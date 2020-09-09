using AutoMapper;
using DAL.EF;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.Services
{
    public class BaseService
    {
        protected IUnitOfWork Database { get; set; }
        public BaseService(IUnitOfWork database)
        {
            Database = database;
        }

        public void Dispose()
        {
            Database.Dispose();
        }
    }
}
