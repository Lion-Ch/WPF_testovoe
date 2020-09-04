using System;
using System.Collections.Generic;
using System.Text;
using WPF_testovoe.Utilty;

namespace WPF_testovoe.Notifications
{
    public class BaseNotification : ObservableObject, INotification
    {
        private string _text;
        public string Text
        {
            get { return _text; }
            set { OnPropertyChanged(ref _text, value); }
        }
        private string _color;
        public string Color
        {
            get { return _color; }
            set { OnPropertyChanged(ref _color, value); }
        }

        public void SetData( string text, string color)
        {
            Text = text; Color = color;
        }
    }
}
