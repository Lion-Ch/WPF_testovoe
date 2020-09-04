﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using WPF_testovoe.Utilty;

namespace WPF_testovoe.Entity.Model
{
    public class Category: ObservableObject
    {
        public int Id { get; set; }

        private string _name;
        public string Name 
        { 
            get { return _name; } 
            set { OnPropertyChanged(ref _name, value); } 
        }

        public List<Product> Products { get; set; }

        public Category()
        {
            Products = new List<Product>();
        }
    }
}
