using BLL.DTO;
using BLL.Interfaces;
using BLL.Services;
using DAL.Entities;
using PL.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace PL.ViewModels
{
    public class CategoriesViewModel: BaseDataPageViewModel<CategoryDTO>
    {
        //private UniversalService<Category, CategoryDTO, CategoryModel> universalService;
        public CategoriesViewModel(IDataService<CategoryDTO> dataService)
               : base(dataService)
        {
            this.dataService = dataService;
            NewRecord = new CategoryDTO();
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
            NewRecord = new CategoryDTO();

            //Notification.SetData(Properties.Resources.AddNewRecordSuccessfully, "Green");
        }
        public override void LoadRecords()
        {
            Records = new ObservableCollection<CategoryDTO>(dataService.GetAll());
        }
        public override void SaveAllRecords()
        {
            foreach(CategoryDTO c in ListNewRecords)
                dataService.Create(c);
            foreach (CategoryDTO c in ListDeletedRecords)
                dataService.Delete(c.Id);
            foreach (CategoryDTO c in ListChangedRecords)
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
