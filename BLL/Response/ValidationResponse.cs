using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.Response
{
    public class ValidationResponse : Response
    {
        public bool IsValid { get; private set; }
        public ValidationResponse(bool isValid)
        {
            IsValid = isValid;
        }
        public ValidationResponse(bool isValid,string text, StatusResponse statusResponse) : base(text, statusResponse)
        {
            IsValid = isValid;
        }

    }
}
