using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;
using WPF_testovoe.Entity.Context;
using WPF_testovoe.Entity.Model;
using WPF_testovoe.Notifications;
using WPF_testovoe.Utilty;

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
        public EmployeesViewModel(ShopContext shopContext, INotification notification)
            : base(shopContext)
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
                db.Employees.Remove(SelectedRecord);
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

            Records.Add(NewRecord);
            db.Employees.Add(NewRecord);
            NewRecord = new Employee();
            Notification.SetData(Properties.Resources.AddNewRecordSuccessfully, "Green");
        }
        public override void LoadPage()
        {
            Records = new ObservableCollection<Employee>(db.Employees.ToList());
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
