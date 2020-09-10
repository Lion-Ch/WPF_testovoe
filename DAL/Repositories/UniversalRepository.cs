using DAL.EF;
using DAL.Entities;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DAL.Repositories
{
    public class UniversalRepository<T> : IRepository<T> , IDisposable
        where T: BaseModel
    {
        private ShopContext db;

        public UniversalRepository()
        {
            db = new ShopContext();
        }
        public void Create(T item)
        {
            db.Set<T>().Add(item);
        }
        public void CreateRange(IEnumerable<T> list)
        {
            db.Set<T>().AddRange(list);
        }
        public void Update(T item)
        {
            var dbEntity = db.Set<T>().Find(item.Id);
            if (dbEntity == null)
            {
                throw new NotImplementedException("Объект не найден. Обработка этого исключения находится на стадии разработки");
            }
            db.Entry(dbEntity).CurrentValues.SetValues(item);
        }

        public void Delete(T item)
        {
            T i = db.Set<T>().Find(item.Id);
            db.Remove(i);
        }

        public IEnumerable<T> GetAll()
        {
            return db.Set<T>().ToList();
        }

        public void Save()
        {
            db.SaveChanges();
        }

        private bool disposed = false;
        public virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    db.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
