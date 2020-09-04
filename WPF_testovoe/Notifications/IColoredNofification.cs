using System;
using System.Collections.Generic;
using System.Text;

namespace WPF_testovoe.Notifications
{
    interface IColoredNotification
    {
        public void ErrorMode();
        public void SuccesfulMode();
    }
}
