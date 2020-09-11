using AutoMapper;
using BLL.DTO;
using BLL.Interfaces;
using BLL.Services;
using DAL.EF;
using DAL.Entities;
using PL.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

namespace PL.ViewModels
{
    public class ProductsViewModel : BaseDataPageViewModel<ProductModel, ProductDTO, Product>
    {
        private List<CategoryModel> Categories;
        public ProductsViewModel() 
        {
        }
        public override void LoadRecords()
        {
            base.LoadRecords();
            using(UniversalService<Category, CategoryDTO> CategoryService = new UniversalService<Category, CategoryDTO>())
            {
                Categories = mapper.Map<IEnumerable<CategoryDTO>, List<CategoryModel>>(CategoryService.GetAll());
                foreach (ProductModel p in Records)
                    p.Category = Categories.Where(x => x.Id == p.CategoryId).FirstOrDefault();
            }
        }
        public override IMapper CreateMap()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<ProductModel, ProductDTO>()
                .ForMember(x => x.CategoryId, src => src.MapFrom(y => y.Category.Id));
                cfg.CreateMap<ProductDTO, ProductModel>()
                .ForMember(x => x.CategoryId, src => src.MapFrom(y => y.CategoryId));
                cfg.CreateMap<CategoryModel, CategoryDTO>();
                cfg.CreateMap<CategoryDTO, CategoryModel>();
            });
            return config.CreateMapper();
        }
    }
}

