using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hangman.Models
{
    public class Category: INotifyPropertyChanged
    {


        private int _id;
        private string _categoryName;
        private List<string> _words;
        private bool _isChecked;

        public bool IsChecked
        {
            get { return _isChecked; }
            set { _isChecked = value;
                OnPropertyChanged("IsChecked");
            }
        }
        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }

        public string CategoryName
        {
            get { return _categoryName; }
                set { _categoryName = value; }
        }

        public List<string> Words
        {
            get { return _words; }
            set { _words = value; }
        }

        public Category(int id, string name)
        {
            IsChecked = false;
            Id = id;
            CategoryName = name;
            Words = new List<string>();
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;

            if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));


        }
    }
}
