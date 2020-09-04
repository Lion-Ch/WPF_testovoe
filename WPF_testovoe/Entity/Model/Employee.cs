using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using WPF_testovoe.Utilty;

namespace WPF_testovoe.Entity.Model
{
    public class Employee : ObservableObject
    {
        public int Id { get; set; }

        private string _fullName;
        public string FullName 
        { 
            get { return _fullName; } 
            set { OnPropertyChanged(ref _fullName, value); } 
        }

        public IEnumerable<Sale> Sales { get; set; }

        public Employee()
        {
            Sales = new List<Sale>();
        }
    }
}
