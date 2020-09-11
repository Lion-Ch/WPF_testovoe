using AutoMapper;
using BLL.Interfaces;
using BLL.Responses;
using DAL.EF;
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

        public UniversalService(EFUnitOfWork uow)
        {
            repository = uow.GetRepository<dbType>();
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

        public virtual IResponse Create(dtoType item)
        {
            try
            {
                dbType ob = mapper.Map<dbType>(item);
                repository.Create(ob);
                return new Response("Данные успешно добавлены", StatusResponse.OK);
            }
            catch(Exception ex)
            {
                return new Response(ex.ToString(), StatusResponse.ERROR);
            }
        }
        public virtual IResponse Update(dtoType item)
        {
            try
            {
                dbType ob = mapper.Map<dbType>(item);
                repository.Update(ob);
                return new Response("Данные успешно обновлены", StatusResponse.OK);
            }
            catch(Exception ex)
            {
                return new Response(ex.ToString(), StatusResponse.ERROR);
            }
        }
        public virtual IResponse Delete(dtoType item)
        {
            try
            {
                dbType ob = mapper.Map<dbType>(item);
                repository.Delete(ob);
                return new Response("Данные успешно удалены", StatusResponse.OK);
            }
            catch (Exception ex)
            {
                return new Response(ex.ToString(), StatusResponse.ERROR);
            }
        }
        public virtual IResponse CreateRange(IEnumerable<dtoType> list)
        {
            try
            {
                repository.CreateRange(mapper.Map<IEnumerable<dbType>>(list));
                return new Response("Данные успешно добавлены", StatusResponse.OK);
            }
            catch (Exception ex)
            {
                return new Response(ex.ToString(), StatusResponse.ERROR);
            }
        }
        public IResponse UpdateRange(IEnumerable<dtoType> list)
        {
            try
            {
                repository.UpdateRange(mapper.Map<IEnumerable<dbType>>(list));
                return new Response("Данные успешно обновлены", StatusResponse.OK);
            }
            catch (Exception ex)
            {
                return new Response(ex.ToString(), StatusResponse.ERROR);
            }
        }

        public IResponse DeleteRange(IEnumerable<dtoType> list)
        {
            try
            {
                repository.DeleteRange(mapper.Map<IEnumerable<dbType>>(list));
                return new Response("Данные успешно удалены", StatusResponse.OK);
            }
            catch (Exception ex)
            {
                return new Response(ex.ToString(), StatusResponse.ERROR);
            }
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
