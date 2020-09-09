using BLL.DTO;
using BLL.Interfaces;
using PL.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace PL.ViewModels
{
    public class CategoriesViewModel: BaseDataPageViewModel<CategoryModel>
    {
        public CategoriesViewModel(IDataService<CategoryModel> dataService)
               : base(dataService)
        {
            this.dataService = dataService;
            NewRecord = new CategoryModel();
        }

        #region DataService
        public override void DeleteRecord()
        {
            if (SelectedRecord != null)
            {
                ListDeletedRecords.Add(SelectedRecord);
                Records.Remove(SelectedRecord);

                //Notification.SetData(Properties.Resources.DeleteRecordSuccessfully, "Green");
            }
            //else
            //    //Notification.SetData(Properties.Resources.RecordSelectedError, "Red");
        }
        public override void AddNewRecord()
        {
            //if (Validator.IsValid(NewRecord))
            //{
            //    Notification.SetData(Validator.ErrorText, "Red");
            //    return;
            //}

            ListNewRecords.Add(NewRecord);
            Records.Add(NewRecord);
            NewRecord = new CategoryModel();

            //Notification.SetData(Properties.Resources.AddNewRecordSuccessfully, "Green");
        }
        public override void LoadRecords()
        {
            Records = new ObservableCollection<CategoryModel>(dataService.GetAll());
        }
        public override void SaveAllRecords()
        {
            foreach(CategoryModel c in ListNewRecords)
                dataService.Create(c);
            foreach (CategoryModel c in ListDeletedRecords)
                dataService.Delete(c.Id);
            foreach (CategoryModel c in ListChangedRecords)
                dataService.Update(c);
            //if (Validator.IsValid(ListChangedRecords))
            //{
            //    db.SaveChanges();
            //    if (ListChangedRecords.Count > 1)
            //        ListChangedRecords.RemoveRange(1, ListChangedRecords.Count - 1);
            //    Notification.SetData(Properties.Resources.AllRecordsSavedSuccessfully, "Green");
            //}
            //else
            //{
            //    Notification.SetData(Validator.ErrorText, "Red");
            //}
            if (ListChangedRecords.Count > 1)
                ListChangedRecords.RemoveRange(1, ListChangedRecords.Count - 1);
            ListNewRecords.Clear();
            ListDeletedRecords.Clear();

            dataService.Save();
        }
        #endregion
    }
}
