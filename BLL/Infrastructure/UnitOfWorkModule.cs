using DAL.EF;
using DAL.Interfaces;
using Ninject.Modules;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.Infrastructure
{
    public class UnitOfWorkModule : NinjectModule
    {
        private string connectionString;
        public UnitOfWorkModule(string connection)
        {
            connectionString = connection;
        }
        public override void Load()
        {
            //Bind<IUnitOfWork>().To<EFUnitOfWork>().WithConstructorArgument(connectionString);
        }
    }
}
