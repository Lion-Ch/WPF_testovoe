using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<T> Universal<T>() where T : class;
        IRepository<Category> Categories { get; }
        IRepository<Employee> Employees { get; }
        IRepository<Product> Products { get; }
        IRepository<Sale> Sales { get; }
        void Save();
    }
}
