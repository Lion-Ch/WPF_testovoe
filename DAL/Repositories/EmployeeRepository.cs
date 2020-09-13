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
    public sealed class EmployeeRepository: BaseRepository<Employee>
    {
        public override Employee Get(int id)
        {
            return db.Employees.Find(id);
        }
        public override Employee Find(Employee item)
        {
            return db.Employees.Find(item.Id);
        }
    }
}
