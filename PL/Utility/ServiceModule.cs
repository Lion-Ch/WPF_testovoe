using BLL.DTO;
using BLL.Interfaces;
using BLL.Services;
using Ninject.Modules;
using System;
using System.Collections.Generic;
using System.Text;

namespace PL.Utility
{
    public class ServiceModule : NinjectModule
    {
        public override void Load()
        {
            //Bind<IDataService<CategoryDTO>>().To<CategoryService>();
            //Bind<IDataService<EmployeeDTO>>().To<EmployeeService>();
            //Bind<IDataService<ProductDTO>>().To<ProductService>();
            //Bind<IDataService<SaleDTO>>().To<SaleService>();
        }
    }
}
