using BLL.Validation;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.DTO
{
    public class CategoryDTO: IValidatable
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public bool IsValid(string errorText)
        {
            if (String.IsNullOrEmpty(Name))
            {
                errorText = Resources.StringValidateError + $" Категория ID:{Id}";
                return false;
            }

            return true;
        }
    }
}
