using DAL.EF;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Repositories
{
    public class BaseRepository 
    {
        protected ShopContext db;

        public BaseRepository()
        {
            db = new ShopContext();
        }

        public void Save()
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
