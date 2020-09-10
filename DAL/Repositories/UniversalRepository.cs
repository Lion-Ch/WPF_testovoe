using DAL.EF;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DAL.Repositories
{
    public class UniversalRepository<T> : IRepository<T> , IDisposable
        where T: class
    {
        private ShopContext db;

        public UniversalRepository(ShopContext context)
        {
            this.db = context;
        }
        public void Create(T item)
        {
            db.Add(item);
        }

        public void Update(T item)
        {
        }

        public void Delete(T item)
        {
            db.Remove(item);
        }

        public T Get(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<T> GetAll()
        {
            return db.Set<T>().ToList();
        }

        public IEnumerable<T> Find(Func<T, bool> predicate)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
