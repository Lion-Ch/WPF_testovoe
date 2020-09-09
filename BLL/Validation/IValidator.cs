using BLL.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace WPF_testovoe.Validator
{
    public interface IValidator
    {
        public string ErrorText { get; }


        //public bool IsValid(CategoryDTO category);
        //public bool IsValid(ProductDTO product);
        //public bool IsValid(EmployeeDTO employee);
        //public bool IsValid(SaleDTO sale);

        //public bool IsValid<T>(IEnumerable<T> categories);
    }
}
