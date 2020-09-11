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
using System.Text;

namespace PL.ViewModels
{
    public class ProductsViewModel : BaseDataPageViewModel<ProductModel, ProductDTO>
    {
        private ObservableCollection<CategoryModel> _categories;
        public ObservableCollection<CategoryModel> Categories
        {
            get { return _categories; }
            set { OnPropertyChanged(ref _categories, value); }
        }
        private UniversalService<Category, CategoryDTO> CategoryService;
        public ProductsViewModel() 
            : base(new UniversalService<Product,ProductDTO>(new EFUnitOfWork()))
        {
            CategoryService = new UniversalService<Category, CategoryDTO>(new EFUnitOfWork());
            Categories = mapper.Map<IEnumerable<CategoryDTO>,ObservableCollection<CategoryModel>>(CategoryService.GetAll());
        }
        public override IMapper CreateMap()
        {
            return new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<ProductModel, ProductDTO>();
                cfg.CreateMap<ProductDTO, ProductModel>();
                cfg.CreateMap<CategoryModel, CategoryDTO>();
                cfg.CreateMap<CategoryDTO, CategoryModel>();
            }).CreateMapper();
        }
    }
}
