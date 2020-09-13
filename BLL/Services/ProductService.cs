using AutoMapper;
using BLL.DTO;
using BLL.Interfaces;
using BLL.Responses;
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
    }
}
