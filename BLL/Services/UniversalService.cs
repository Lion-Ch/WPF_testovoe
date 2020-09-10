using AutoMapper;
using BLL.Interfaces;
using DAL.Entities;
using DAL.Interfaces;
using DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.Services
{
    public class UniversalService<dbType,dtoType> : IDataService<dtoType>, IDisposable
        where dbType: BaseEntity
        where dtoType: class
    {
        private IRepository<dbType> repository;
        private IMapper mapper;

        public UniversalService()
        {
            repository = new UniversalRepository<dbType>();
            mapper = CreateMap();
        }
        public virtual IMapper CreateMap()
        {
            return new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<dtoType, dbType>();
                cfg.CreateMap<dbType, dtoType>();
            }).CreateMapper();
        }

        public virtual void CreateRange(IEnumerable<dtoType> list)
        {
            repository.CreateRange(mapper.Map<IEnumerable<dbType>>(list));
        }
        public virtual void Create(dtoType item)
        {
            dbType ob = mapper.Map<dbType>(item);
            repository.Create(ob);
        }

        public virtual void Update(dtoType item)
        {
            dbType ob = mapper.Map<dbType>(item);
            repository.Update(ob);
        }

        public virtual void Delete(dtoType item)
        {
            dbType ob = mapper.Map<dbType>(item);
            repository.Delete(ob);
        }

        public void Save()
        {
            repository.Save();
        }

        public virtual IEnumerable<dtoType> GetAll()
        {
            return mapper.Map<IEnumerable<dbType>, List<dtoType>>(repository.GetAll());
        }

        private bool disposed = false;
        public virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    repository.Dispose();
                }
            }
            this.disposed = true;
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
