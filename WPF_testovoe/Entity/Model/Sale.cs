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
        private Product _product;
        public Product Product
        {
            get { return _product; }
            set { OnPropertyChanged(ref _product, value); }
        }

        private int _employeeId; 
        public int EmployeeId
        {
            get { return _employeeId; }
            set { OnPropertyChanged(ref _employeeId, value); }
        }
        private Employee _employee;
        public Employee Employee
        {
            get { return _employee; }
            set { OnPropertyChanged(ref _employee, value); }
        }
    }
}
