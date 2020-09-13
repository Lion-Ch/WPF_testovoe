using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Interfaces
{
    public interface IRepository<T>
    {
        IEnumerable<T> GetAll();
        T Get(T item);
        T Get(int id);
        T Find(T item);
        void CreateRange(IEnumerable<T> list);
        void UpdateRange(IEnumerable<T> list);
        void DeleteRange(IEnumerable<T> list);
        void Save();
        void Dispose();
    }
}
