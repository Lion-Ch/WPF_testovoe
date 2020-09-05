using System;
using System.Collections.Generic;
using System.Text;
using WPF_testovoe.Entity.Model;

namespace WPF_testovoe.Validator
{
    public class BaseValidator : IValidator
    {
        public bool IsValid(Category category)
        {
            if (category.Name.Length >= 0)
                return true;

            return false;
        }

        public bool IsValid(Product product)
        {
            if (IsValid(product.Category))
                if(product.Amount>=0 && product.Name.Length>=0)
                    return true;

            return false;
        }

        public bool IsValid(Employee employee)
        {
            if (employee.FullName.Length >= 0)
                return true;

            return false;
        }

        public bool IsValid(Sale sale)
        {
            throw new NotImplementedException();
        }
    }
}
