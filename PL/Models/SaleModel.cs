using PL.Utility;
using System;
using System.Collections.Generic;
using System.Text;

namespace PL.Models
{
    public class SaleModel: ObservableObject
    {
        private int amount;
        public int Amount
        {
            get { return amount; }
            set { OnPropertyChanged(ref amount, value); }
        }
        public int EmployeeId { get; set; }
        public string EmployeeFullName { get; set; }
        public int ProductId { get; set; }
        public string ProductName { get; set; }

        private EmployeeModel employee;
        public EmployeeModel Employee
        {
            get { return employee; }
            set { EmployeeId = value.Id; EmployeeFullName = value.FullName; OnPropertyChanged(ref employee, value); }
        }
        private ProductModel product;
        public ProductModel Product
        {
            get { return product; }
            set { ProductId = value.Id; ProductName = value.Name; OnPropertyChanged(ref product, value); }
        }
    }
}
