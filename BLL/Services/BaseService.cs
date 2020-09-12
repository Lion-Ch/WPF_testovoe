using AutoMapper;
using BLL.Interfaces;
using BLL.Responses;
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

        public virtual IEnumerable<dtoType> GetAll()
        {
            return InMap(Repository.GetAll());
        }
        public virtual Response CreateRange(IEnumerable<dtoType> list)
        {
            try
            {
                Repository.CreateRange(OutMap(list));
                return new Response("Данные успешно добавлены", TypeRespone.OK);
            }
            catch(Exception ex)
            {
                return new Response(ex.ToString(), TypeRespone.ERROR);
            }
        }
        public virtual Response UpdateRange(IEnumerable<dtoType> list)
        {
            try
            {
                Repository.UpdateRange(OutMap(list));
                return new Response("Данны успешно изменены", TypeRespone.OK);
            }
            catch (Exception ex)
            {
                return new Response(ex.ToString(), TypeRespone.ERROR);
            }
        }
        public virtual Response DeleteRange(IEnumerable<dtoType> list)
        {
            try
            {
                Repository.DeleteRange(OutMap(list));
                return new Response("Данные успешно удалены", TypeRespone.OK);
            }
            catch (Exception ex)
            {
                return new Response(ex.ToString(), TypeRespone.ERROR);
            }
        }
        public Response Save()
        {
            try
            {
                Repository.Save();
                return new Response("Данные успешно сохранены", TypeRespone.OK);
            }
            catch (Exception ex)
            {
                return new Response(ex.ToString(), TypeRespone.ERROR);
            }
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
