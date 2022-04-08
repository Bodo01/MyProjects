using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hangman.Models
{
   public class Statistics:INotifyPropertyChanged
    {
       private string _name;
       private string _categoryName;
        private int _won;
        private int _lost;

        public string Name
        { get { return _name; } set { _name = value; } }    

        public string CategoryName { get { return _categoryName; } set { _categoryName = value;} }

        public int Won
        {
            get { return _won; } set { _won = value; } 
        }

        public int Lost
        { get { return _lost; } set {_lost = value; } }

        public Statistics()
        { }
        public Statistics(string name,string cat,int w,int l)
        {
            Name = name;
            CategoryName = cat;
            Won = w;
            Lost = l;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;

            if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));

        }
    }
}
