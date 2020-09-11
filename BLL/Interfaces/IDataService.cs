using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.Interfaces
{
    public interface IDataService<T>
    {
        IEnumerable<T> GetAll();
        void CreateRange(IEnumerable<T> item);
        void UpdateRange(IEnumerable<T> item);
        void DeleteRange(IEnumerable<T> id);
        public void Save();
        void Dispose();
    }
}
