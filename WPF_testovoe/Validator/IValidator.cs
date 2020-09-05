using System;
using System.Collections.Generic;
using System.Text;
using WPF_testovoe.Entity.Model;

namespace WPF_testovoe.Validator
{
    public interface IValidator
    {
        public bool IsValid(Category category);
        public bool IsValid(Product product);
        public bool IsValid(Employee employee);
        public bool IsValid(Sale sale);
    }
}
