using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;
using WPF_testovoe.Entity.Context;
using WPF_testovoe.Entity.Model;
using WPF_testovoe.Utilty;

namespace WPF_testovoe.ViewModels
{
    public class CategoriesViewModel: ObservableObject, IViewModel
    {
        private ShopContext db;

        #region Свойства
        private Category _selectedRecord;
        public Category SelectedRecord
        {
            get { return _selectedRecord; }
            set 
            { 
                OnPropertyChanged(ref _selectedRecord, value); 
            }
        }
        private Category _newCategory;
        public Category NewCategory
        {
            get { return _newCategory; }
            set { OnPropertyChanged(ref _newCategory, value); }
        }
        private ObservableCollection<Category> _categories;
        public ObservableCollection<Category> Categories
        {
            get { return _categories; }
            set
            {
                OnPropertyChanged(ref _categories, value);
            }
        }
        private string _notification;
        public string Notification
        {
            get { return _notification; }
            set { OnPropertyChanged(ref _notification, value); }
        }
        #endregion
        #region Команды
        public ICommand AddNewRecordCommand { get; private set; }
        public ICommand DeleteRecordCommand { get; private set; }
        #endregion

        public CategoriesViewModel(ShopContext shopContext)
        {
            db =shopContext;
            NewCategory = new Category { Name = "" };
            SelectedRecord = null;
            LoadRecords();

            AddNewRecordCommand = new RelayCommand(AddNewRecord);
        }

        private void DeleteRecord()
        {
            if(SelectedRecord != null)
                db.Categories.Remove(SelectedRecord);
        }
        private void LoadRecords()
        {
            Categories = new ObservableCollection<Category>(db.Categories.ToList());
            OnPropertyChanged("Categories");
        }
        private void AddNewRecord()
        {
            if (String.IsNullOrEmpty(NewCategory.Name))
                Notification = Properties.Resources.AddNewRecordError;

            Categories.Add(NewCategory);
            db.Categories.Add(NewCategory);
            NewCategory = new Category { Name = "" };
        }
    }
}
