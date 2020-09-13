using BLL.DTO;
using BLL.Interfaces;
using BLL.Services;
using DAL.Entities;
using DAL.Repositories;
using PL.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace PL.ViewModels
{
    public sealed class CategoriesViewModel: BaseDataPageViewModel<CategoryModel, CategoryDTO,Category,CategoryService>
    {
    }
}
