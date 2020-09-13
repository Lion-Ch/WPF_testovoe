using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Entities
{
    public sealed class Employee
    {
        public int Id { get; set; }
        public string FullName { get; set; }

        public IEnumerable<Sale> Sales { get; set; }

        public Employee()
        {
            Sales = new List<Sale>();
        }
    }
}
