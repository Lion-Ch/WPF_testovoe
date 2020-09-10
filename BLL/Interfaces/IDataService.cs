using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.Interfaces
{
    public interface IDataService<T> where T : class
    {
        IEnumerable<T> GetAll();
        void CreateRange(IEnumerable<T> list);
        void Create(T item);
        void Update(T item);
        void Delete(T item);
        public void Save();
        void Dispose();
    }
}