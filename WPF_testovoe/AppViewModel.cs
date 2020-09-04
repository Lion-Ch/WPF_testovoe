using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using WPF_testovoe.Entity.Context;
using WPF_testovoe.Entity.Model;
using WPF_testovoe.Notifications;
using WPF_testovoe.Utilty;
using WPF_testovoe.ViewModels;

namespace WPF_testovoe
{
    public class AppViewModel : ObservableObject
    {
        private ShopContext db;
        private INotification notification;

        private IViewModel _currentView;
        public IViewModel CurrentView
        {
            get { return _currentView; }
            set { OnPropertyChanged(ref _currentView, value); }
        }

        public ICommand LoadCategoriesPageCommand { get; private set; }
        public ICommand LoadEmployeePageCommand { get; private set; }

        public AppViewModel()
        {
            db = new ShopContext();
            notification = new BaseNotification();

            LoadCategoriesPageCommand = new RelayCommand(LoadCategoriesPage);
            LoadEmployeePageCommand   = new RelayCommand(LoadEmployeePage);
        }
        public void LoadEmployeePage()
        {
            CurrentView = new EmployeesViewModel(db, notification);
        }
        public void LoadCategoriesPage()
        {
            CurrentView = new CategoriesViewModel(db, notification);
        }
    }
}
