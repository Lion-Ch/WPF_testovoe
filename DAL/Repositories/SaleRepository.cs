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
    public class SaleRepository: BaseRepository, IRepository<Sale>
    {
        public IEnumerable<Sale> GetAll()
        {
            return db.Sales.ToList();
        }
        public void CreateRange(IEnumerable<Sale> list)
        {
            db.Sales.AddRange(list);
        }
        public void UpdateRange(IEnumerable<Sale> list)
        {
            foreach (Sale ob in list)
            {
                Sale original = db.Sales.Find(ob.EmployeeId,ob.ProductId);

                if (original != null)
                {
                    db.Entry(original).CurrentValues.SetValues(ob);
                }
            }
        }
        public void DeleteRange(IEnumerable<Sale> list)
        {
            foreach (Sale ob in list)
            {
                Sale a = db.Sales.Find(ob.EmployeeId,ob.ProductId);

                if (a != null)
                    db.Sales.Remove(a);
            }
        }
    }
}
