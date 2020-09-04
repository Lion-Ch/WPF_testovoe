using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Configuration;
using WPF_testovoe.Entity.Model;
using WPF_testovoe.Entity.Configuration;

namespace WPF_testovoe.Entity.Context
{
    public class ShopContext : DbContext//, IShopDataService
    {
        public DbSet<Category> Categories { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Product>  Products { get; set; }
        public DbSet<Sale>     Sales { get; set; }

        public ShopContext()
        {
            //Database.EnsureDeleted();
            //Database.EnsureCreated();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(ConfigurationManager.ConnectionStrings["MSSQL_Connection"].ToString());
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CategoryConfiguration());
            modelBuilder.ApplyConfiguration(new EmployeeConfiguration());
            modelBuilder.ApplyConfiguration(new ProductConfiguration());
            modelBuilder.ApplyConfiguration(new SaleConfiguration());

            //modelBuilder.Entity<Category>().HasData(
            //    new Category[]
            //    {
            //        new Category{Id=2, Name="Ноутбуки"},
            //        new Category{Id =3,Name="Смартфоны"}
            //    });
            //modelBuilder.Entity<Employee>().HasData(
            //    new Employee[]
            //    {
            //        new Employee{Id=2,FullName="Чуприн Лев Юрьевич"},
            //        new Employee{Id=3,FullName="Петров Сергей Иванович"}
            //    });
            //modelBuilder.Entity<Product>().HasData(
            //    new Product[]
            //    {
            //        new Product{Id=2,Name="iPhone 6"},
            //        new Product{Id=3,Name="Redmi Note 7"}
            //    });
            //modelBuilder.Entity<Sale>().HasData(
            //    new Sale[]
            //    {
            //        new Sale{Id=2,EmployeeId = 2, ProductId = 3, Amount = 3},
            //        new Sale{Id=3,EmployeeId = 3, ProductId = 2, Amount = 9},
            //    });
        }
    }
}
