using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hotel.Tools;
using Hotel.Models.BusinessLogicLayer;
using Hotel.Models;
using System.Windows.Input;
using System.Windows;


namespace Hotel.ViewModels
{
    internal class RegisterViewModel:NotifyProp
    {

        public RegisterViewModel()
        { 
        _userBLL = new UserBLL();
        }

        

        private string _username;
        private string _password;
        private string _phone;
        private string _email;
        private string _name;
        private UserBLL _userBLL;

        public string Username
        {
            get { return _username; }
            set { _username = value; OnPropertyChanged("Username"); }
        }

        public string Password
        {
            get { return _password; }
            set { _password = value; OnPropertyChanged("Password"); }

        }

        public string Phone
        {
            get { return _phone; }
            set { _phone = value; OnPropertyChanged("Phone"); }

        }

        public string Email
        {
            get { return _email; }
            set { _email = value; OnPropertyChanged("Email"); }

        }

        public string Name
        {
            get { return _name; }
            set { _name = value; OnPropertyChanged("Name"); }

        }

        private void Reg(object parameter)
        {
            if(_userBLL.UsernameExists(Username))
            {
                MessageBox.Show("Username already exists!");
            }
            else
            {
                User newUser = new User();
                newUser.username = Username;
                newUser.name = Name;
                newUser.email = Email;
                newUser.pass_word = Password;
                newUser.phone_number = Phone;

                _userBLL.AddMethod(newUser);

            }


        }


        private ICommand m_register;

        public ICommand Register
        {
            get { m_register = new RelayCommand(Reg);

                return m_register;
            }
        }

    }
}
