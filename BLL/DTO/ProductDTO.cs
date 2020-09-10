using BLL.Response;
using BLL.Validation;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.DTO
{
    public class ProductDTO: IValidatable
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Amount { get; set; }
        public int CategoryId { get; set; }

        public ValidationResponse IsValid()
        {
            if (Amount < 0 || String.IsNullOrEmpty(Name))
            {
                return new ValidationResponse(
                          false,
                          Resources.AmountValidateError + ", " + Resources.StringValidateError + $" Продукт ID:{Id}",
                          StatusResponse.WARNING);
            }
            else
                return new ValidationResponse(true);
        }
    }
}
