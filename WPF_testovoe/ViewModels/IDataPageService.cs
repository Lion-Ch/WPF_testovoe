using System.Collections.ObjectModel;

namespace WPF_testovoe.ViewModels
{
    public interface IDataPageService<TypeRecord>
    {
        public TypeRecord SelectedRecord { get; set; }
        public TypeRecord NewRecord { get; set; }
        public ObservableCollection<TypeRecord> Records { get; set; }

        public virtual void DeleteRecord() { }
        public virtual void AddNewRecord() { }
        public virtual void LoadPage() { }
        public virtual void SaveAllRecords() { }
    }
}