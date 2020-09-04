﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using WPF_testovoe.Entity.Context;
using WPF_testovoe.Utilty;
using WPF_testovoe.ViewModels;

namespace WPF_testovoe
{
    public class AppViewModel : ObservableObject
    {
        private ShopContext db;

        private IViewModel _currentView;
        public IViewModel CurrentView
        {
            get { return _currentView; }
            set { OnPropertyChanged(ref _currentView, value); }
        }

        public ICommand LoadCategoriesPageCommand { get; private set; }

        public AppViewModel()
        {
            db = new ShopContext();
            LoadCategoriesPageCommand = new RelayCommand(LoadCategoriesPage);
        }

        public void LoadCategoriesPage()
        {
            CurrentView = new CategoriesViewModel(db);
        }
    }
}