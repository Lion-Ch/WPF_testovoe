using AutoMapper;
using BLL.DTO;
using BLL.Interfaces;
using DAL.Entities;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.Services
{
    public class SaleService : BaseService, IDataService<SaleDTO>
    {
        public SaleService(IUnitOfWork uow) : base(uow)
        {
        }

        public void Create(SaleDTO saleDTO)
        {
            Sale sale = new Sale
            {
                Amount = saleDTO.Amount,
                EmployeeId = saleDTO.EmployeeId,
                ProductId = saleDTO.ProductId
            };
            Database.Sales.Create(sale);
        }

        public void Update(SaleDTO saleDTO)
        {
            Database.Sales.Update(new Sale
            {
                Amount = saleDTO.Amount,
                EmployeeId = saleDTO.EmployeeId,
                ProductId = saleDTO.ProductId
            }
            );
        }

        public void Delete(int id)
        {
            Database.Categories.Delete(id);
        }

        public IEnumerable<SaleDTO> GetAll()
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<Sale, SaleDTO>()).CreateMapper();
            return mapper.Map<IEnumerable<Sale>, List<SaleDTO>>(Database.Sales.GetAll());
        }
    }
}
