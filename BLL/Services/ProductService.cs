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
    public class ProductService : BaseService, IDataService<ProductDTO>
    {
        public ProductService(IUnitOfWork uow) : base(uow)
        {
        }

        public void Create(ProductDTO productDTO)
        {
            Product product = new Product
            {
                Name = productDTO.Name,
                Amount = productDTO.Amount,
                CategoryId = productDTO.CategoryId
            };
            Database.Products.Create(product);
        }

        public void Update(ProductDTO productDTO)
        {
            Database.Products.Update(new Product
            {
                Id = productDTO.Id,
                Name = productDTO.Name,
                Amount = productDTO.Amount,
                CategoryId = productDTO.CategoryId
            }
            );
        }

        public void Delete(int id)
        {
            Database.Categories.Delete(id);
        }

        public IEnumerable<ProductDTO> GetAll()
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<Product, ProductDTO>()).CreateMapper();
            return mapper.Map<IEnumerable<Product>, List<ProductDTO>>(Database.Products.GetAll());
        }
    }
}
