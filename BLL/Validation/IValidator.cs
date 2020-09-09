using BLL.DTO;
using BLL.Validation;
using System;
using System.Collections.Generic;
using System.Text;

namespace WPF_testovoe.Validator
{
    public interface IValidator
    {
        public bool IsValid(IValidatable objDTO);
        public bool IsValid(IEnumerable<IValidatable> listDTO);
    }
}
