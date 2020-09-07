using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using WPF_testovoe.Utilty;

namespace WPF_testovoe.Entity.Model
{
    public class Product:ObservableObject
    {
        public int Id { get; set; }

        private string _name;
        public string Name 
        { 
            get { return _name; } 
            set { OnPropertyChanged(ref _name, value); } 
        }
        private int _amount;
        public int Amount 
        { 
            get { return _amount; } 
            set { OnPropertyChanged(ref _amount, value); } 
        }

        private int _ProductId;
        public int ProductId
        {
            get { return _ProductId; }
            set { OnPropertyChanged(ref _ProductId, value); }
        }
        private Product _Product;
        public Product Product
        {
            get { return _Product; }
            set { OnPropertyChanged(ref _Product, value); }
        }

        public IEnumerable<Sale> Sales { get; set; }

        public Product()
        {
            Sales = new List<Sale>();
        }
    }
}
