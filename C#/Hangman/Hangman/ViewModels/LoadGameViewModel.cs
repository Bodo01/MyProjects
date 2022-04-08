using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using GalaSoft.MvvmLight.Command;
using Hangman.Models;


namespace Hangman.ViewModels
{
    internal class LoadGameViewModel:INotifyPropertyChanged
    {


        private ObservableCollection<Game> _savedGames;
        private int _selectedIndex;
       
        public int SelectedIndex
        {
            get { return _selectedIndex; }
            set { _selectedIndex = value; OnPropertyChanged("SelectedIndex"); }
        }
        public ObservableCollection<Game> Games
        {
            get { return _savedGames; }
            set { _savedGames = value; OnPropertyChanged("Games"); }

        }
        
      public LoadGameViewModel(ObservableCollection<Game> savedGames)
        {
           SelectedIndex = 0;
           Games = savedGames;
            CloseWindowCommand = new RelayCommand<IClosable>(this.CloseWindow);

          

        }

     
        



        public RelayCommand<IClosable> CloseWindowCommand { get; set; }

        private  void CloseWindow(IClosable window)
        {

            GLOBALS.loadGameIndex = SelectedIndex;
            if (window != null)
                window.Close();

        }

        private ICommand _loadGameCommand;
       

       

        

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;

            if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));


        }
    }
}
