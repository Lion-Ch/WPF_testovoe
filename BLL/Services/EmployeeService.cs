using AutoMapper;
using BLL.DTO;
using BLL.Interfaces;
using DAL.Entities;
using DAL.Interfaces;
using DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.Services
{
    public sealed class EmployeeService: BaseService<Employee,EmployeeDTO>/*, IDataService<EmployeeDTO>*/
    {
        public EmployeeService() : base(new EmployeeRepository())
        {
        }
    }
}
