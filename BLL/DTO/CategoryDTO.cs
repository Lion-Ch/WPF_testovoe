using BLL.Interfaces;
using BLL.Responses;
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
