using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hangman.Models
{
    internal class ButtonKey:INotifyPropertyChanged
    {

        private string _key;
        private bool _isEnabled;


        public string Key
        {
            get { return _key; }
            set { _key = value;}
        }

        public bool IsEnabled
        {
            get { return _isEnabled; }
            set { _isEnabled = value; OnPropertyChanged("IsEnabled"); }
        }


        public ButtonKey(string key)
        {
            Key = key;
            IsEnabled = true;
        }

        public ButtonKey(string key,bool isenabled)
        {
            Key = key;
            IsEnabled = isenabled;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;

            if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
            

        }
    } 
}
