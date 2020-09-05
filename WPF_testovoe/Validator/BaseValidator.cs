﻿using System;
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
            if (category == null)
            {
                ErrorText = "Не указано поле 'Категория'";
                return false;
            }

            if (String.IsNullOrEmpty(category.Name))
            {
                ErrorText = Properties.Resources.StringValidateError + $" Категория ID:{category.Id}";
                return false;
            }

            return true;
        }

        public bool IsValid(Product product)
        {
            if (product == null)
            {
                ErrorText = "Не указано поле 'Продукт'";
                return false;
            }

            if (IsValid(product.Category))
            {
                if (product.Amount < 0 || String.IsNullOrEmpty(product.Name))
                {
                    ErrorText = Properties.Resources.AmountValidateError + ", " + Properties.Resources.StringValidateError + $" Продукт ID:{product.Id}";
                    return false;
                }

                return true;
            }
            else
                return false;
        }

        public bool IsValid(Employee employee)
        {
            if (employee == null)
            {
                ErrorText = "Не указано поле 'Сотрудник'";
                return false;
            }

            if (String.IsNullOrEmpty(employee.FullName))
            {
                ErrorText = Properties.Resources.StringValidateError + $" Сотрудник ID:{employee.Id}";
                return false;
            }

            return true;
        }

        public bool IsValid(Sale sale)
        {
            if(sale == null)
            {
                ErrorText = "Не указано поле 'Продажа'";
                return false;
            }
            if(sale.Amount < 0)
            {
                ErrorText = Properties.Resources.AmountValidateError + $", Продавец: {sale.Employee.FullName}, Товар: {sale.Product.Name}";
                return false;
            }

            return true;
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