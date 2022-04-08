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
    internal class GameViewModel:INotifyPropertyChanged
    {
        #region Var declaration

      

        private User _user;
        private KeyBoardCls _keyBoard;
        private ObservableCollection<Category> _categories;
        private string _gamePhaseImage;
        private Game _currentGame;
       
        private string _currentCategories;
        private bool _categoryEnable;

        private ObservableCollection<Game> _savedGames;
        private ObservableCollection<Game> _finishedGames;

        public ObservableCollection<Game> FinishedGames
        {
            get { return _finishedGames; }
            set { _finishedGames = value; OnPropertyChanged("FinishedGames"); }


        }
        public bool CategoryEnable
        {
            get { return _categoryEnable; }
            set { _categoryEnable = value; OnPropertyChanged("CategoryEnable"); }

        }
       


        public ObservableCollection<Game> SavedGames
        {
            get { return _savedGames; }
            set { _savedGames = value; OnPropertyChanged("SavedGames"); }

        }
        public string CurrentCategories
        {
            get { return _currentCategories; }
            set { _currentCategories = value; OnPropertyChanged("CurrentCategories"); }
        }

        public Game CurrentGame
        {
           get { return _currentGame; }
            set { _currentGame = value; OnPropertyChanged("CurrentGame"); }

        }
        public string GamePhaseImage
        {
            get { return _gamePhaseImage; }
            set { _gamePhaseImage = value; OnPropertyChanged("GamePhaseImage"); }
        }

       
        public ObservableCollection<Category> Categories
        {
            get { return _categories; }
            set { _categories = value; OnPropertyChanged("Categories");  }

        }

        public KeyBoardCls KeyBoardCl
        {
            get { return _keyBoard; }
            set { _keyBoard = value; OnPropertyChanged("KeyBoardCl"); }
        }

        public User User { 
            get { return _user; } 
            set { _user = value; }
        }

        #endregion

        public GameViewModel(User user)
        {
            DatabaseConnection database = new DatabaseConnection();

            

            User = user;
            KeyBoardCl = new KeyBoardCls();
            Categories = database.GetCategories();
            CategoryEnable = true;
            UpdateGamesList();
        }


        #region KeyBoard Functioning

        #region Commands for ICommand
        private void DisablebuttonQ(object parameter)
        {               
              KeyBoardCl.ButtonQ.IsEnabled = false;
            GuessLetter('Q');
         

        }
        private void DisablebuttonW(object parameter)
        {
            KeyBoardCl.ButtonW.IsEnabled = false;
            GuessLetter('W');
        }
        private void DisablebuttonE(object parameter)
        {
            KeyBoardCl.ButtonE.IsEnabled = false;
            GuessLetter('E');
        }
        private void DisablebuttonR(object parameter)
        {
            KeyBoardCl.ButtonR.IsEnabled = false;
            GuessLetter('R');

        }
        private void DisablebuttonT(object parameter)
        {
            KeyBoardCl.ButtonT.IsEnabled = false;
            GuessLetter('T');

        }
        private void DisablebuttonY(object parameter)
        {
            KeyBoardCl.ButtonY.IsEnabled = false;
            GuessLetter('Y');

        }
        private void DisablebuttonU(object parameter)
        {
            KeyBoardCl.ButtonU.IsEnabled = false;
            GuessLetter('U');

        }
        private void DisablebuttonI(object parameter)
        {
            KeyBoardCl.ButtonI.IsEnabled = false;
            GuessLetter('I');

        }
        private void DisablebuttonO(object parameter)
        {
            KeyBoardCl.ButtonO.IsEnabled = false;
            GuessLetter('O');

        }
        private void DisablebuttonP(object parameter)
        {
            KeyBoardCl.ButtonP.IsEnabled = false;
            GuessLetter('P');

        }
        private void DisablebuttonA(object parameter)
        {
            KeyBoardCl.ButtonA.IsEnabled = false;
            GuessLetter('A');

        }
        private void DisablebuttonS(object parameter)
        {
            KeyBoardCl.ButtonS.IsEnabled = false;
            GuessLetter('S');

        }
        private void DisablebuttonD(object parameter)
        {
            KeyBoardCl.ButtonD.IsEnabled = false;
            GuessLetter('D');


        }

        private void DisablebuttonF(object parameter)
        {
            KeyBoardCl.ButtonF.IsEnabled = false;
            GuessLetter('F');

        }

        private void DisablebuttonG(object parameter)
        {
            KeyBoardCl.ButtonG.IsEnabled = false;
            GuessLetter('G');

        }

        private void DisablebuttonH(object parameter)
        {
            KeyBoardCl.ButtonH.IsEnabled = false;
            GuessLetter('H');

        }

        private void DisablebuttonJ(object parameter)
        {
            KeyBoardCl.ButtonJ.IsEnabled = false;
            GuessLetter('J');

        }

        private void DisablebuttonK(object parameter)
        {
            KeyBoardCl.ButtonK.IsEnabled = false;
            GuessLetter('K');

        }
        private void DisablebuttonL(object parameter)
        {
            KeyBoardCl.ButtonL.IsEnabled = false;
            GuessLetter('L');

        }
        private void DisablebuttonZ(object parameter)
        {
            KeyBoardCl.ButtonZ.IsEnabled = false;
            GuessLetter('Z');

        }
        private void DisablebuttonX(object parameter)
        {
            KeyBoardCl.ButtonX.IsEnabled = false;
            GuessLetter('X');

        }
        private void DisablebuttonC(object parameter)
        {
            KeyBoardCl.ButtonC.IsEnabled = false;
            GuessLetter('C');

        }
        private void DisablebuttonV(object parameter)
        {
            KeyBoardCl.ButtonV.IsEnabled = false;
            GuessLetter('V');

        }
        private void DisablebuttonB(object parameter)
        {
            KeyBoardCl.ButtonB.IsEnabled = false;
            GuessLetter('B');

        }
        private void DisablebuttonN(object parameter)
        {
            KeyBoardCl.ButtonN.IsEnabled = false;
            GuessLetter('N');

        }
        private void DisablebuttonM(object parameter)
        {
            KeyBoardCl.ButtonM.IsEnabled = false;
            GuessLetter('M');

        }

        #endregion

        #region Private Commands

        private ICommand _disableButtonQ;
        private ICommand _disableButtonW;
        private ICommand _disableButtonE;
        private ICommand _disableButtonR;
        private ICommand _disableButtonT;
        private ICommand _disableButtonY;
        private ICommand _disableButtonU;
        private ICommand _disableButtonI;
        private ICommand _disableButtonO;
        private ICommand _disableButtonP;
        private ICommand _disableButtonA;
        private ICommand _disableButtonS;
        private ICommand _disableButtonD;
        private ICommand _disableButtonF;
        private ICommand _disableButtonG;
        private ICommand _disableButtonH;
        private ICommand _disableButtonJ;
        private ICommand _disableButtonK;
        private ICommand _disableButtonL;
        private ICommand _disableButtonZ;
        private ICommand _disableButtonX;
        private ICommand _disableButtonC;
        private ICommand _disableButtonV;
        private ICommand _disableButtonB;
        private ICommand _disableButtonN;
        private ICommand _disableButtonM;

#endregion

        #region Public Commands
        public ICommand DisableButtonQ
        {
            
            get {
                if (_disableButtonQ == null)
                {  _disableButtonQ = new RelayCommand(DisablebuttonQ);  }
                return _disableButtonQ;

            }    
        }

        public ICommand DisableButtonW
        {

            get
            {
                if (_disableButtonW == null)
                {  _disableButtonW = new RelayCommand(DisablebuttonW); }
                return _disableButtonW;
            }
        }

        public ICommand DisableButtonE
        {

            get
            {
                if (_disableButtonE == null)
                { _disableButtonE = new RelayCommand(DisablebuttonE); }
                return _disableButtonE;
            }
        }

        public ICommand DisableButtonR
        {

            get
            {
                if (_disableButtonR == null)
                {  _disableButtonR = new RelayCommand(DisablebuttonR);  }
                return _disableButtonR;
            }
        }

        public ICommand DisableButtonT
        {

            get
            {
                if (_disableButtonT == null)
                { _disableButtonT = new RelayCommand(DisablebuttonT); }
                return _disableButtonT;
            }
        }

        public ICommand DisableButtonY
        {

            get
            {
                if (_disableButtonY == null)
                { _disableButtonY = new RelayCommand(DisablebuttonY); }
                return _disableButtonY;
            }
        }

        public ICommand DisableButtonU
        {

            get
            {
                if (_disableButtonU == null)
                { _disableButtonU = new RelayCommand(DisablebuttonU); }
                return _disableButtonU;
            }
        }

        public ICommand DisableButtonI
        {

            get
            {
                if (_disableButtonI == null)
                { _disableButtonI = new RelayCommand(DisablebuttonI); }
                return _disableButtonI;
            }
        }

        public ICommand DisableButtonO
        {

            get
            {
                if (_disableButtonO == null)
                { _disableButtonO = new RelayCommand(DisablebuttonO); }
                return _disableButtonO;
            }
        }

        public ICommand DisableButtonP
        {

            get
            {
                if (_disableButtonP == null)
                { _disableButtonP = new RelayCommand(DisablebuttonP); }
                return _disableButtonP;
            }
        }

        public ICommand DisableButtonA
        {

            get
            {
                if (_disableButtonA == null)
                { _disableButtonA = new RelayCommand(DisablebuttonA); }
                return _disableButtonA;
            }
        }

        public ICommand DisableButtonS
        {

            get
            {
                if (_disableButtonS == null)
                { _disableButtonS = new RelayCommand(DisablebuttonS); }
                return _disableButtonS;
            }
        }

        public ICommand DisableButtonD
        {

            get
            {
                if (_disableButtonD == null)
                { _disableButtonD = new RelayCommand(DisablebuttonD); }
                return _disableButtonD;
            }
        }

        public ICommand DisableButtonF
        {

            get
            {
                if (_disableButtonF == null)
                { _disableButtonF = new RelayCommand(DisablebuttonF); }
                return _disableButtonF;
            }
        }

        public ICommand DisableButtonG
        {

            get
            {
                if (_disableButtonG == null)
                { _disableButtonG = new RelayCommand(DisablebuttonG); }
                return _disableButtonG;
            }
        }

        public ICommand DisableButtonH
        {

            get
            {
                if (_disableButtonH == null)
                { _disableButtonH = new RelayCommand(DisablebuttonH); }
                return _disableButtonH;
            }
        }

        public ICommand DisableButtonJ
        {

            get
            {
                if (_disableButtonJ == null)
                { _disableButtonJ = new RelayCommand(DisablebuttonJ); }
                return _disableButtonJ;
            }
        }

        public ICommand DisableButtonK
        {

            get
            {
                if (_disableButtonK == null)
                { _disableButtonK = new RelayCommand(DisablebuttonK); }
                return _disableButtonK;
            }
        }

        public ICommand DisableButtonL
        {

            get
            {
                if (_disableButtonL == null)
                { _disableButtonL = new RelayCommand(DisablebuttonL); }
                return _disableButtonL;
            }
        }

        public ICommand DisableButtonZ
        {

            get
            {
                if (_disableButtonZ == null)
                { _disableButtonZ = new RelayCommand(DisablebuttonZ); }
                return _disableButtonZ;
            }
        }

        public ICommand DisableButtonX
        {

            get
            {
                if (_disableButtonX == null)
                { _disableButtonX = new RelayCommand(DisablebuttonX); }
                return _disableButtonX;
            }
        }

        public ICommand DisableButtonC
        {

            get
            {
                if (_disableButtonC == null)
                { _disableButtonC = new RelayCommand(DisablebuttonC); }
                return _disableButtonC;
            }
        }

        public ICommand DisableButtonV
        {

            get
            {
                if (_disableButtonV == null)
                { _disableButtonV = new RelayCommand(DisablebuttonV); }
                return _disableButtonV;
            }
        }

        public ICommand DisableButtonB
        {

            get
            {
                if (_disableButtonB == null)
                { _disableButtonB = new RelayCommand(DisablebuttonB); }
                return _disableButtonB;
            }
        }

        public ICommand DisableButtonN
        {

            get
            {
                if (_disableButtonN == null)
                { _disableButtonN = new RelayCommand(DisablebuttonN); }
                return _disableButtonN;
            }
        }

        public ICommand DisableButtonM
        {

            get
            {
                if (_disableButtonM == null)
                { _disableButtonM = new RelayCommand(DisablebuttonM); }
                return _disableButtonM;
            }
        }

        #endregion

        #endregion


        public void UpdateGamesList()
        {
            DatabaseConnection database = new DatabaseConnection();
           var allgames= database.GetUserGames(User.Id);

            SavedGames = new ObservableCollection<Game>();
            FinishedGames = new ObservableCollection<Game>();

            for (int i=0; i<allgames.Count;i++)
                if (allgames[i].LivesLeft==0||allgames[i].Level==5)
                    FinishedGames.Add(allgames[i]);
            else SavedGames.Add(allgames[i]);

        }
        public void UpdateGameImage()
        {
           if (CurrentGame!=null)
            {
                int phase = CurrentGame.LivesLeft;

                switch (phase)
                {
                    case 0:
                        GamePhaseImage = "D:\\Proiecte WPF\\Hangman\\Hangman\\Pictures\\GamePhases\\hangman7.png";
                    break;

                    case 1:
                        GamePhaseImage = "D:\\Proiecte WPF\\Hangman\\Hangman\\Pictures\\GamePhases\\hangman6.png";
                        break;

                    case 2:
                        GamePhaseImage = "D:\\Proiecte WPF\\Hangman\\Hangman\\Pictures\\GamePhases\\hangman5.png";
                        break;

                    case 3:
                        GamePhaseImage = "D:\\Proiecte WPF\\Hangman\\Hangman\\Pictures\\GamePhases\\hangman4.png";
                        break;

                    case 4:
                        GamePhaseImage = "D:\\Proiecte WPF\\Hangman\\Hangman\\Pictures\\GamePhases\\hangman3.png";
                        break;

                    case 5:
                        GamePhaseImage = "D:\\Proiecte WPF\\Hangman\\Hangman\\Pictures\\GamePhases\\hangman2.png";
                        break;

                    case 6:
                        GamePhaseImage = "D:\\Proiecte WPF\\Hangman\\Hangman\\Pictures\\GamePhases\\hangman1.png";
                        break;
                        
                    default:
                        GamePhaseImage = "";
                        break;
                }

            }

        }
        public string GenerateRandomWord()
        {
            List<string> words = new List<string>();

            for (int i = 0; i < Categories.Count; i++)
                if (Categories[i].IsChecked == true) words.AddRange(Categories[i].Words);


            Random rd = new Random();
            int rand_num = rd.Next(0, words.Count);

            return words[rand_num].ToUpper();


        }

        public void NewGameFunc(object parameter)
        {

            
            KeyBoardCl.ResetKeys();

            RefreshCurrentCategories();

            if (CurrentCategories == "")
            {
                var dg = MessageBox.Show("Please select one or more categories first!");
            }
            else
            {
                CategoryEnable = false;
                List<int> categId = new List<int>();

                for (int i = 0; i < Categories.Count; i++)
                    if (Categories[i].IsChecked == true) categId.Add(Categories[i].Id);

                RefreshCurrentCategories();
                CurrentGame = new Game(User.Id, categId, CurrentCategories, GenerateRandomWord());
            
                UpdateGameImage();
            }
        }


        public void SaveGameFunc(object parameter)
        {
            if (CurrentGame!=null)
            {
                if (CurrentGame.Level==5||CurrentGame.LivesLeft==0)
                { var dg = MessageBox.Show("Cannot save a finished game!"); }
                else
                {
                    DatabaseConnection databaseConnection = new DatabaseConnection();

                    databaseConnection.UploadGameToDB(CurrentGame);

                    var dg = MessageBox.Show("The game has been saved!");

                    DialogResult result = MessageBox.Show("Do you want close the game now ?", "Confirmation", MessageBoxButtons.YesNoCancel);

                    if (result == DialogResult.Yes)
                    { CurrentGame = null; KeyBoardCl.ResetKeysFalse(); CategoryEnable = true; }
                   

                }

            }
            else { var dg = MessageBox.Show("No game in progress!"); }

            UpdateGamesList();
        }

        
        public void OpenGameFunc(object parameter)
        {
            UpdateGamesList();
            LoadGame load = new LoadGame();

            load.DataContext = new LoadGameViewModel(SavedGames);
            load.ShowDialog();

            if (GLOBALS.loadGameIndex!=-1)
            {
                CurrentGame = SavedGames[GLOBALS.loadGameIndex];
                GLOBALS.loadGameIndex = -1;
                KeyBoardCl.ResetKeys();
                UpdateGameImage();

                CurrentCategories = CurrentGame.CategoryName;
                CategoryEnable = false;

            }
           
        }

       


        public void GuessLetter(char letter)
        {

            if (CurrentGame !=null)
            {
                string word = CurrentGame.Word;


                if (word.Contains(letter) && !CurrentGame.GuessedWord.ToString().Contains(letter))
                {
                    int nrLitereWor = -1;
                    for (int i = 0; i < word.Length; i++)
                    {
                        if (word[i] != ' ') nrLitereWor++;

                        if (word[i] == letter)
                        {
                            int nrDe_ = -1;
                            for (int j = 0; j < CurrentGame.GuessedWord.Length; j++)
                            {
                                if (CurrentGame.GuessedWord[j] != ' ') nrDe_++;

                                if (nrDe_ == nrLitereWor)
                                {
                                    CurrentGame.GuessedWord[j] = letter;
                                    break;
                                }
                            }

                        }
                    }
                    CurrentGame.GuessedWord = new StringBuilder(CurrentGame.GuessedWord.ToString());

                    if (!CurrentGame.GuessedWord.ToString().Contains('_'))
                    {

                        CurrentGame.Level++;
                        CurrentGame.LivesLeft = 6;
                        if (CurrentGame.Level>=5)
                        {
                            KeyBoardCl.ResetKeysFalse();
                            var dg = MessageBox.Show("Congrats, you won!");
                            CategoryEnable = true;
                            DatabaseConnection database = new DatabaseConnection();
                            database.UploadGameToDB(CurrentGame);
                            database.UpdateStatistics(User, CurrentGame.CategoryName,true);
                        }
                        else
                        {
                            CurrentGame.Word=GenerateRandomWord();
                            CurrentGame.GenerateGuessedWord(CurrentGame.Word);
                            KeyBoardCl.ResetKeys();
                            UpdateGameImage();


                        }


                    }
                }
                else
                {
                    CurrentGame.LivesLeft--;

                    UpdateGameImage();

                    if (CurrentGame.LivesLeft <= 0) { var dg = MessageBox.Show(string.Format("You lost, the word was {0}!", CurrentGame.Word));
                        KeyBoardCl.ResetKeysFalse();
                        CategoryEnable = true;
                        DatabaseConnection database = new DatabaseConnection();
                        database.UploadGameToDB(CurrentGame);
                        database.UpdateStatistics(User, CurrentGame.CategoryName, false);

                    }

                }

            }
        }



        private ICommand _newGame;
        private ICommand _saveGame;
        private ICommand _openGame;
        

        
        public ICommand OpenGame
        {
            get
            {
                if (_openGame == null)
                { _openGame = new RelayCommand(OpenGameFunc); }
                return _openGame;
            }

        }
        public ICommand NewGame
        {
            get {
                if (_newGame == null)
                { _newGame = new RelayCommand(NewGameFunc); }
                return _newGame;
            }


        }
         
        public ICommand SaveGame
        {
            get
            {
                if (_saveGame == null)
                { _saveGame = new RelayCommand(SaveGameFunc); }
                return _saveGame;
            }
        }

        

        public void RefreshCurrentCategories()
        {
            CurrentCategories = "";

            for (int i = 0; i < Categories.Count; i++)
                if (Categories[i].IsChecked == true) CurrentCategories += Categories[i].CategoryName+",";
           if (CurrentCategories!="") CurrentCategories = CurrentCategories.Substring(0,CurrentCategories.Length-1);
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;

            if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));


        }
    }
}
