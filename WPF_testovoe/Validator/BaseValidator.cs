using System;
using System.Collections.Generic;
using System.Text;
using WPF_testovoe.Entity.Model;

namespace WPF_testovoe.Validator
{
    public class BaseValidator : IValidator
    {
        public string ErrorText { get; private set; }

        public bool IsValid(Category category)
        {
            if (String.IsNullOrEmpty(category.Name))
            {
                ErrorText = Properties.Resources.StringValidateError + $" Категория ID:{category.Id}";
                return false;
            }

            return true;
        }

        public bool IsValid(Product product)
        {
            if (IsValid(product.Category))
            {
                if (product.Amount <= 0 || String.IsNullOrEmpty(product.Name))
                {
                    ErrorText = Properties.Resources.AmountValidateError + ", " + Properties.Resources.StringValidateError + $" Продукт ID:{product.Id}";
                    return false;
                }

                return false;
            }
            else
                return false;
        }

        public bool IsValid(Employee employee)
        {
            if (String.IsNullOrEmpty(employee.FullName))
            {
                ErrorText = Properties.Resources.StringValidateError + $" Сотрудник ID:{employee.Id}";
                return false;
            }

            return true;
        }

        public bool IsValid(Sale sale)
        {
            ErrorText = null;
            return false;
        }

        //Создать единое обобщение для ниже приведенных методов
        //не позволяет c#

        public bool IsValid(IEnumerable<Category> categories)
        {
            foreach(Category c in categories)
            {
                if (!IsValid(c))
                    return false;
            }

            return true;
        }

        public bool IsValid(IEnumerable<Product> products)
        {
            foreach (Product c in products)
            {
                if (!IsValid(c))
                    return false;
            }

            return true;
        }

        public bool IsValid(IEnumerable<Employee> employees)
        {
            foreach (Employee c in employees)
            {
                if (!IsValid(c))
                    return false;
            }

            return true;
        }

        public bool IsValid(IEnumerable<Sale> sales)
        {
            foreach (Sale c in sales)
            {
                if (!IsValid(c))
                    return false;
            }

            return true;
        }
    }
}
