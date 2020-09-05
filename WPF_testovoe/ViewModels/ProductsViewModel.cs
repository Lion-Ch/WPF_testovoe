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
    public class ProductsViewModel : BaseDataPageViewModel<Product>, INotificationPageService, IDataValidateService, IViewModel
    {

        #region Свойства
        public IValidator    Validator { get; set; }
        public INotification Notification { get; set; }

        public List<Category> Categories { get; set; }
        public Category SelectedCategory
        {
            get { return NewRecord.Category; }
            set { NewRecord.Category = value;  }
        }
        #endregion

        #region Конструктор
        public ProductsViewModel(IContext shopContext,IValidator validator, INotification notification)
            : base(shopContext)
        {
            Validator = validator;
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
            if (!Validator.IsValid(NewRecord))
            {
                Notification.SetData(Validator.ErrorText, "Red");
                return;
            }
            ListNewRecords.Add(NewRecord);
            Records.Add(NewRecord);
            NewRecord = new Product();

            Notification.SetData(Properties.Resources.AddNewRecordSuccessfully, "Green");
        }
        public override void LoadRecords()
        {
            Categories = db.Categories.ToList();
            Records = new ObservableCollection<Product>(db.Products.Include(p=>p.Category).ToList());
        }
        public override void SaveAllRecords()
        {
            db.Products.AddRange(ListNewRecords);
            db.Products.RemoveRange(ListDeletedRecords);

            if (Validator.IsValid(ListChangedRecords))
            {
                db.SaveChanges();
                if (ListChangedRecords.Count > 1)
                    ListChangedRecords.RemoveRange(1, ListChangedRecords.Count - 1);
                Notification.SetData(Properties.Resources.AllRecordsSavedSuccessfully, "Green");
            }
            else
            {
                Notification.SetData(Validator.ErrorText, "Red");
            }

            ListNewRecords.Clear();
            ListDeletedRecords.Clear();
        }
        #endregion
    }
}
