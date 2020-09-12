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
    public class SaleViewModel:BaseDataPageViewModel<SaleModel,SaleDTO,Sale,SaleService>
    {
        public ObservableCollection<ProductModel> Products { get; set; }
        public ObservableCollection<EmployeeModel> Employees { get; set; }

        public SaleViewModel()
        {
            using (ProductService prodServ = new ProductService())
            {
                Products = mapper.Map<ObservableCollection<ProductModel>>(prodServ.GetAll());
            }
            using(EmployeeService empServ = new EmployeeService())
            {
                Employees = mapper.Map<ObservableCollection<EmployeeModel>>(empServ.GetAll());
            }
        }

        public override IMapper CreateMap()
        {
            return new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<ProductModel, ProductDTO>();
                cfg.CreateMap<ProductDTO, ProductModel>();
                cfg.CreateMap<EmployeeDTO, EmployeeModel>();
                cfg.CreateMap<EmployeeModel, EmployeeDTO>();
                cfg.CreateMap<SaleDTO, SaleModel>();
                cfg.CreateMap<SaleModel, SaleDTO>();
            }).CreateMapper();
        }
    }
}
