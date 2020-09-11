using PL.Utility;
using System;
using System.Collections.Generic;
using System.Text;

namespace PL.Models
{
    public class ProductModel: ObservableObject
    {
        public int Id { get; set; }
        private string _name;
        public string Name
        {
            get { return _name; }
            set { OnPropertyChanged(ref _name, value); }
        }
        public CategoryModel CategoryModel{ get; set; }
    }
}
