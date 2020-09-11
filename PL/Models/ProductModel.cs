using DAL.Entities;
using PL.Utility;
using System;
using System.Collections.Generic;
using System.Text;

namespace PL.Models
{
    public class ProductModel: ObservableObject
    {
        public int Id { get; set; }
        private string name;
        public string Name
        {
            get { return name; }
            set { OnPropertyChanged(ref name, value); }
        }
        private string amount;
        public string Amount
        {
            get { return amount; }
            set { OnPropertyChanged(ref amount, value); }
        }
        public int CategoryId { get; set; }

        public CategoryModel category;
        public CategoryModel Category
        {
            get { return category; }
            set { CategoryId = value.Id; OnPropertyChanged(ref category, value); }
        }
    }
}
