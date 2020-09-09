using AutoMapper;
using BLL.DTO;
using BLL.Interfaces;
using DAL.Entities;
using DAL.Interfaces;
using System.Collections.Generic;

namespace BLL.Services
{
    public class CategoryService : BaseService, IDataService<CategoryDTO>
    {
        public CategoryService(IUnitOfWork uow):base(uow)
        {
        }

        public void Create(CategoryDTO categoryDTO)
        {
            Category category = new Category
            {
                Name = categoryDTO.Name
            };
            Database.Categories.Create(category);
        }

        public void Update(CategoryDTO categoryDTO)
        {
            Database.Categories.Update(new Category
            {
                Id = categoryDTO.Id,
                Name = categoryDTO.Name
            }
            );
        }

        public void Delete(int id)
        {
            Database.Categories.Delete(id);
        }

        public IEnumerable<CategoryDTO> GetAll()
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<Category, CategoryDTO>()).CreateMapper();
            return mapper.Map<IEnumerable<Category>, List<CategoryDTO>>(Database.Categories.GetAll());
        }
    }
}
