using BLL.Responses;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.Validation
{
    public interface IValidatable
    {
        bool IsValid(ref string errorText) { return true; }
    }
}
