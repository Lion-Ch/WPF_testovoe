using AutoMapper;
using BLL.DTO;
using BLL.Interfaces;
using BLL.Services;
using DAL.Entities;
using PL.Models;
using PL.Utility;
using PL.ViewModels.Interfaces;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows.Input;

namespace PL.ViewModels
{
    public class BaseDataPageViewModel<TypeRecord, dtoType> : ObservableObject, IDataPageService, IDisposable
        where TypeRecord : ObservableObject, new()
        where dtoType : class
    {
        #region Поля
        /// <summary>
        /// Сервис работающий с БД (DTO -> DB)
        /// Производит валидацию и другие бизнес процессы.
        /// </summary>
        protected IDataService<dtoType> dataService;
        /// <summary>
        /// Mapper для преобразования Model в DTO и обратно.
        /// </summary>
        protected IMapper mapper;

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
                    if ((ListChangedRecords.IndexOf(value) == -1 || ListChangedRecords.Count == 0)
                        && (ListNewRecords.IndexOf(value)==-1))
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
        public BaseDataPageViewModel(IDataService<dtoType> c)
        {
            dataService = c;
            mapper = CreateMap();

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
        public virtual IMapper CreateMap()
        {
            return new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<TypeRecord, dtoType>();
                cfg.CreateMap<dtoType, TypeRecord>();
            }).CreateMapper();
        }

        public virtual void DeleteRecord()
        {
            if (SelectedRecord != null)
            {
                if (ListNewRecords.IndexOf(SelectedRecord) == -1)
                    ListDeletedRecords.Add(SelectedRecord);
                Records.Remove(SelectedRecord);
            }
        }
        public virtual void AddNewRecord()
        {
            ListNewRecords.Add(NewRecord);
            Records.Add(NewRecord);
            NewRecord = new TypeRecord();
        }
        public virtual void LoadRecords()
        {
            Records = new ObservableCollection<TypeRecord>(mapper.Map<IEnumerable<dtoType>, List<TypeRecord>>(dataService.GetAll()));
        }
        public virtual void SaveAllRecords()
        {
            dataService.CreateRange(mapper.Map<List<TypeRecord>, IEnumerable<dtoType>>(ListNewRecords));
            foreach (TypeRecord c in ListDeletedRecords)
                dataService.Delete(mapper.Map<TypeRecord,dtoType>(c));
            foreach (TypeRecord c in ListChangedRecords)
                dataService.Update(mapper.Map<TypeRecord, dtoType>(c));


            if (ListChangedRecords.Count > 1)
                ListChangedRecords.RemoveRange(1, ListChangedRecords.Count - 1);
            ListNewRecords.Clear();
            ListDeletedRecords.Clear();

            dataService.Save();
        }
        #endregion

        #region Dispose
        private bool disposed = false;
        public virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    dataService.Dispose();
                }
            }
            this.disposed = true;
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        #endregion
    }
}
