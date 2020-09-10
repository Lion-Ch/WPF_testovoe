using BLL.Interfaces;
using BLL.Response;
using BLL.Validation;
using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.DTO
{
    public class CategoryDTO: IValidatable
    {
        public int Id { get; set; }
        public string Name { get; set; }

        //public Category Copy()
        //{
        //    return new Category { Id = Id, Name = Name };
        //}

        public ValidationResponse IsValid()
        {
            if (String.IsNullOrEmpty(Name))
            {
                return new ValidationResponse(
                    false,
                    Resources.StringValidateError + $" Категория ID:{Id}",
                    StatusResponse.WARNING);
            }

            return new ValidationResponse(true);
        }

    }
}
