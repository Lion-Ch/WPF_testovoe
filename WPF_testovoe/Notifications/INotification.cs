using System;
using System.Collections.Generic;
using System.Text;

namespace WPF_testovoe.Notifications
{
    public interface INotification
    {
        public string Color { get;  set; }
        public string Text { get; set; }
    }
}
