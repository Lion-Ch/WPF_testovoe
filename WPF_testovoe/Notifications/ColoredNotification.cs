using System;
using System.Collections.Generic;
using System.Text;

namespace WPF_testovoe.Notifications
{
    public class ColoredNotification : INotification
    {
        public string Color { get; private set; }
        public string Text { get; set; }

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
