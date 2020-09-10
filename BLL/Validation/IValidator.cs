using BLL.Validation;
using BLL.Responses;
using System.Collections.Generic;

namespace WPF_testovoe.Validator
{
    public interface IValidator
    {
        public ValidationResponse IsValid(IValidatable objDTO);
        public ValidationResponse IsValid(IEnumerable<IValidatable> listDTO);
    }
}
