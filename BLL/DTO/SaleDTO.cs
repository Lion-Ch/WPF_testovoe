using BLL.Validation;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.DTO
{
    public class SaleDTO: IValidatable
    {
        public int Amount { get; set; }

        public int ProductId { get; set; }
        public int EmployeeId { get; set; }

        public bool IsValid(string errorText)
        {
            if (Amount < 0)
            {
                errorText = Resources.AmountValidateError + $", Продавец: {EmployeeId}, Товар: {ProductId}";
                return false;
            }

            return true;
        }
    }
}
