using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Entities
{
    public class Category: BaseEntity
    {
        public override int Id { get; set; }
        public string Name { get; set; }

        public List<Product> Products { get; set; }

        public Category()
        {
            Products = new List<Product>();
        }
    }
}
