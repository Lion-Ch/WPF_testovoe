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
    public class EmployeeService: BaseService<Employee,EmployeeDTO>, IDataService<EmployeeDTO>
    {
        public EmployeeService(IRepository<Employee> rep) : base(rep)
        {
        }
        //public void CreateRange(IEnumerable<EmployeeDTO> list)
        //{
        //    Repository.CreateRange(mapper.Map<IEnumerable<Employee>>(list));
        //}
        //public void UpdateRange(IEnumerable<EmployeeDTO> list)
        //{
        //    Repository.UpdateRange(mapper.Map<IEnumerable<Employee>>(list));
        //}
        //public void DeleteRange(IEnumerable<EmployeeDTO> list)
        //{
        //    Repository.DeleteRange(mapper.Map<IEnumerable<Employee>>(list));
        //}
        //public IEnumerable<EmployeeDTO> GetAll()
        //{
        //    return mapper.Map<IEnumerable<Employee>, List<EmployeeDTO>>(Repository.GetAll());
        //}
    }
}
