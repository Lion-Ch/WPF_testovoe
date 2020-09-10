using DAL.Entities;
using PL.Utility;
using System;
using System.Collections.Generic;
using System.Text;

namespace PL.Models
{
    public class CategoryModel: ObservableObject
    {
        public int Id { get; set; }

        public string _name;
        public string Name
        {
            get { return _name; }
            set { OnPropertyChanged(ref _name,value); }
        }
    }
}
