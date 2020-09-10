using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.Response
{
    public class Response : IResponse
    {
        public string Text { get; private set; }
        public string Color { get; private set; }
        public StatusResponse StatusResponse { get; private set; }

        public Response(string text, StatusResponse statusResponse)
        {
            Text = text;
            StatusResponse = statusResponse;
            Color = GetColor(statusResponse);
        }

        public Response()
        {
        }

        private string GetColor(StatusResponse status)
        {
            switch(StatusResponse)
            {
                case StatusResponse.ERROR:return "Brown";
                case StatusResponse.OK:return "YellowGreen";
                case StatusResponse.WARNING: return "Khaki";
                default:return "Black";
            }
        }
    }
}
