using CRUD_MVVM_2.Models;
using CRUD_MVVM_2.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace CRUD_MVVM_2.ViewModels
{
    public class ClientViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private ObservableCollection<ClientDetail> _lstClientDetail;

        public ObservableCollection<ClientDetail> LstClientDetail
        {
            get { return _lstClientDetail; }
            set 
            {
                _lstClientDetail = value; 
                OnPropertyChanged(nameof(LstClientDetail));
            }
        }
        private ClientDetail _selectedClient;

        public ClientDetail SelectedClient
        {
            get { return _selectedClient; }
            set
            {
                _selectedClient = value;
                OnPropertyChanged(nameof(SelectedClient));
            }
        }
        private ClientDetail clientDetail = new ClientDetail();

        public ClientDetail ClientDetail
        {
            get { return clientDetail; }
            set
            {
                clientDetail = value;
                OnPropertyChanged(nameof(ClientDetail));
            }
        }

        readonly ClientEntities clientEntities;

        public ClientViewModel()
        {
            clientEntities =  new ClientEntities();
            LoadClient();
            DeleteCommand = new Command((s) => true, Delete);
            UpdateCommand = new Command((s) => true, Update);
            UpdateClientCommand = new Command((s) => true, UpdateClient);
            AddClientCommand = new Command((s) => true, AddClient);
        }

        private void AddClient(object obj)
        {
            ClientDetail.id = clientEntities.ClientDetails.Count();
            clientEntities.ClientDetails.Add(ClientDetail);
            clientEntities.SaveChanges();
            LstClientDetail.Add(ClientDetail);
            ClientDetail = new ClientDetail();
        }

        private void UpdateClient(object obj)
        {
            clientEntities.SaveChanges();
            SelectedClient = new ClientDetail();
        }

        private void Update(object obj)
        {
            SelectedClient = obj as ClientDetail;
        }

        private void Delete(object obj)
        {
            var cln = obj as ClientDetail;
            clientEntities.ClientDetails.Remove(cln);
            clientEntities.SaveChanges();
            LstClientDetail.Remove(cln);
        }

        private void LoadClient()
        {
            LstClientDetail = new ObservableCollection<ClientDetail>(clientEntities.ClientDetails);
        }

        public ICommand UpdateClientCommand { get; set; }
        public ICommand UpdateCommand { get; set; }
        public ICommand DeleteCommand { get; set; }
        public ICommand AddClientCommand { get; set; }
    }

    class Command : ICommand
    {
        public Command(Func<object, bool> methodCanExecute, Action<object> methodExecuted)
        {
            MethodCanExecute = methodCanExecute;
            MethodExecute = methodExecuted;
        }
        readonly Action<object> MethodExecute;
        readonly Func<object, bool> MethodCanExecute;
        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return MethodExecute != null && MethodCanExecute.Invoke(parameter);
        }

        public void Execute(object parameter)
        {
            MethodExecute(parameter);
        }
    }
}
