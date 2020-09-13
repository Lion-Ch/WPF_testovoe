using AutoMapper;
using BLL.DTO;
using BLL.Services;
using DAL.Entities;
using PL.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace PL.ViewModels
{
    public class ProductViewModel: BaseDataPageViewModel<ProductModel,ProductDTO,Product,ProductService>
    {
        public ObservableCollection<CategoryModel> Categories { get; set; }

        public ProductViewModel()
        {
            using(CategoryService categoryServ = new CategoryService())
            {
                Categories = mapper.Map<ObservableCollection<CategoryModel>>(categoryServ.GetAll());
            }
        }

        public override IMapper CreateMap()
        {
            return new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<CategoryModel, CategoryDTO>();
                cfg.CreateMap<CategoryDTO, CategoryModel>();
                cfg.CreateMap<ProductModel, ProductDTO>();
                cfg.CreateMap<ProductDTO, ProductModel>();
            }).CreateMapper();
        }
    }
}
