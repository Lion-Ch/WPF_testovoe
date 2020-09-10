using BLL.DTO;
using BLL.Interfaces;
using BLL.Services;
using DAL.Entities;
using PL.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace PL.ViewModels
{
    public class ProductsViewModel : BaseDataPageViewModel<ProductModel, ProductDTO>
    {
        public ProductsViewModel() 
            : base(new UniversalService<Product,ProductDTO>())
        {
        }
    }
}
