using AutoMapper;
using BLL.DTO;
using DAL.EF;
using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.Services
{
    public class ProductService: UniversalService<Product, ProductDTO>
    {
        public ProductService() : base()
        {
        }

        public override IMapper CreateMap()
        {
             return new MapperConfiguration(cfg =>
             {
                 cfg.CreateMap<ProductDTO, Product>();
                 cfg.CreateMap<Product, ProductDTO>();
                 cfg.CreateMap<Category, CategoryDTO>();
                 cfg.CreateMap<CategoryDTO, Category>();
             }).CreateMapper();
        }
    }
}
