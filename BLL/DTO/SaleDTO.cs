using BLL.Responses;
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

        public ValidationResponse IsValid()
        {
            if (Amount < 0)
            {
                return new ValidationResponse(
                             false,
                             Resources.AmountValidateError + $", Продавец: {EmployeeId}, Товар: {ProductId}",
                            StatusResponse.WARNING);
            }

            return new ValidationResponse(true);
        }
    }
}
