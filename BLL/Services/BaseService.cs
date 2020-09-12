using AutoMapper;
using BLL.Interfaces;
using BLL.Responses;
using BLL.Validation;
using DAL.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace BLL.Services
{
    public class BaseService<dbType,dtoType>: IDataService<dtoType>, IMapped<dbType,dtoType>, IDisposable
        where dtoType: IValidatable
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
        public virtual dtoType Get(int id)
        {
            return mapper.Map<dtoType>(Repository.Get(id));
        }
        public virtual Response CreateRange(IEnumerable<dtoType> list)
        {
            Response res = IsValidRange(list);
            if(res.Status == TypeRespone.OK)
            {
                try
                {
                    Repository.CreateRange(OutMap(list));
                    return new Response("Данные успешно добавлены", TypeRespone.OK);
                }
                catch (Exception ex)
                {
                    return new Response(ex.ToString(), TypeRespone.ERROR);
                }
            }

            return res;
        }
        public virtual Response UpdateRange(IEnumerable<dtoType> list)
        {
            Response res = IsValidRange(list);
            if (res.Status == TypeRespone.OK)
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

            return res;
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
            catch (DbUpdateException ex)
            {
                return new Response(ex.ToString(), TypeRespone.ERROR);
            }
        }
        public virtual Response IsValidRange(IEnumerable<dtoType> list)
        {
            Response res = new Response("", TypeRespone.OK);
            foreach (dtoType c in list)
            {
                res = IsValidObject(c);
                if (res.Status != TypeRespone.OK)
                    return res;
            }
            return res;
        }
        public virtual Response IsValidObject(dtoType item)
        {
            string errorText = "";
            if (!item.IsValid(ref errorText))
            {
                return new Response(errorText, TypeRespone.WARNING);
            }
            else
                return new Response("", TypeRespone.OK);
        }

        public virtual Response PreparationRange(IEnumerable<dtoType> list)
        {

            Response res = new Response("", TypeRespone.OK);
            foreach (dtoType ob in list)
            {
                res = PreparationObject(ob);
                if (res.Status != TypeRespone.OK)
                    return res;
            }
            return res;
        }

        public virtual Response PreparationObject(dtoType item)
        {
            return new Response("", TypeRespone.OK);
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
