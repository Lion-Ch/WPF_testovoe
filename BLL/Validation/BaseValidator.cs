using BLL.DTO;
using BLL.Validation;
using System;
using System.Collections.Generic;

namespace WPF_testovoe.Validator
{
    public class BaseValidator : IValidator
    {
        public string ErrorText { get; private set; }

        public bool IsValid(IValidatable objDTO)
        {
            return objDTO.IsValid(ErrorText);
        }
        public bool IsValid(IEnumerable<IValidatable> listDTO) 
        {
            foreach (IValidatable ob in listDTO)
            {
                if (ob.IsValid(ErrorText))
                    return false;
            }
            return true;
        }
    }
}
