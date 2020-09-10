using BLL.DTO;
using BLL.Interfaces;
using BLL.Services;
using DAL.Entities;
using Ninject.Modules;
using PL.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace PL.Utility
{
    public class ServiceModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IDataService<CategoryDTO>>().To<UniversalService<Category, CategoryDTO, CategoryModel>>();
            //Bind<IDataService<CategoryDTO>>().To<CategoryService>();
            Bind<IDataService<EmployeeDTO>>().To<EmployeeService>();
            Bind<IDataService<ProductDTO>>().To<ProductService>();
            Bind<IDataService<SaleDTO>>().To<SaleService>();
        }
    }
}
