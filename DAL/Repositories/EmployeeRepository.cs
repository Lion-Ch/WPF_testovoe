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
    public class EmployeeRepository: BaseRepository, IRepository<Employee>
    {
        public IEnumerable<Employee> GetAll()
        {
            return db.Employees;
        }
        public void CreateRange(IEnumerable<Employee> list)
        {
            db.Employees.AddRange(list);
        }
        public void UpdateRange(IEnumerable<Employee> list)
        {
            foreach (Employee ob in list)
            {
                Employee original = db.Employees.Find(ob.Id);

                if (original != null)
                {
                    db.Entry(original).CurrentValues.SetValues(ob);
                }
            }
        }
        public void DeleteRange(IEnumerable<Employee> list)
        {
            foreach (Employee ob in list)
            {
                Employee a = db.Employees.Find(ob.Id);

                if (a != null)
                    db.Employees.Remove(a);
            }
        }
    }
}
