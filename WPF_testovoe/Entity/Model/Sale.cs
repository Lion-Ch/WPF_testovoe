using System;
using System.Collections.Generic;
using System.Text;
using WPF_testovoe.Utilty;

namespace WPF_testovoe.Entity.Model
{
    public class Sale: ObservableObject
    {
        private int _amount;
        public int Amount
        {
            get { return _amount; }
            set { OnPropertyChanged(ref _amount, value); }
        }

        private int _productId;
        public int ProductId
        {
            get { return _productId; }
            set { OnPropertyChanged(ref _productId, value); }
        }
        public Product Product { get; set; }

        private int _employeeId; 
        public int EmployeeId
        {
            get { return _employeeId; }
            set { OnPropertyChanged(ref _employeeId, value); }
        }
        public Employee Employee { get; set; }
    }
}
