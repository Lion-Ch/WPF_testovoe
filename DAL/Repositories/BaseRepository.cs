using DAL.EF;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DAL.Repositories
{
    public class BaseRepository<T> : IRepository<T>, IDisposable
        where T: class
    {
        protected ShopContext db;

        public BaseRepository()
        {
            db = new ShopContext();
        }

        public virtual T Find(T item)
        {
            return null;
        }
        public virtual IEnumerable<T> GetAll()
        {
            return db.Set<T>().ToList();
        }
        public virtual T Get(T item)
        {
            return Find(item);
        }
        public virtual T Get(int id)
        {
            throw new NotImplementedException();
        }
        public virtual void CreateRange(IEnumerable<T> list)
        {
            db.Set<T>().AddRange(list);
        }
        public virtual void UpdateRange(IEnumerable<T> list)
        {
            foreach (T ob in list)
            {
                T original = Find(ob);

                if (original != null)
                {
                    db.Entry(original).CurrentValues.SetValues(ob);
                }
            }
        }
        public virtual void DeleteRange(IEnumerable<T> list)
        {
            foreach (T ob in list)
            {
                T a = Find(ob);

                if (a != null)
                    db.Set<T>().Remove(a);
            }
        }
        public virtual void Save()
        {
            db.SaveChanges();
        }


        protected bool disposed = false;

        public virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    db.Dispose();
                }
                this.disposed = true;
            }
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
