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
    public class CategoriesViewModel: BaseDataPageViewModel<CategoryModel, CategoryDTO>
    {
        //private UniversalService<Category, CategoryDTO> dataService;

        public CategoriesViewModel()
            :base(new UniversalService<Category, CategoryDTO>())
        {
        }

        #region DataService
        //public override void DeleteRecord()
        //{
        //    if (SelectedRecord != null)
        //    {
        //        if (SelectedRecord.Id != 0)
        //            ListDeletedRecords.Add(SelectedRecord);
        //        Records.Remove(SelectedRecord);
        //        //Notification.SetData(Properties.Resources.DeleteRecordSuccessfully, "Green");
        //    }
        //    //else
        //    //    //Notification.SetData(Properties.Resources.RecordSelectedError, "Red");
        //}
        //public override void AddNewRecord()
        //{
        //    //if (Validator.IsValid(NewRecord))
        //    //{
        //    //    Notification.SetData(Validator.ErrorText, "Red");
        //    //    return;
        //    //}

        //    ListNewRecords.Add(NewRecord);
        //    Records.Add(NewRecord);
        //    NewRecord = new CategoryModel();

        //    //Notification.SetData(Properties.Resources.AddNewRecordSuccessfully, "Green");
        //}
        //public override void LoadRecords()
        //{
        //    //Records = new ObservableCollection<CategoryModel>(mapper.Map<IEnumerable<CategoryDTO>,List<CategoryModel>>(dataService.GetAll()));
        //}
        //public override void SaveAllRecords()
        //{
        //    dataService.CreateRange(ListNewRecords);
        //    foreach (CategoryModel c in ListDeletedRecords)
        //        dataService.Delete(c);
        //    foreach (CategoryModel c in ListChangedRecords)
        //        dataService.Update(c);
        //    //if (Validator.IsValid(ListChangedRecords))
        //    //{
        //    //    db.SaveChanges();
        //    //    if (ListChangedRecords.Count > 1)
        //    //        ListChangedRecords.RemoveRange(1, ListChangedRecords.Count - 1);
        //    //    Notification.SetData(Properties.Resources.AllRecordsSavedSuccessfully, "Green");
        //    //}
        //    //else
        //    //{
        //    //    Notification.SetData(Validator.ErrorText, "Red");
        //    //}
        //    if (ListChangedRecords.Count > 1)
        //        ListChangedRecords.RemoveRange(1, ListChangedRecords.Count - 1);
        //    ListNewRecords.Clear();
        //    ListDeletedRecords.Clear();

        //    dataService.Save();
        //}
        #endregion
    }
}
