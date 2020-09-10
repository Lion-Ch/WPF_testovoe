using BLL.Response;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.Validation
{
    public interface IValidatable
    {
        public ValidationResponse IsValid();
    }
}
