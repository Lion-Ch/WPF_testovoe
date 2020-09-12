using BLL.Responses;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.Interfaces
{
    public interface IDataService<T>
    {
        IEnumerable<T> GetAll();
        Response CreateRange(IEnumerable<T> item);
        Response UpdateRange(IEnumerable<T> item);
        Response DeleteRange(IEnumerable<T> id);
        Response Save();
        void Dispose();
    }
}
