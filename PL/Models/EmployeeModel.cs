using PL.Utility;
using System;
using System.Collections.Generic;
using System.Text;

namespace PL.Models
{
    public class EmployeeModel: ObservableObject
    {
        public int Id { get; set; }
        private string fullName;
        public string FullName
        {
            get { return fullName; }
            set
            {
                OnPropertyChanged(ref fullName, value);
            }
        }
    }
}
