using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hangman.Models
{
    public class Game:INotifyPropertyChanged
    {

        private int _gameId;
        private string _name;
        private int _userId;
        private int _timeLeft;
        private int _livesLeft;
        private string _categoryName;
        private List<int> _categoryId;
        private int _level;
        private string _word;
        private StringBuilder _guessedWord;

        public int GameId { get { return _gameId; } set { _gameId = value; } }
        public string Name { get { return _name;} set { _name = value; } }
        
        public int UserId { get { return _userId; } set { _userId = value; } }
        
        public int TimeLeft { get { return _timeLeft;} set { _timeLeft = value; } }

        public int LivesLeft { get { return _livesLeft; } set { _livesLeft = value; } }

        public string CategoryName { get { return _categoryName; } set { _categoryName = value; } }

        public List<int> CategoryId { get { return _categoryId; } set { _categoryId = value; } }

        public int Level { get { return _level; } set { _level = value; OnPropertyChanged("Level"); } }

        public string Word { get { return _word; } set { _word = value;  } } 

        public StringBuilder GuessedWord { get { return _guessedWord; } set { _guessedWord = value; OnPropertyChanged("GuessedWord"); } }

        public void GenerateGuessedWord(string word)
        {
            GuessedWord = new StringBuilder();
            for (int i = 0; i < word.Length; i++)
            {
                if (word[i] != ' ') GuessedWord.Append('_');
                else GuessedWord.Append(' ');

                GuessedWord.Append(' ');
            }

        }
        public Game(int userId,List<int> category, string categoryName, string word)
        {
            
            Name ="Game "+DateTime.Now.ToString();
            UserId=userId;
            TimeLeft = 60;
            LivesLeft = 6;
            CategoryId = category;
            CategoryName = categoryName;
            Level = 0;
            Word = word; ;
            Word=Word.ToUpper();

            GenerateGuessedWord(word);
            
        }
        public Game(int gameId, int userId, int timeLeft, int livesLeft,int gameLevel,string word,string guessedWord, string categoryName,string name)
        {
            GameId=gameId;
            UserId = userId;
            LivesLeft=livesLeft;
            Level=gameLevel;
            Word=word;
            GuessedWord = new StringBuilder(guessedWord);
            CategoryName=categoryName;
            TimeLeft=timeLeft;
            Name=name;

        }


        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;

            if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));


        }
    }
}
