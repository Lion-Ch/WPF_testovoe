using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using WPF_testovoe.Entity.Context;
using WPF_testovoe.Entity.Model;
using WPF_testovoe.Notifications;

namespace WPF_testovoe.ViewModels
{
    public class ProductsViewModel : BaseDataPageViewModel<Product>, INotificationPageService, IViewModel
    {
        public List<Category> Categories { get; set; }
        #region Свойства
        public Category SelectedCategory
        {
            get { return NewRecord.Category; }
            set { NewRecord.Category = value;  }
        }
        private INotification _notification;
        public INotification Notification
        {
            get { return _notification; }
            set { OnPropertyChanged(ref _notification, value); }
        }
        #endregion

        #region Конструктор
        public ProductsViewModel(ShopContext shopContext, INotification notification)
            : base(shopContext)
        {
            Notification = notification;
            NewRecord = new Product();
        }
        #endregion

        #region DataService
        public override void DeleteRecord()
        {
            if (SelectedRecord != null)
            {
                db.Products.Remove(SelectedRecord);
                Records.Remove(SelectedRecord);
                Notification.SetData(Properties.Resources.DeleteRecordSuccessfully, "Green");
            }
            else
                Notification.SetData(Properties.Resources.RecordSelectedError, "Red");
        }
        public override void AddNewRecord()
        {
            if (String.IsNullOrEmpty(NewRecord.Name))
            {
                Notification.SetData(Properties.Resources.AddNewRecordError, "Red");
                return;
            }
            Records.Add(NewRecord);
            db.Products.Add(NewRecord);
            NewRecord = new Product();
            Notification.SetData(Properties.Resources.AddNewRecordSuccessfully, "Green");
        }
        public override void LoadPage()
        {
            Categories = db.Categories.ToList();
            Records = new ObservableCollection<Product>(db.Products.Include(p=>p.Category).ToList());
            OnPropertyChanged("Categories");
        }
        public override void SaveAllRecords()
        {
            db.SaveChanges();
            Notification.SetData(Properties.Resources.AllRecordsSavedSuccessfully, "Green");
        }
        #endregion
    }
}
