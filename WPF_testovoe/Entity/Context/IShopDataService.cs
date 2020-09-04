using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using WPF_testovoe.Entity.Model;

namespace WPF_testovoe.Entity.Context
{
    public interface IShopDataService
    {
        public DbSet<Category> Categories { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Sale> Sales { get; set; }

        public int SaveChanges();
    }
}
