using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace WPF_testovoe.ViewModels
{
    public interface IDataPageService<TypeRecord>
    {
        public TypeRecord SelectedRecord { get; set; }
        public TypeRecord NewRecord { get; set; }
        public ObservableCollection<TypeRecord> Records { get; set; }

        public abstract void DeleteRecord();
        public abstract void AddNewRecord();
        public abstract void AddNewRecordPreProcess();
        public abstract void LoadRecords();
        public abstract void SaveAllRecords();
        public abstract bool CanAddRecord();
    }
}