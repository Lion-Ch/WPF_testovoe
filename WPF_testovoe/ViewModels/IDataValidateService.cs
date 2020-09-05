using System;
using System.Collections.Generic;
using System.Text;
using WPF_testovoe.Validator;

namespace WPF_testovoe.ViewModels
{
    public interface IDataValidateService
    {
        public IValidator Validator { get; set; }
    }
}
