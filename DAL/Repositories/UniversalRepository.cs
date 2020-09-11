using DAL.EF;
using DAL.Entities;
using DAL.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DAL.Repositories
{
    public class UniversalRepository<T> : IRepository<T> , IDisposable
        where T: BaseEntity
    {
        private ShopContext db;

        public UniversalRepository(ShopContext context)
        {
            db = context;
        }
        public void Create(T item)
        {
            db.Set<T>().Add(item);
        }
        public void CreateRange(IEnumerable<T> list)
        {
            db.Set<T>().AddRange(list);
        }
        public void UpdateRange(IEnumerable<T> list)
        {
            foreach (T ob in list)
                Update(ob);
        }

        public void DeleteRange(IEnumerable<T> list)
        {
            foreach (T ob in list)
                Delete(ob);
        }
        public void Update(T item)
        {
            var dbEntity = db.Set<T>().Find(item.Id);
            if (dbEntity != null)
                db.Entry(dbEntity).CurrentValues.SetValues(item);
        }

        public void Delete(T item)
        {
            T i = db.Set<T>().Find(item.Id);
            if(i!=null)
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
