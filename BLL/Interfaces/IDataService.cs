using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.Interfaces
{
    public interface IDataService<T> where T : class
    {
        IEnumerable<T> GetAll();
        void Create(T item);
        void Update(T item);
        void Delete(int id);
        void Dispose();
    }
}
