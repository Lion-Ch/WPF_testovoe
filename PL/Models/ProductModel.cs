using DAL.Entities;
using PL.Utility;
using System;
using System.Collections.Generic;
using System.Text;

namespace PL.Models
{
    public sealed class ProductModel:ObservableObject
    {
        public int Id { get; set; }

        private string name;
        public string Name
        {
            get { return name; }
            set { OnPropertyChanged(ref name, value); }
        }
        private int amount;
        public int Amount
        {
            get { return amount; }
            set { OnPropertyChanged(ref amount, value); }
        }
        public int CategoryId { get; set; }
        private string categoryName;
        public string CategoryName
        {
            get { return categoryName; }
            set { OnPropertyChanged(ref categoryName, value); }
        }

        private CategoryModel category;
        public CategoryModel Category
        {
            get { return category; }
            set { CategoryName = value.Name; CategoryId = value.Id; OnPropertyChanged(ref category, value); }
        }
    }
}
