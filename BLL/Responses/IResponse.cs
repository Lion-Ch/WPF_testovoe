using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.Responses
{
    public interface IResponse
    {
        string Text { get; }
        string Color { get;}
        StatusResponse StatusResponse { get; }
    }

    public enum StatusResponse
    {
        OK,
        ERROR,
        WARNING
    }
}
