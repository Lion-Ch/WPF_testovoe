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
    public class CategoryRepository : BaseRepository, IRepository<Category>
    {
        public IEnumerable<Category> GetAll()
        {
            return db.Categories.AsNoTracking().ToList();
        }
        public void CreateRange(IEnumerable<Category> list)
        {
            db.Categories.AddRange(list);
        }
        public void UpdateRange(IEnumerable<Category> list)
        {
            foreach(Category ob in list)
            {
                Category original = db.Categories.Find(ob.Id);

                if (original != null)
                    db.Entry(original).CurrentValues.SetValues(ob);
            }
        }
        public void DeleteRange(IEnumerable<Category> list)
        {
            foreach(Category ob in list)
            {
                Category a = db.Categories.Find(ob.Id);

                if (a != null)
                    db.Categories.Remove(a);
            }
        }
    }
}
