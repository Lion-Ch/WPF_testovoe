using BLL.Responses;
using BLL.Validation;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.DTO
{
    public class EmployeeDTO: IValidatable
    {
        public int Id { get; set; }
        public string FullName { get; set; }

        public ValidationResponse IsValid()
        {
            if (String.IsNullOrEmpty(FullName))
            {
                return new ValidationResponse(
                       false,
                       Resources.StringValidateError + $" Сотрудник ID:{Id}",
                       StatusResponse.WARNING);
            }

            return new ValidationResponse(true);
        }
    }
}
