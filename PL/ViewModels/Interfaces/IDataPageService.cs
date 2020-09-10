using AutoMapper;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace PL.ViewModels.Interfaces
{
    public interface IDataPageService
    {
        public abstract IMapper CreateMap();
        public abstract void DeleteRecord();
        public abstract void AddNewRecord();
        public abstract void LoadRecords();
        public abstract void SaveAllRecords();
    }
}
