using BLL.Interfaces;
using BLL.Validation;
using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.DTO
{
    public class CategoryDTO: BaseModel, IValidatable
    {
        public override int Id { get; set; }
        public string Name { get; set; }

        //public Category Copy()
        //{
        //    return new Category { Id = Id, Name = Name };
        //}

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
