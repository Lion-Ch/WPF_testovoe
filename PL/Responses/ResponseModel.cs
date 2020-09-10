using BLL.Responses;
using PL.Utility;
using System;
using System.Collections.Generic;
using System.Text;

namespace PL.Responses
{
    public class ResponseModel: ObservableObject , IResponse
    {
        private string _text;
        public string Text
        {
            get { return _text; }
            set { OnPropertyChanged(ref _text,  value); }
        }
        private string _color;
        public string Color
        {
            get { return _color; }
            set { OnPropertyChanged(ref _color, value); }
        }
        public StatusResponse StatusResponse { get; }
    }
}
