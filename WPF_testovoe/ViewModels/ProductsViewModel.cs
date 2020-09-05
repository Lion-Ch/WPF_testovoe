using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using WPF_testovoe.Entity.Context;
using WPF_testovoe.Entity.Model;
using WPF_testovoe.Notifications;
using WPF_testovoe.Validator;

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
        public ProductsViewModel(ShopContext shopContext,IValidator v, INotification notification)
            : base(shopContext,v)
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
                ListDeletedRecords.Add(SelectedRecord);
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
            ListNewRecords.Add(NewRecord);
            Records.Add(NewRecord);
            NewRecord = new Product();

            Notification.SetData(Properties.Resources.AddNewRecordSuccessfully, "Green");
        }
        public override void LoadPage()
        {
            Categories = db.Categories.ToList();
            Records = new ObservableCollection<Product>(db.Products.Include(p=>p.Category).ToList());
        }
        public override void SaveAllRecords()
        {
            db.Products.AddRange(ListNewRecords);
            db.Products.RemoveRange(ListDeletedRecords);
            db.SaveChanges();

            Notification.SetData(Properties.Resources.AllRecordsSavedSuccessfully, "Green");
        }
        #endregion
    }
}
