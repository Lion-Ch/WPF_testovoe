using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Entities
{
    public sealed class Sale 
    {
        public int Amount { get; set; }

        public int ProductId { get; set; }
        public Product Product { get; set; }
        public int EmployeeId{ get; set; }
        public Employee Employee { get; set; }
    }
}
