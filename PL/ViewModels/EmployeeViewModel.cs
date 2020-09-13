using BLL.DTO;
using BLL.Services;
using DAL.Entities;
using PL.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace PL.ViewModels
{
    public sealed class EmployeeViewModel : BaseDataPageViewModel<EmployeeModel, EmployeeDTO, Employee, EmployeeService>
    {
    }
}
