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
    public class SaleRepository: IRepository<Sale>
    {
        private ShopContext db;

        public SaleRepository(ShopContext context)
        {
            this.db = context;
        }

        public IEnumerable<Sale> GetAll()
        {
            return db.Sales;
        }

        public Sale Get(int id)
        {
            return db.Sales.Find(id);
        }

        public void Create(Sale sale)
        {
            db.Sales.Add(sale);
        }

        public void Update(Sale sale)
        {
            var original = db.Products.Find(sale.ProductId, sale.EmployeeId);

            if (original != null)
            {
                db.Entry(original).CurrentValues.SetValues(sale);
            }
        }

        public IEnumerable<Sale> Find(Func<Sale, Boolean> predicate)
        {
            return db.Sales.Where(predicate).ToList();
        }

        public void Delete(int id)
        {
            Sale sale = db.Sales.Find(id);
            if (sale != null)
                db.Sales.Remove(sale);
        }
    }
}
