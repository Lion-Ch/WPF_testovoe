using Microsoft.EntityFrameworkCore;
using System.Configuration;
using WPF_testovoe.Entity.Model;
using WPF_testovoe.Entity.Configuration;

namespace WPF_testovoe.Entity.Context
{
    public class MSSQLContext : DbContext, IContext
    {
        public DbSet<Product> Categories { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Product>  Products { get; set; }
        public DbSet<Sale>     Sales { get; set; }

        public MSSQLContext()
        {
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(ConfigurationManager.ConnectionStrings["MSSQL_Connection"].ToString());
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ProductConfiguration());
            modelBuilder.ApplyConfiguration(new EmployeeConfiguration());
            modelBuilder.ApplyConfiguration(new ProductConfiguration());
            modelBuilder.ApplyConfiguration(new SaleConfiguration());
        }
    }
}
