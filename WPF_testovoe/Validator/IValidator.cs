using System;
using System.Collections.Generic;
using System.Text;
using WPF_testovoe.Entity.Model;

namespace WPF_testovoe.Validator
{
    public interface IValidator
    {
        public string ErrorText { get; }


        public bool IsValid(Product Product);
        public bool IsValid(Product  product);
        public bool IsValid(Employee employee);
        public bool IsValid(Sale     sale);

        public bool IsValid(IEnumerable<Product> categories);
        public bool IsValid(IEnumerable<Product>  products);
        public bool IsValid(IEnumerable<Employee> employees);
        public bool IsValid(IEnumerable<Sale>     sales);
    }
}
