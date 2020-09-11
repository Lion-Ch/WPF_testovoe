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
    public class CategoriesViewModel: BaseDataPageViewModel<CategoryModel, CategoryDTO>
    {
        public CategoriesViewModel()
            :base(new UniversalService<Category, CategoryDTO>(new EFUnitOfWork()))
        {
        }
    }
}
