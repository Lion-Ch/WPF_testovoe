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
    public class SalesViewModel : BaseDataPageViewModel<Sale>, INotificationPageService, IDataValidateService, IViewModel
    {
        #region Свойства
        public IValidator Validator { get; set; }
        public INotification Notification { get; set; }

        public List<Employee> Employees { get; set; }
        public List<Product>  Products { get; set; }
        public Product SelectedProduct
        {
            get { return NewRecord.Product; }
            set { NewRecord.Product = value; }
        }
        public Employee SelectedEmployee
        {
            get { return NewRecord.Employee; }
            set { NewRecord.Employee = value; }
        }
        #endregion

        #region Конструктор
        public SalesViewModel(ShopContext shopContext, IValidator validator, INotification notification)
            : base(shopContext)
        {
            Validator = validator;
            Notification = notification;
            NewRecord = new Sale();
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
            if (CanAddRecord())
            {
                if (!Validator.IsValid(NewRecord))
                {
                    Notification.SetData(Validator.ErrorText, "Red");
                    return;
                }

                AddNewRecordPreProcess();
                ListNewRecords.Add(NewRecord);
                Records.Add(NewRecord);
                NewRecord = new Sale();

                Notification.SetData(Properties.Resources.AddNewRecordSuccessfully, "Green");
            }
        }
        public override void LoadRecords()
        {
            Employees = db.Employees.ToList();
            Products = db.Products.ToList();
            Records = new ObservableCollection<Sale>(db.Sales.Include(s=>s.Employee).Include(s=>s.Product).ToList());
        }
        public override void SaveAllRecords()
        {
            db.Sales.AddRange(ListNewRecords);
            db.Sales.RemoveRange(ListDeletedRecords);

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
        public override bool CanAddRecord()
        {
            if (db.Sales.Where(s => s.EmployeeId == NewRecord.Employee.Id && s.ProductId == NewRecord.Product.Id).Count() == 0)
            {
                if (NewRecord.Product.Amount >= NewRecord.Amount + NewRecord.Product.Sales.Sum(s=>s.Amount))
                {
                    return true;
                }
                else
                {
                    Notification.SetData(Properties.Resources.NotHaveProduct, "Red");
                    return false;
                }
            }
            else
            {
                Notification.SetData(Properties.Resources.HaveRecordInBase, "Red");
                return false;
            }
        }
        public override void AddNewRecordPreProcess()
        {
            NewRecord.Product.Amount -= NewRecord.Amount;
        }
        #endregion
    }
}
