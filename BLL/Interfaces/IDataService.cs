using AutoMapper;
using BLL.Responses;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.Interfaces
{
    public interface IDataService<T>
    {
        IResponse Create(T item);
        IResponse Update(T item);
        IResponse Delete(T item);

        IResponse CreateRange(IEnumerable<T> list);
        IResponse UpdateRange(IEnumerable<T> list);
        IResponse DeleteRange(IEnumerable<T> list);

        IEnumerable<T> GetAll();
        public void Save();
        void Dispose();
    }
}