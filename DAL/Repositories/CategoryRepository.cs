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
    public class CategoryRepository : BaseRepository<Category>
    {
        public override Category Get(int id)
        {
            return db.Categories.Find(id);
        }
        public override Category Find(Category item)
        {
            return db.Categories.Find(item.Id);
        }
    }
}
