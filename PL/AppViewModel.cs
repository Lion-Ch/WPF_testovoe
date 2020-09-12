using BLL.DTO;
using BLL.Interfaces;
using BLL.Services;
using DAL.EF;
using DAL.Entities;
using DAL.Repositories;
using Ninject;
using PL.Models;
using PL.Utility;
using PL.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace PL
{
    public class AppViewModel: ObservableObject
    {
        #region Текущая View
        private object _currentView;
        public object CurrentView
        {
            get { return _currentView; }
            set { OnPropertyChanged(ref _currentView, value); }
        }
        #endregion

        #region Комманды
        public ICommand LoadCategoriesPageCommand { get; private set; }
        public ICommand LoadEmployeePageCommand { get; private set; }
        public ICommand LoadProductPageCommand { get; private set; }
        public ICommand LoadSalePageCommand { get; private set; }
        #endregion
        public AppViewModel()
        {
            CurrentView = new CategoriesViewModel();
            LoadCategoriesPageCommand = new RelayCommand(LoadCategoriesPage);
            LoadProductPageCommand = new RelayCommand(LoadProductPage);
            LoadEmployeePageCommand = new RelayCommand(LoadEmployeePage);
            LoadSalePageCommand = new RelayCommand(LoadSalePage);
        }
        #region Реализация комманд
        public void LoadEmployeePage()
        {
            CurrentView = new EmployeeViewModel();
        }
        public void LoadCategoriesPage()
        {
            CurrentView = new CategoriesViewModel();
        }
        public void LoadProductPage()
        {
            CurrentView = new ProductViewModel();
        }
        public void LoadSalePage()
        {
            CurrentView = new SaleViewModel();
        }
        #endregion
    }
}
