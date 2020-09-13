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
    public class ProductRepository: BaseRepository<Product>
    {
        public override Product Get(int id)
        {
            return db.Products.Find(id);
        }
        public override Product Find(Product item)
        {
            return db.Products.Find(item.Id);
        }
        public override IEnumerable<Product> GetAll()
        {
            return db.Products.Include(i => i.Category).ToList();
        }
    }
}
