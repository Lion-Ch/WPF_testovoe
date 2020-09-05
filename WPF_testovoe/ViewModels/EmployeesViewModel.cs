using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;
using WPF_testovoe.Entity.Context;
using WPF_testovoe.Entity.Model;
using WPF_testovoe.Notifications;
using WPF_testovoe.Utilty;
using WPF_testovoe.Validator;

namespace WPF_testovoe.ViewModels
{
    public class EmployeesViewModel : BaseDataPageViewModel<Employee>, INotificationPageService, IViewModel
    {
        #region Свойства
        private INotification _notification;
        public INotification Notification
        {
            get { return _notification; }
            set { OnPropertyChanged(ref _notification, value); }
        }
        #endregion

        #region Конструктор
        public EmployeesViewModel(ShopContext shopContext, IValidator v, INotification notification)
            : base(shopContext,v)
        {
            Notification = notification;
            NewRecord = new Employee();
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
            if (String.IsNullOrEmpty(NewRecord.FullName))
            {
                Notification.SetData(Properties.Resources.AddNewRecordError, "Red");
                return;
            }

            ListNewRecords.Add(NewRecord);
            Records.Add(NewRecord);
            NewRecord = new Employee();

            Notification.SetData(Properties.Resources.AddNewRecordSuccessfully, "Green");
        }
        public override void LoadPage()
        {
            Records = new ObservableCollection<Employee>(db.Employees.ToList());
        }
        public override void SaveAllRecords()
        {
            db.Employees.AddRange(ListNewRecords);
            db.Employees.RemoveRange(ListDeletedRecords);
            db.SaveChanges();

            Notification.SetData(Properties.Resources.AllRecordsSavedSuccessfully, "Green");
        }
        #endregion
    }
}
