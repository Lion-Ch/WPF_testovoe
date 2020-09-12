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
    public class ProductRepository: BaseRepository, IRepository<Product>, IDisposable
    {
        public IEnumerable<Product> GetAll()
        {
            return db.Products.Include(i=>i.Category).ToList();
        }
        public void CreateRange(IEnumerable<Product> list)
        {
            db.Products.AddRange(list);
        }
        public void UpdateRange(IEnumerable<Product> list)
        {
            foreach (Product ob in list)
            {
                Product original = db.Products.Find(ob.Id);

                if (original != null)
                {
                    db.Entry(original).CurrentValues.SetValues(ob);
                }
            }
        }
        public void DeleteRange(IEnumerable<Product> list)
        {
            foreach (Product ob in list)
            {
                Product a = db.Products.Find(ob.Id);

                if (a != null)
                    db.Products.Remove(a);
            }
        }

        public Product Get(Product item)
        {
            return db.Products.Find(item.Id);
        }

        public Product Get(int id)
        {
            return db.Products.Find(id);
        }
    }
}
