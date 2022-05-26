using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Hotel.Tools;
using Hotel.Models.BusinessLogicLayer;
using System.Windows;
using Hotel.Views;

namespace Hotel.ViewModels
{
    internal class LoginViewModel:NotifyProp
    {


        public LoginViewModel()
        {
            _userBll = new UserBLL();

        }

        private string _username;
        private string _password;
        private UserBLL _userBll;

        public string Username
        {
            get { return _username; }
            set { _username = value; OnPropertyChanged("Username"); }
        }

        public string Password
        {
            get { return _password; }
            set { _password = value; OnPropertyChanged("Password");}

        }

        private void ConnectCommand(object parameter)
        {
            

            if(_userBll.VerifyExistanceOfAnUser(Username,Password)==null)
            {
                MessageBox.Show("User doesn't exist!");
            }
            else
            {
                ClientView clientView = new ClientView();
                clientView.DataContext = new ClientViewModel( _userBll.VerifyExistanceOfAnUser(Username, Password));
                clientView.Show();
              

            }

        }
        private void ConnectAsGuestCommand(object parameter)
        {
            ClientView clientView = new ClientView();
            clientView.DataContext = new ClientViewModel(null);
            clientView.Show();

        }
        private void RegisterCommand(object parameter)
        {
            Register register = new Register();
            register.Show();

        }

        private ICommand m_connect;
        private ICommand m_register;
        private ICommand m_connectAsGuest;

        public ICommand Connect
        {
            get
            {
                m_connect = new RelayCommand(ConnectCommand);
                return m_connect;
            }

        }

        public ICommand Register
        {
            get
            {
                m_register = new RelayCommand(RegisterCommand);
                return m_register;
            }
        }

        public ICommand ConnectAsGuest
        {
            get
            {
                m_connectAsGuest = new RelayCommand(ConnectAsGuestCommand);
                return m_connectAsGuest;
            }
        }

    }
}
