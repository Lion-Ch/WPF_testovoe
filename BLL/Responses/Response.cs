using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.Responses
{
    public class Response
    {
        public string Text { get;}
        public TypeRespone Status { get; }

        public Response(string text, TypeRespone status)

        {
            Text = text;
            Status = status;
        }
    }

    public enum TypeRespone
    {
        OK,
        ERROR,
        WARNING
    }
}
