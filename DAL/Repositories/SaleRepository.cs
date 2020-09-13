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
    public class SaleRepository: BaseRepository<Sale>
    {
        public override Sale Find(Sale item)
        {
            return db.Sales.Find(item.EmployeeId, item.ProductId);
        }

        public override Sale Get(Sale item)
        {
            return db.Sales.Find(item.EmployeeId, item.ProductId);
        }
        public override IEnumerable<Sale> GetAll()
        {
            return db.Sales.Include(i => i.Product).Include(i => i.Employee).ToList();
        }
    }
}
