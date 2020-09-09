using BLL.DTO;
using System;
using System.Collections.Generic;

namespace WPF_testovoe.Validator
{
    public class BaseValidator : IValidator
    {
        public string ErrorText { get; private set; }

        //public bool IsValid(CategoryDTO category)
        //{
        //    if (category == null)
        //    {
        //        ErrorText = "Не указано поле 'Категория'";
        //        return false;
        //    }

        //    if (String.IsNullOrEmpty(category.Name))
        //    {
        //        ErrorText = Properties.Resources.StringValidateError + $" Категория ID:{category.Id}";
        //        return false;
        //    }

        //    return true;
        //}

        //public bool IsValid(ProductDTO product)
        //{
        //    if (product == null)
        //    {
        //        ErrorText = "Не указано поле 'Продукт'";
        //        return false;
        //    }

        //    if (product.Amount < 0 || String.IsNullOrEmpty(product.Name))
        //    {
        //        ErrorText = Properties.Resources.AmountValidateError + ", " + Properties.Resources.StringValidateError + $" Продукт ID:{product.Id}";
        //        return false;
        //    }
        //    else
        //        return false;
        //}

        //public bool IsValid(EmployeeDTO employee)
        //{
        //    if (employee == null)
        //    {
        //        ErrorText = "Не указано поле 'Сотрудник'";
        //        return false;
        //    }

        //    if (String.IsNullOrEmpty(employee.FullName))
        //    {
        //        ErrorText = Properties.Resources.StringValidateError + $" Сотрудник ID:{employee.Id}";
        //        return false;
        //    }

        //    return true;
        //}

        //public bool IsValid(SaleDTO sale)
        //{
        //    if(sale == null)
        //    {
        //        ErrorText = "Не указано поле 'Продажа'";
        //        return false;
        //    }
        //    if(sale.Amount < 0)
        //    {
        //        ErrorText = Properties.Resources.AmountValidateError + $", Продавец: {sale.EmployeeId}, Товар: {sale.ProductId}";
        //        return false;
        //    }

        //    return true;
        //}
        public bool IsValid(CategoryDTO listDTO)
        {
            return true;
        }
        public bool IsValid(ProductDTO listDTO)
        {
            return true;
        }

        //public bool IsValid<T>(IEnumerable<T> listDTO) where T: IValitable
        //{
        //    foreach(T ob in listDTO)
        //    {
        //        if (!IsValid(ob))
        //            return false;
        //    }
        //    return true;
        //}

        //Создать единое обобщение для ниже приведенных методов
        //не позволяет c#

        //public bool IsValid(IEnumerable<Product> products)
        //{
        //    foreach(Product c in products)
        //    {
        //        if (!IsValid(c))
        //            return false;
        //    }

        //    return true;
        //}

        //public bool IsValid(IEnumerable<Category> categories)
        //{
        //    foreach (Category c in categories)
        //    {
        //        if (!IsValid(c))
        //            return false;
        //    }

        //    return true;
        //}

        //public bool IsValid(IEnumerable<Employee> employees)
        //{
        //    foreach (Employee c in employees)
        //    {
        //        if (!IsValid(c))
        //            return false;
        //    }

        //    return true;
        //}

        //public bool IsValid(IEnumerable<Sale> sales)
        //{
        //    foreach (Sale c in sales)
        //    {
        //        if (!IsValid(c))
        //            return false;
        //    }

        //    return true;
        //}
    }
}
