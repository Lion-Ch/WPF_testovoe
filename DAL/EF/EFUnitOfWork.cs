using DAL.Entities;
using DAL.Interfaces;
using DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.EF
{
    public class EFUnitOfWork
    {
        private ShopContext db;

        public EFUnitOfWork()
        {
            db = new ShopContext();
        }

        public IRepository<dbType> GetRepository<dbType>()
            where dbType : BaseEntity
        {
            return new UniversalRepository<dbType>();
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
