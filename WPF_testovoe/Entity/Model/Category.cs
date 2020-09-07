using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text;
using WPF_testovoe.Utilty;

namespace WPF_testovoe.Entity.Model
{
    public class Product: ObservableObject
    {
        #region Столбцы
        public int Id { get; set; }

        private string _name;
        public string Name 
        { 
            get { return _name; } 
            set { OnPropertyChanged(ref _name, value); } 
        }
        #endregion

        #region Внешние ссылки
        public List<Product> Products { get; set; }
        #endregion

        public Product()
        {
            Products = new List<Product>();
        }
    }
}
