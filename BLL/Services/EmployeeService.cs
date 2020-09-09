using AutoMapper;
using BLL.DTO;
using BLL.Interfaces;
using DAL.Entities;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.Services
{
    public class EmployeeService: BaseService, IDataService<EmployeeDTO>
    {
        public EmployeeService(IUnitOfWork uow) : base(uow)
        {
        }

        public void Create(EmployeeDTO employeeDTO)
        {
            Employee product = new Employee
            {
                FullName = employeeDTO.FullName
            };
            Database.Employees.Create(product);
        }

        public void Update(EmployeeDTO employeeDTO)
        {
            Database.Employees.Update(new Employee
            {
                Id = employeeDTO.Id,
                FullName = employeeDTO.FullName
            }
            );
        }

        public void Delete(int id)
        {
            Database.Categories.Delete(id);
        }

        public IEnumerable<EmployeeDTO> GetAll()
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<Employee, EmployeeDTO>()).CreateMapper();
            return mapper.Map<IEnumerable<Employee>, List<EmployeeDTO>>(Database.Employees.GetAll());
        }
    }
}
