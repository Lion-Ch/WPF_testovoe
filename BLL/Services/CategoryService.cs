using AutoMapper;
using BLL.DTO;
using BLL.Interfaces;
using BLL.Responses;
using DAL.Entities;
using DAL.Interfaces;
using DAL.Repositories;
using System.Collections.Generic;

namespace BLL.Services
{
    public sealed class CategoryService : BaseService<Category,CategoryDTO>
    {
        public CategoryService():base(new CategoryRepository())
        {
        }
    }
}
