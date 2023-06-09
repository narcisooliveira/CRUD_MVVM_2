//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace CRUD_MVVM_2.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Runtime.CompilerServices;

    public partial class ClientDetail : INotifyPropertyChanged
    {
        private int _id;
        private string _name;
        private string _gender;
        private int _age;
        private string _address;


        public int id
        {
            get => _id;
            set
            {
                _id = value;
                OnProPertyChanged(nameof(id));
            }

        }

        public string name
        {
            get => _name;
            set
            {
                _name = value;
                OnProPertyChanged(nameof(name));
            }

        }
        public string gender
        {
            get => _gender;
            set
            {
                _gender = value;
                OnProPertyChanged(nameof(gender));
            }

        }
        public Nullable<int> age
        {
            get => _age;
            set
            {
                _age = (int)value;
                OnProPertyChanged(nameof(age));
            }

        }
        public string address
        {
            get => _address;
            set
            {
                _address = value;
                OnProPertyChanged(nameof(address));
            }

        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnProPertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
