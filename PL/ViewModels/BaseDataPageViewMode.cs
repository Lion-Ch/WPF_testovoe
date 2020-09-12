using AutoMapper;
using BLL.Interfaces;
using BLL.Responses;
using BLL.Services;
using BLL.Validation;
using PL.Utility;
using PL.ViewModels.Interfaces;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows.Input;

namespace PL.ViewModels
{
    public class BaseDataPageViewModel<modelType, dtoType, dbType, serviceType> : ObservableObject, IDataPageService<modelType>, IMapped<dtoType, modelType>
        where modelType   : new()
        where dtoType     : IValidatable
        where serviceType : BaseService<dbType, dtoType>, new()
    {
        #region Поля
        protected IMapper mapper;

        protected List<modelType> ListNewRecords { get; set; }
        protected List<modelType> ListDeletedRecords { get; set; }
        protected List<modelType> ListChangedRecords { get; set; }
        #endregion

        #region Свойства
        private Response response;
        public Response Response
        {
            get { return response; }
            set { OnPropertyChanged(ref response, value); }
        }

        private modelType _selectedRecord;
        public modelType SelectedRecord
        {
            get { return _selectedRecord; }
            set
            {
                if (value != null)
                    if ((ListChangedRecords.IndexOf(value) == -1 || ListChangedRecords.Count == 0) && ListNewRecords.IndexOf(value)==-1)
                        ListChangedRecords.Add(value);
                OnPropertyChanged(ref _selectedRecord, value);
            }
        }

        private modelType _newRecord;
        public modelType NewRecord
        {
            get { return _newRecord; }
            set { OnPropertyChanged(ref _newRecord, value); }
        }

        private ObservableCollection<modelType> _records;
        public ObservableCollection<modelType> Records
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
        public BaseDataPageViewModel()
        {
            mapper = CreateMap();
            NewRecord = new modelType();

            ListNewRecords = new List<modelType>();
            ListDeletedRecords = new List<modelType>();
            ListChangedRecords = new List<modelType>();

            AddNewRecordCommand = new RelayCommand(AddNewRecord);
            DeleteRecordCommand = new RelayCommand(DeleteRecord);
            SaveAllRecordsCommand = new RelayCommand(SaveAllRecords);

            LoadRecords();
        }
        #endregion

        #region Mapping
        public virtual IMapper CreateMap()
        {
            return new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<modelType, dtoType>();
                cfg.CreateMap<dtoType, modelType>();
            }
            ).CreateMapper();
        }
        public virtual IEnumerable<dtoType> OutMap(IEnumerable<modelType> list)
        {
            return mapper.Map<IEnumerable<dtoType>>(list);
        }
        public virtual IEnumerable<modelType> InMap(IEnumerable<dtoType> list)
        {
            return mapper.Map<IEnumerable<modelType>>(list);
        }
        #endregion

        #region DataService
        public virtual void DeleteRecord()
        {
            if (SelectedRecord != null)
            {
                ListChangedRecords.Remove(SelectedRecord);

                if (ListNewRecords.IndexOf(SelectedRecord) >= 0)
                {
                    ListNewRecords.Remove(SelectedRecord);
                }
                else
                {
                    ListDeletedRecords.Add(SelectedRecord);
                }
                Records.Remove(SelectedRecord);
            }
        }
        public virtual void AddNewRecord()
        {
            ListNewRecords.Add(NewRecord);
            Records.Add(NewRecord);
            NewRecord = new modelType();
        }
        public virtual void LoadRecords()
        {
            using (BaseService<dbType, dtoType> dataService = new serviceType())
            {
                Records = new ObservableCollection<modelType>(InMap(dataService.GetAll()));
            }
        }
        public virtual void SaveAllRecords()
        {
            Response = new Response("", TypeRespone.OK);
            using (BaseService<dbType, dtoType> dataService = new serviceType())
            {
                if (ListNewRecords.Count != 0)
                    Response = dataService.CreateRange(OutMap(ListNewRecords));

                if (Response.Status == TypeRespone.OK)
                {
                    if (ListChangedRecords.Count != 0)
                        Response = dataService.UpdateRange(OutMap(ListChangedRecords));

                    if (Response.Status == TypeRespone.OK)
                    {
                        if (ListDeletedRecords.Count != 0)
                            Response = dataService.DeleteRange(OutMap(ListDeletedRecords));
                    }
                }
                if (Response.Status == TypeRespone.OK)
                {
                    Response = dataService.Save();
                    if(Response.Status == TypeRespone.OK)
                    {
                        if (ListChangedRecords.Count > 1)
                            ListChangedRecords.RemoveRange(1, ListChangedRecords.Count - 1);
                        ListNewRecords.Clear();
                        ListDeletedRecords.Clear();
                        LoadRecords();
                    }
                }
            }
        }
        #endregion
    }
}
