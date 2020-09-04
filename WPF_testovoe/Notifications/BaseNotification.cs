using System;
using System.Collections.Generic;
using System.Text;
using WPF_testovoe.Utilty;

namespace WPF_testovoe.Notifications
{
    public class BaseNotification: INotification
    {
        public string Text { get; set; }
    }
}
