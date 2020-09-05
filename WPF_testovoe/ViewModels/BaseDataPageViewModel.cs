using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Windows.Input;
using WPF_testovoe.Entity.Context;
using WPF_testovoe.Entity.Model;
using WPF_testovoe.Notifications;
using WPF_testovoe.Utilty;
using WPF_testovoe.Validator;

namespace WPF_testovoe.ViewModels
{
    public class BaseDataPageViewModel<TypeRecord> : ObservableObject, IDataPageService<TypeRecord>, IViewModel
    {
        #region Поля
        protected ShopContext db;
        protected IValidator validator;
        protected List<TypeRecord> ListNewRecords     { get; set; }
        protected List<TypeRecord> ListDeletedRecords { get; set; }
        #endregion

        #region Свойства

        private TypeRecord _selectedRecord;
        public TypeRecord SelectedRecord
        {
            get { return _selectedRecord; }
            set
            {
                OnPropertyChanged(ref _selectedRecord, value);
            }
        }

        private TypeRecord _newRecord;
        public TypeRecord NewRecord
        {
            get { return _newRecord; }
            set { OnPropertyChanged(ref _newRecord, value); }
        }

        private ObservableCollection<TypeRecord> _records;
        public ObservableCollection<TypeRecord> Records
        {
            get { return _records; }
            set
            {
                OnPropertyChanged(ref _records, value);
            }
        }
        #endregion

        #region Команды

        public ICommand AddNewRecordCommand   { get; protected set; }
        public ICommand DeleteRecordCommand   { get; protected set; }
        public ICommand SaveAllRecordsCommand { get; protected set; }

        #endregion

        #region Конструктор
        public BaseDataPageViewModel(ShopContext shopContext, IValidator v)
        {
            ListNewRecords     = new List<TypeRecord>();
            ListDeletedRecords = new List<TypeRecord>();

            validator = v;
            db        = shopContext;

            AddNewRecordCommand   = new RelayCommand(AddNewRecord);
            DeleteRecordCommand   = new RelayCommand(DeleteRecord);
            SaveAllRecordsCommand = new RelayCommand(SaveAllRecords);

            LoadPage();
        }
        #endregion

        #region DataService
        public virtual void DeleteRecord()
        {
            
        }
        public virtual void AddNewRecord()
        {
            if (NewRecord == null)
                return;

            Records.Add(NewRecord);
            NewRecord = default(TypeRecord);
        }
        public virtual void LoadPage()
        {
            OnPropertyChanged("Categories");
        }
        public virtual void SaveAllRecords()
        {
            db.SaveChanges();
        }
        #endregion
    }
}
