using System.Collections.ObjectModel;

namespace WPF_testovoe.ViewModels
{
    public interface IDataPageService<TypeRecord>
    {
        public TypeRecord SelectedRecord { get; set; }
        public TypeRecord NewRecord { get; set; }
        public ObservableCollection<TypeRecord> Records { get; set; }

        private void DeleteRecord() { }
        private void AddNewRecord() { }
        private void LoadRecords() { }
        private void SaveAllRecords() { }
    }
}