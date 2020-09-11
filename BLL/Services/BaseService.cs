using AutoMapper;
using BLL.Interfaces;
using DAL.EF;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.Services
{
    public class BaseService<dbType,dtoType>: IDataService<dtoType>, IMapped<dbType,dtoType>, IDisposable
    {
        protected IRepository<dbType> Repository { get; set; }
        protected IMapper mapper { get; set; }

        public BaseService(IRepository<dbType> repository)
        {
            Repository = repository;
            mapper = CreateMap();
        }

        public virtual void CreateRange(IEnumerable<dtoType> list)
        {
            Repository.CreateRange(mapper.Map<IEnumerable<dbType>>(list));
        }
        public virtual void UpdateRange(IEnumerable<dtoType> list)
        {
            Repository.UpdateRange(mapper.Map<IEnumerable<dbType>>(list));
        }
        public virtual void DeleteRange(IEnumerable<dtoType> list)
        {
            Repository.DeleteRange(mapper.Map<IEnumerable<dbType>>(list));
        }
        public virtual IEnumerable<dtoType> GetAll()
        {
            return mapper.Map<IEnumerable<dbType>, List<dtoType>>(Repository.GetAll());
        }
        public void Save()
        {
            Repository.Save();
        }

        public virtual IMapper CreateMap()
        {
            return new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<dbType, dtoType>();
                cfg.CreateMap<dtoType, dbType>();
            }
            ).CreateMapper();
        }
        public virtual IEnumerable<dbType> OutMap(IEnumerable<dtoType> list)
        {
            return mapper.Map<IEnumerable<dbType>>(list);
        }
        public virtual IEnumerable<dtoType> InMap(IEnumerable<dbType> list)
        {
            return mapper.Map<IEnumerable<dtoType>>(list);
        }

        public void Dispose()
        {
            Repository.Dispose();
        }
    }
}
