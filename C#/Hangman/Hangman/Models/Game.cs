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
        private float _timeLeft;
        private int _livesLeft;
        private string _categoryName;
        private int _categoryId;
        private int _level;
        private string _word;
        private string _guessedWord;

        public int GameId { get { return _gameId; } set { _gameId = value; } }
        public string Name { get { return _name;} set { _name = value; } }
        
        public int UserId { get { return _userId; } set { _userId = value; } }
        
        public float TimeLeft { get { return _timeLeft;} set { _timeLeft = value; } }

        public int LivesLeft { get { return _livesLeft; } set { _livesLeft = value; } }

        public string CategoryName { get { return _categoryName; } set { _categoryName = value; } }

        public int CategoryId { get { return _categoryId; } set { _categoryId = value; } }

        public int Level { get { return _level; } set { _level = value; } }

        public string Word { get { return _word; } set { _word = value; } } 

        public string GuessedWord { get { return _guessedWord; } set { _guessedWord = value;} }






        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;

            if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));


        }
    }
}
