using BLL.Interfaces;
using PL.Utility;
using PL.ViewModels.Interfaces;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows.Input;

namespace PL.ViewModels
{
    public class BaseDataPageViewModel<TypeRecord> : ObservableObject, IDataPageService<TypeRecord>
        where TypeRecord: class
    {
        #region Поля
        protected IDataService<TypeRecord> dataService;
        protected List<TypeRecord> ListNewRecords { get; set; }
        protected List<TypeRecord> ListDeletedRecords { get; set; }
        protected List<TypeRecord> ListChangedRecords { get; set; }
        #endregion

        #region Свойства

        private TypeRecord _selectedRecord;
        public TypeRecord SelectedRecord
        {
            get { return _selectedRecord; }
            set
            {
                if (value != null)
                    if (ListChangedRecords.IndexOf(value) == -1 || ListChangedRecords.Count == 0)
                        ListChangedRecords.Add(value);
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

        public ICommand AddNewRecordCommand { get; protected set; }
        public ICommand DeleteRecordCommand { get; protected set; }
        public ICommand SaveAllRecordsCommand { get; protected set; }

        #endregion

        #region Конструктор
        public BaseDataPageViewModel(IDataService<TypeRecord> service)
        {
            dataService = service;

            ListNewRecords = new List<TypeRecord>();
            ListDeletedRecords = new List<TypeRecord>();
            ListChangedRecords = new List<TypeRecord>();

            AddNewRecordCommand = new RelayCommand(AddNewRecord);
            DeleteRecordCommand = new RelayCommand(DeleteRecord);
            SaveAllRecordsCommand = new RelayCommand(SaveAllRecords);

            LoadRecords();
        }
        #endregion

        #region DataService
        public virtual void DeleteRecord()
        {
        }
        public virtual void AddNewRecord()
        {
        }
        public virtual void AddNewRecordPreProcess()
        {
        }
        public virtual void LoadRecords()
        {
        }
        public virtual void SaveAllRecords()
        {
        }
        public virtual bool CanAddRecord()
        {
            return true;
        }
        #endregion
    }
}
