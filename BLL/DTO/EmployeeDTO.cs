﻿using BLL.Validation;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.DTO
{
    public class EmployeeDTO: IValidatable
    {
        public int Id { get; set; }
        public string FullName { get; set; }

        public bool IsValid(string errorText)
        {
            if (String.IsNullOrEmpty(FullName))
            {
                errorText = Resources.StringValidateError + $" Сотрудник ID:{Id}";
                return false;
            }

            return true;
        }
    }
}
