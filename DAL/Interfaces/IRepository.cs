using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Interfaces
{
    public interface IRepository<T> where T : BaseEntity
    {
        void Create(T item);
        void Update(T item);
        void Delete(T item);

        void CreateRange(IEnumerable<T> list);
        void UpdateRange(IEnumerable<T> list);
        void DeleteRange(IEnumerable<T> list);

        public IEnumerable<T> GetAll(List<int> listId);
        IEnumerable<T> GetAll();
        void Save();
        void Dispose();
    }
}
