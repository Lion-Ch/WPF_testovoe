using BLL.DTO;
using BLL.Interfaces;
using BLL.Services;
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
        private IDisposable _currentView;
        public IDisposable CurrentView
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

            CurrentView = new ProductsViewModel();
            LoadCategoriesPageCommand = new RelayCommand(LoadCategoriesPage);
            //LoadEmployeePageCommand = new RelayCommand(LoadEmployeePage);
            LoadProductPageCommand = new RelayCommand(LoadProductPage);
            //LoadSalePageCommand = new RelayCommand(LoadSalePage);
        }
        #region Реализация комманд
        //public void LoadEmployeePage()
        //{
        //    CurrentView = new EmployeesViewModel();
        //}
        public void LoadCategoriesPage()
        {
        }
        public void LoadProductPage()
        {
            CurrentView.Dispose();
            CurrentView = new ProductsViewModel();
        }
        //public void LoadSalePage()
        //{
        //    CurrentView = new SalesViewModel();
        //}
        #endregion
    }
}
