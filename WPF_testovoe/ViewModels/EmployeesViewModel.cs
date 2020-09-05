﻿using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;
using WPF_testovoe.Entity.Context;
using WPF_testovoe.Entity.Model;
using WPF_testovoe.Notifications;
using WPF_testovoe.Utilty;
using WPF_testovoe.Validator;

namespace WPF_testovoe.ViewModels
{
    public class EmployeesViewModel : BaseDataPageViewModel<Employee>, INotificationPageService, IDataValidateService, IViewModel
    {
        #region Свойства
        public IValidator    Validator { get; set; }
        public INotification Notification { get; set; }
        #endregion

        #region Конструктор
        public EmployeesViewModel(IContext shopContext, IValidator validator, INotification notification)
            : base(shopContext)
        {
            Validator = validator;
            Notification = notification;
            NewRecord = new Employee();
        }
        #endregion

        #region DataService
        public override void DeleteRecord()
        {
            if (SelectedRecord != null)
            {
                ListDeletedRecords.Add(SelectedRecord);
                Records.Remove(SelectedRecord);

                Notification.SetData(Properties.Resources.DeleteRecordSuccessfully, "Green");
            }
            else
                Notification.SetData(Properties.Resources.RecordSelectedError, "Red");
        }
        public override void AddNewRecord()
        {
            if (!Validator.IsValid(NewRecord))
            {
                Notification.SetData(Validator.ErrorText, "Red");
                return;
            }

            ListNewRecords.Add(NewRecord);
            Records.Add(NewRecord);
            NewRecord = new Employee();

            Notification.SetData(Properties.Resources.AddNewRecordSuccessfully, "Green");
        }
        public override void LoadRecords()
        {
            Records = new ObservableCollection<Employee>(db.Employees.ToList());
        }
        public override void SaveAllRecords()
        {
            db.Employees.AddRange(ListNewRecords);
            db.Employees.RemoveRange(ListDeletedRecords);

            if (Validator.IsValid(ListChangedRecords))
            {
                db.SaveChanges();
                if (ListChangedRecords.Count > 1)
                    ListChangedRecords.RemoveRange(1, ListChangedRecords.Count - 1);
                Notification.SetData(Properties.Resources.AllRecordsSavedSuccessfully, "Green");
            }
            else
            {
                Notification.SetData(Validator.ErrorText, "Red");
            }

            ListNewRecords.Clear();
            ListDeletedRecords.Clear();
        }
        #endregion
    }
}
