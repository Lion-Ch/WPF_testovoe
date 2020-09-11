using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Interfaces
{
    public interface IRepository<T>
    {
        IEnumerable<T> GetAll();
        void CreateRange(IEnumerable<T> item);
        void UpdateRange(IEnumerable<T> item);
        void DeleteRange(IEnumerable<T> item);
        void Save();
        void Dispose();
    }
}
