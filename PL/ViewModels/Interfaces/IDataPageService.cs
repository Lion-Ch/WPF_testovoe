using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace PL.ViewModels.Interfaces
{
    public interface IDataPageService<TypeRecord>
    {
        public abstract void DeleteRecord();
        public abstract void AddNewRecord();
        public abstract void AddNewRecordPreProcess();
        public abstract void LoadRecords();
        public abstract void SaveAllRecords();
    }
}
