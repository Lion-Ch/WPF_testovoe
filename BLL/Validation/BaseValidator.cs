using BLL.DTO;
using BLL.Responses;
using BLL.Validation;
using System;
using System.Collections.Generic;

namespace WPF_testovoe.Validator
{
    public class BaseValidator : IValidator
    {
        public IResponse Response { get; private set; }

        public ValidationResponse IsValid(IValidatable objDTO)
        {
            return objDTO.IsValid();
        }
        public ValidationResponse IsValid(IEnumerable<IValidatable> listDTO) 
        {
            foreach (IValidatable ob in listDTO)
            {
                var response = ob.IsValid();
                if (response.IsValid)
                    return response;
            }
            return new ValidationResponse(true);
        }
    }
}
