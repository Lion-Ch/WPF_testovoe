using AutoMapper;
using BLL.DTO;
using BLL.Interfaces;
using DAL.Entities;
using DAL.Interfaces;
using DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.Services
{
    public class ProductService : BaseService<Product,ProductDTO>
    {
        public ProductService() : base(new ProductRepository())
        {
        }

        public override IMapper CreateMap()
        {
            return new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Category, CategoryDTO>();
                //cfg.CreateMap<CategoryDTO, Category>();
                cfg.CreateMap<Product, ProductDTO>();
                cfg.CreateMap<ProductDTO, Product>();
            }
               ).CreateMapper();
        }
    }
}
