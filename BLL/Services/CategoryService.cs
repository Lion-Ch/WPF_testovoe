using AutoMapper;
using BLL.DTO;
using BLL.Interfaces;
using DAL.Entities;
using DAL.Interfaces;
using DAL.Repositories;
using System.Collections.Generic;

namespace BLL.Services
{
    public class CategoryService : BaseService<Category,CategoryDTO>
    {
        public CategoryService():base(new CategoryRepository())
        {
        }
    }
}
