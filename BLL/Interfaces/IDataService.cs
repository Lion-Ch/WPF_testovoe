using BLL.Responses;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.Interfaces
{
    public interface IDataService<T>
    {
        IEnumerable<T> GetAll();
        T Get(int id);
        Response CreateRange(IEnumerable<T> list);
        Response UpdateRange(IEnumerable<T> list);
        Response DeleteRange(IEnumerable<T> list);
        Response Save();

        Response PreparationRange(IEnumerable<T> list);
        Response PreparationObject(T item);
        Response IsValidRange(IEnumerable<T> list);
        Response IsValidObject(T item);

        void Dispose();
    }
}
