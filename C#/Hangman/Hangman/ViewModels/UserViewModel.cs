using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.Integration;
using System.Windows.Input;
using Hangman.Models;
using Hangman.Views;
namespace Hangman.ViewModels
{
    internal class UserViewModel:INotifyPropertyChanged
    {
        public void newUser(object parameter)
        {
            NewUserView newUser = new NewUserView();
            newUser.Show();

           

        }

        public void RefreshList(object parameter)
        {
            DatabaseConnection database = new DatabaseConnection();

            Users = database.getUsers();
            SelectedUser = 0;
           
            

        }

        public void DeleteUsr(object parameter)
        {
            if (SelectedUser<Users.Count)
            {
                DatabaseConnection db = new DatabaseConnection();

                db.DeleteUserByName(Users[SelectedUser]);

                Users.Remove(Users[SelectedUser]);
                SelectedUser = 0;
            }

        }

        public void PlayGame(object parameter)
        {
            if (Users.Count > 0)
            {
                GameWindow gameWindow = new GameWindow();

                gameWindow.DataContext = new GameViewModel(Users[SelectedUser]);
                gameWindow.Show();
            }
            else
            {
                var d = MessageBox.Show("Please select an user !");

            }

        }

        public void StatsFunc(object parameter)
        {
            StatisticsView statistics = new StatisticsView();
            statistics.DataContext = new StatisticsViewModel();

            statistics.Show();

        }

        private ICommand m_newUser;
        private ICommand m_refresh;
        private ICommand m_deleteUser;
        private ICommand m_play;
        private ICommand m_stats;

        public ICommand Stats
        {
            get { m_stats = new RelayCommand(StatsFunc); return m_stats; }

        }

        public ICommand Play 
        {
        get { m_play = new RelayCommand(PlayGame); return m_play; }
        }
        public ICommand DeleteUser
        {
            get {

                m_deleteUser = new RelayCommand(DeleteUsr);
                return m_deleteUser; }
                
        }
        public ICommand NewUser {
            get {


                m_newUser = new RelayCommand(newUser);
                return m_newUser;

            }
        }

        public ICommand Refresh
        {
            get
            {
                m_refresh = new RelayCommand(RefreshList);
                return m_refresh;

            }
        }

            


        public UserViewModel()
        {

            DatabaseConnection database= new DatabaseConnection();
            _users = database.getUsers();


        }

        private User _user;
        private ObservableCollection<User> _users;
        private int _selectedUser;

        public int SelectedUser{
        private get{ return _selectedUser; }
            set{ _selectedUser = value;
                OnPropertyChanged("SelectedUser");
            }
        }
        public User User
        {
            get { return _user; }
            set { _user = value; }
        }

        public ObservableCollection<User> Users { 
           get { return _users; } 
           private set { _users = value;
                OnPropertyChanged("Users");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;

            if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));


        }
    }
}
