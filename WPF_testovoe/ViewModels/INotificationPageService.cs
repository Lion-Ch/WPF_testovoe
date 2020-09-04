using System;
using System.Collections.Generic;
using System.Text;
using WPF_testovoe.Notifications;

namespace WPF_testovoe.ViewModels
{
    public interface INotificationPageService
    {
        public INotification Notification { get; set; }
    }
}
