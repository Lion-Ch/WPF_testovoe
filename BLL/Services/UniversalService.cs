using AutoMapper;
using BLL.Interfaces;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.Services
{
    public class UniversalService<dbType,dtoType,uiType> : BaseService, IDataService<dtoType>
        where dbType: class
        where dtoType: class
        where uiType: class
    {

        private IMapper mapInBase;
        private IMapper mapOutBase;
        private IMapper mapToUI;
        public UniversalService(IUnitOfWork uow) : base(uow)
        {
            mapInBase = new MapperConfiguration(cfg => cfg.CreateMap<dtoType, dbType>()).CreateMapper();
            mapOutBase = new MapperConfiguration(cfg => cfg.CreateMap<dbType, dtoType>()).CreateMapper();
            mapToUI = new MapperConfiguration(cfg => cfg.CreateMap<uiType,dtoType>()).CreateMapper();
        }

        public void Create(dtoType item)
        {
            var ob = mapInBase.Map<dbType>(item);
            Database.Universal<dbType>().Create(ob);
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<dtoType> GetAll()
        {
            //var mapper = new MapperConfiguration(cfg => cfg.CreateMap<dbType, dtoType>()).CreateMapper();
            return mapOutBase.Map<IEnumerable<dbType>, List<dtoType>>(Database.Universal<dbType>().GetAll());
        }

        public void Save()
        {
            Database.Save();
        }

        public void Update(dtoType item)
        {
            var ob = mapInBase.Map<dbType>(item);
            Database.Universal<dbType>().Update(ob);
        }
    }
}
