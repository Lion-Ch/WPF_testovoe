using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Input;
using WPF_testovoe.Entity.Context;
using WPF_testovoe.Entity.Model;
using WPF_testovoe.Notifications;
using WPF_testovoe.Utilty;
using WPF_testovoe.Validator;
using WPF_testovoe.ViewModels;

namespace WPF_testovoe
{
    public class AppViewModel : ObservableObject
    {
        #region Поля
        private ShopContext   db;
        private INotification notification;
        private IValidator    validator;
        private IViewModel[]  appPages;
        #endregion

        #region Текущая View
        private IViewModel _currentView;
        public IViewModel CurrentView
        {
            get { return _currentView; }
            set { OnPropertyChanged(ref _currentView, value); }
        }
        #endregion

        #region Комманды
        public ICommand LoadCategoriesPageCommand { get; private set; }
        public ICommand LoadEmployeePageCommand   { get; private set; }
        public ICommand LoadProductPageCommand    { get; private set; }
        public ICommand LoadSalePageCommand       { get; private set; }
        #endregion

        #region Конструктор
        public AppViewModel()
        {
            db           = new ShopContext();
            notification = new BaseNotification();
            validator    = new BaseValidator();

            LoadCategoriesPageCommand = new RelayCommand(LoadCategoriesPage);
            LoadEmployeePageCommand   = new RelayCommand(LoadEmployeePage);
            LoadProductPageCommand    = new RelayCommand(LoadProductPage);
            LoadSalePageCommand       = new RelayCommand(LoadSalePage);
        }
        #endregion

        #region Реализация комманд
        public void LoadEmployeePage()
        {
            CurrentView = new EmployeesViewModel(db, validator, notification);
        }
        public void LoadCategoriesPage()
        {
            CurrentView = new CategoriesViewModel(db, validator, notification);
        }
        public void LoadProductPage()
        {
            CurrentView = new ProductsViewModel(db, validator, notification);
        }
        public void LoadSalePage()
        {
            CurrentView = new SalesViewModel(db, validator, notification);
        }
        #endregion
    }
}
