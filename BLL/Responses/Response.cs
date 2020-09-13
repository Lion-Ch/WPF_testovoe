using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.Responses
{
    public class Response
    {
        public string Text { get; private set; }
        public TypeRespone Status { get; private set; }

        public Response(string text, TypeRespone status)
        {
            Text = text;
            Status = status;
        }
        public void SetData(string text,TypeRespone status)
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
