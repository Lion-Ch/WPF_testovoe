using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Entities
{
    public sealed class Product 
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Amount { get; set; }

        public int CategoryId { get; set; }
        public Category Category { get; set; }

        public IEnumerable<Sale> Sales { get; set; }

        public Product()
        {
            Sales = new List<Sale>();
        }
    }
}
