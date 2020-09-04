using System;
using System.Collections.Generic;
using System.Text;

namespace WPF_testovoe.Notifications
{
    public class ColoredNotification : BaseNotification, IColoredNotification
    {
        public string Color { get; private set; }

        public void ErrorMode()
        {
            Color = "Red";
        }

        public void SuccesfulMode()
        {
            Color = "Green";
        }
    }
}
