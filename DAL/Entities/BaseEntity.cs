using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Entities
{
    public abstract class BaseEntity
    {
        public virtual int Id { get; set; }
    }
}
