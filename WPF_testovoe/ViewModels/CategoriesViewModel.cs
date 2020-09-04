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
        private Category _newRecord;
        public Category NewRecord
        {
            get { return _newRecord; }
            set { OnPropertyChanged(ref _newRecord, value); }
        }
        private ObservableCollection<Category> _records;
        public ObservableCollection<Category> Records
        {
            get { return _records; }
            set
            {
                OnPropertyChanged(ref _records, value);
            }
        }
        private INotification _notification;
        public INotification Notification
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

        public CategoriesViewModel(ShopContext shopContext)
        {
            db = shopContext;
            Notification = new BaseNotification();
            LoadRecords();

            AddNewRecordCommand   = new RelayCommand(AddNewRecord);
            DeleteRecordCommand   = new RelayCommand(DeleteRecord);
            SaveAllRecordsCommand = new RelayCommand(SaveAllRecords);
        }

        private void DeleteRecord()
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
        private void AddNewRecord()
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
        private void LoadRecords()
        {
            Records = new ObservableCollection<Category>(db.Categories.ToList());
            OnPropertyChanged("Categories");
        }
        private void SaveAllRecords()
        {
            db.SaveChanges();
            Notification.SetData(Properties.Resources.AllRecordsSavedSuccessfully, "Green");
        }
    }
}
