using Hangman.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Input;

namespace Hangman.ViewModels
{
    internal class NewUserViewModel:INotifyPropertyChanged
    {

        private void nextPic(object parameter)
        {
            if (_selectedPhoto == _picturePath.Count - 1)
                _selectedPhoto = 0;
            else _selectedPhoto++;


            SelectedPhotostr = _picturePath[_selectedPhoto];
          //  DialogResult res = MessageBox.Show();
        }

        private void prevPic(object parameter)
        {
            if (_selectedPhoto == 0)
                _selectedPhoto = _picturePath.Count - 1;
            else _selectedPhoto--;
            SelectedPhotostr = _picturePath[_selectedPhoto];

        }

        private void CreateNewUser(object parameter)
        {

            DatabaseConnection database = new DatabaseConnection();

            var Users = database.getUsers();

            for (int i = 0; i < Users.Count; i++)
                if (Users[i].Name.ToLower() == _username.ToLower())
                {
                    DialogResult res = MessageBox.Show("USERNAME ALREADY EXISTS!");
                    return;
                    break;
                }
            if (_username == "")
            { DialogResult res = MessageBox.Show("PLEASE INSERT AN USERNAME"); }
            else { 
           
            if (database.InsertNewUser(_username, _selectedPhoto + 1))
            {
                DialogResult res = MessageBox.Show("User succesfuly created!");

                    
                    
            }
            }
        }

        private ICommand m_nextPhoto;
        private ICommand m_previousPhoto;
        private ICommand m_createUser;

        public ICommand CreateUser { get {

               


                m_createUser = new RelayCommand(CreateNewUser);  
                
                return m_createUser; } }

        public ICommand NextPhoto { get { m_nextPhoto = new RelayCommand(nextPic);   return m_nextPhoto; } }
        public ICommand PreviousPhoto { get { m_previousPhoto = new RelayCommand(prevPic); return m_previousPhoto; } }



        private string _username;

        private List<string> _picturePath;

        private int _selectedPhoto = 0;

        private string _selectedPhotostr;
        public NewUserViewModel()
        {
            _username = "";

            _picturePath = new List<string>();
            _picturePath.Add("D:\\Proiecte WPF\\Hangman\\Hangman\\Pictures\\picture1.jpg");
            _picturePath.Add("D:\\Proiecte WPF\\Hangman\\Hangman\\Pictures\\picture2.jpg");
            _picturePath.Add("D:\\Proiecte WPF\\Hangman\\Hangman\\Pictures\\picture3.jpg");
            _picturePath.Add("D:\\Proiecte WPF\\Hangman\\Hangman\\Pictures\\picture4.jpg");
            _selectedPhotostr = _picturePath[0];
        }

        public string Username
        {
            get { return _username; }
            set { _username = value; }
        }
        public string SelectedPhotostr { get { return _selectedPhotostr; } set { _selectedPhotostr = value;
                OnPropertyChanged("SelectedPhotoStr");
                    } }
        public int SelectedPhoto { 
            get { return _selectedPhoto; } 
            set { _selectedPhoto = value; } }


        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;

            if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));


        }
    }
}
