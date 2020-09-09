using AutoMapper;
using BLL.DTO;
using BLL.Interfaces;
using DAL.Entities;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.Services
{
    public class CategoryService : IDataService<CategoryDTO>
    {

        IUnitOfWork Database { get; set; }

        public CategoryService(IUnitOfWork uow)
        {
            Database = uow;
        }

        public void Create(CategoryDTO categoryDTO)
        {
            Category category = new Category
            {
                Name = categoryDTO.Name
            };
            Database.Categories.Create(category);
            Database.Save();
        }

        public void Delete(int id)
        {
            Database.Categories.Delete(id);
            Database.Save();
        }

        public IEnumerable<CategoryDTO> GetAll()
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<Category, CategoryDTO>()).CreateMapper();
            return mapper.Map<IEnumerable<Category>, List<CategoryDTO>>(Database.Categories.GetAll());
        }

        public void Update(CategoryDTO categoryDTO)
        {
            Database.Categories.Update(new Category { Name = categoryDTO.Name });
        }

        public void Dispose()
        {
            Database.Dispose();
        }
    }
}
