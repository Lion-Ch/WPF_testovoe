using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Interfaces
{
    public interface IRepository<T> where T : BaseModel
    {
        IEnumerable<T> GetAll();
        void CreateRange(IEnumerable<T> list);
        void Create(T item);
        void Update(T item);
        void Delete(T item);
        void Save();
        void Dispose();
    }
}
