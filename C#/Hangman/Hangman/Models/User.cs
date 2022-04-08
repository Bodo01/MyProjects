using System;
using System.ComponentModel;

namespace Hangman.Models
{
    public class User: INotifyPropertyChanged
    {
        private int _id;
        private string _name;
        private int _picture;
        private string _picturePath;

        public User(int id,string name,int picture)
        { 
            _id = id;
            _name = name;
            _picture = picture;

            switch(_picture)
            {
                case 1:
                    _picturePath = "D:\\Proiecte WPF\\Hangman\\Hangman\\Pictures\\picture1.jpg";
                    break;
                case 2:
                    _picturePath = "D:\\Proiecte WPF\\Hangman\\Hangman\\Pictures\\picture2.jpg";
                    break;
                case 3:
                    _picturePath = "D:\\Proiecte WPF\\Hangman\\Hangman\\Pictures\\picture3.jpg";
                    break;
                case 4:
                    _picturePath = "D:\\Proiecte WPF\\Hangman\\Hangman\\Pictures\\picture4.jpg";
                    break;
                default: _picturePath = "D:\\Proiecte WPF\\Hangman\\Hangman\\Pictures\\pictureDefault.png";
                    break;

            }

        }


        public string PicturePath { 
            get { return _picturePath; } 
            
            set { _picturePath = value; } }
        public string Name
        {
            get { return _name; }
            set { _name = value;
                OnPropertyChanged("Name");
            }

        }

        public int Picture
        {
            private get { return _picture; }
            set
            {
                _picture = value;
                OnPropertyChanged("Picture");
            }
        }

        public int Id
        {
            get { return _id; }
            set { _id = value; }
        
        }

            public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged (string propertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;

            if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));


        }
    }
}
