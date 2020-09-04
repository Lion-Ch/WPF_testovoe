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
    public class CategoriesViewModel<TypeRecord>: BaseDataPageViewModel<TypeRecord>, IDataPageService<TypeRecord>, INotificationPageService, IViewModel
        where TypeRecord: Category
    {

        #region Свойства
        private INotification _notification;
        public  INotification Notification
        {
            get { return _notification; }
            set { OnPropertyChanged(ref _notification, value); }
        }
        #endregion

        #region Команды
        public ICommand AddNewRecordCommand { get; private set; }
        public ICommand DeleteRecordCommand { get; private set; }
        public ICommand SaveAllRecordsCommand { get; private set; }
        #endregion

        #region Конструктор
        public CategoriesViewModel(ShopContext shopContext, INotification notification)
            :base(shopContext)
        {
            Notification = notification;
        }
        #endregion

        #region DataService
        public override void DeleteRecord()
        {
            if (SelectedRecord != null)
            {
                db.Categories.Remove(SelectedRecord);
                Records.Remove(SelectedRecord);
                Notification.SetData(Properties.Resources.DeleteRecordSuccessfully, "Green");
            }
            else
                Notification.SetData(Properties.Resources.RecordSelectedError, "Red");
        }
        public override void AddNewRecord()
        {
            if (NewRecord == null)
            {
                Notification.SetData(Properties.Resources.AddNewRecordError, "Red");
                return;
            }

            Records.Add(NewRecord);
            db.Categories.Add(NewRecord);
            NewRecord = null;
            Notification.SetData(Properties.Resources.AddNewRecordSuccessfully, "Green");
        }
        public override void LoadRecords()
        {
            Records = new ObservableCollection<TypeRecord>(db.Categories.ToList());
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
