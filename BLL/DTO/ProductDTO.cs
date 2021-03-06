﻿using BLL.Responses;
using BLL.Validation;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.DTO
{
    public sealed class ProductDTO: IValidatable
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Amount { get; set; }

        public int CategoryId { get; set; }
        public string CategoryName { get; set; }

        public bool IsValid(ref string errorText)
        {
            if (Amount < 0 || String.IsNullOrEmpty(Name))
            {
                errorText = Resources.AmountValidateError + ", " + Resources.StringValidateError + $" Продукт ID:{Id}";
                return false;
            }
            else if(CategoryId == 0)
            {
                errorText = Resources.NotHaveCategory + $" Продукт ID:{Id}";
                return false;
            }
            else
                return true;
        }
    }
}
