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

    public class EmployeesViewModel
    {

    }
    //public class EmployeesViewModel<TypeRecord> : BaseDataPageViewModel<TypeRecord>, IDataPageService<TypeRecord>, INotificationPageService, IViewModel
    //    where TypeRecord : Employee
    //{
    //    #region Свойства
    //    private INotification _notification;
    //    public INotification Notification
    //    {
    //        get { return _notification; }
    //        set { OnPropertyChanged(ref _notification, value); }
    //    }
    //    #endregion

    //    #region Конструктор
    //    public EmployeesViewModel(ShopContext shopContext, INotification notification)
    //        : base(shopContext)
    //    {
    //        Notification = notification;
    //    }
    //    #endregion

    //    #region DataService
    //    private void DeleteRecord()
    //    {
    //        if (SelectedRecord != null)
    //        {
    //            db.Employees.Remove(SelectedRecord);
    //            Records.Remove(SelectedRecord);
    //            Notification.SetData(Properties.Resources.DeleteRecordSuccessfully, "Green");
    //        }
    //        else
    //            Notification.SetData(Properties.Resources.RecordSelectedError, "Red");
    //    }
    //    private void AddNewRecord()
    //    {
    //        if (NewRecord == null)
    //        {
    //            Notification.SetData(Properties.Resources.AddNewRecordError, "Red");
    //            return;
    //        }

    //        Records.Add(NewRecord);
    //        db.Employees.Add(NewRecord);
    //        NewRecord = null;
    //        Notification.SetData(Properties.Resources.AddNewRecordSuccessfully, "Green");
    //    }
    //    private void LoadRecords()
    //    {
    //        Records = new ObservableCollection<TypeRecord>(db.Employees.ToList());
    //        OnPropertyChanged("Categories");
    //    }
    //    private void SaveAllRecords()
    //    {
    //        db.SaveChanges();
    //        Notification.SetData(Properties.Resources.AllRecordsSavedSuccessfully, "Green");
    //    }
    //    #endregion
    //}
}
