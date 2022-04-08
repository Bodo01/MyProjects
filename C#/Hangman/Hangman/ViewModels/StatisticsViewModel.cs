using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Hangman.Models;
namespace Hangman.ViewModels
{
    internal class StatisticsViewModel:INotifyPropertyChanged
    {

        
        private ObservableCollection<User> _users;
        private ObservableCollection<ObservableCollection<Statistics>> _statisticsList;
        private int _selectedItem;
        private ObservableCollection<Statistics> _statisticsListCurrent;





        public ObservableCollection<Statistics> StatisticsListCurrent
        {
            get { return _statisticsListCurrent; }
            set { _statisticsListCurrent = value; OnPropertyChanged("StatisticsListCurrent"); }
        }
        public ObservableCollection<ObservableCollection<Statistics>> StatisticsList
        {
            get { return _statisticsList; }
            set { _statisticsList = value; OnPropertyChanged("StatisticsList"); }
        }
        public int SelectedItem
        {
            private get { return _selectedItem; }
            set
            {
                _selectedItem = value;
                OnPropertyChanged("SelectedUser");
            }
        }
        
        public StatisticsViewModel()
        {
            DatabaseConnection database = new DatabaseConnection();
            

            Users = database.getUsers();
            ObservableCollection<Statistics> aux= database.GetStatistics();
            SelectedItem = 0;

            StatisticsList = new ObservableCollection<ObservableCollection<Statistics>>();
          
            for (int i = 0; i < Users.Count; i++)
                StatisticsList.Add(new ObservableCollection<Statistics>());

                for (int i=0;i<Users.Count;i++)
                  for (int j=0;j<aux.Count;j++)
                    if (aux[j].Name==Users[i].Name) 
                        StatisticsList[i].Add(aux[j]);

                StatisticsListCurrent= StatisticsList[0];

        }
        public ObservableCollection<User> Users
        {
            get { return _users; }
            private set
            {
                _users = value;
                OnPropertyChanged("Users");
            }
        }

        public void LoadStatsFunc(object parameter)
        {
            StatisticsListCurrent = StatisticsList[SelectedItem];
        }

        private ICommand _loadStats;

        public ICommand LoadStats
        {
            get
            {
                if (_loadStats == null)
                { _loadStats = new RelayCommand(LoadStatsFunc); }
                return _loadStats;
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
