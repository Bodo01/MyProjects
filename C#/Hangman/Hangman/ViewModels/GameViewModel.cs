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


        private User _user;
        private KeyBoardCls _keyBoard;

        public KeyBoardCls KeyBoardCl
        {
            get { return _keyBoard; }
            set { _keyBoard = value; OnPropertyChanged("KeyBoard"); }
        }


        

        public User User { get { return _user; } set { _user = value; } }



        public GameViewModel(User user)
        {
            User = user;
            KeyBoardCl = new KeyBoardCls();

        }


        #region KeyBoard Functioning

        #region Commands for ICommand
        private void DisablebuttonQ(object parameter)
        {               
              KeyBoardCl.ButtonQ.IsEnabled = false;       
        }
        private void DisablebuttonW(object parameter)
        {
            KeyBoardCl.ButtonW.IsEnabled = false;
        }
        private void DisablebuttonE(object parameter)
        {
            KeyBoardCl.ButtonE.IsEnabled = false;
        }
        private void DisablebuttonR(object parameter)
        {
            KeyBoardCl.ButtonR.IsEnabled = false;

        }
        private void DisablebuttonT(object parameter)
        {
            KeyBoardCl.ButtonT.IsEnabled = false;

        }
        private void DisablebuttonY(object parameter)
        {
            KeyBoardCl.ButtonY.IsEnabled = false;

        }
        private void DisablebuttonU(object parameter)
        {
            KeyBoardCl.ButtonU.IsEnabled = false;

        }
        private void DisablebuttonI(object parameter)
        {
            KeyBoardCl.ButtonI.IsEnabled = false;

        }
        private void DisablebuttonO(object parameter)
        {
            KeyBoardCl.ButtonO.IsEnabled = false;

        }
        private void DisablebuttonP(object parameter)
        {
            KeyBoardCl.ButtonP.IsEnabled = false;

        }
        private void DisablebuttonA(object parameter)
        {
            KeyBoardCl.ButtonA.IsEnabled = false;

        }
        private void DisablebuttonS(object parameter)
        {
            KeyBoardCl.ButtonS.IsEnabled = false;

        }
        private void DisablebuttonD(object parameter)
        {
            KeyBoardCl.ButtonD.IsEnabled = false;


        }

        private void DisablebuttonF(object parameter)
        {
            KeyBoardCl.ButtonF.IsEnabled = false;

        }

        private void DisablebuttonG(object parameter)
        {
            KeyBoardCl.ButtonG.IsEnabled = false;

        }

        private void DisablebuttonH(object parameter)
        {
            KeyBoardCl.ButtonH.IsEnabled = false;

        }

        private void DisablebuttonJ(object parameter)
        {
            KeyBoardCl.ButtonJ.IsEnabled = false;

        }

        private void DisablebuttonK(object parameter)
        {
            KeyBoardCl.ButtonK.IsEnabled = false;

        }
        private void DisablebuttonL(object parameter)
        {
            KeyBoardCl.ButtonL.IsEnabled = false;

        }
        private void DisablebuttonZ(object parameter)
        {
            KeyBoardCl.ButtonZ.IsEnabled = false;

        }
        private void DisablebuttonX(object parameter)
        {
            KeyBoardCl.ButtonX.IsEnabled = false;

        }
        private void DisablebuttonC(object parameter)
        {
            KeyBoardCl.ButtonC.IsEnabled = false;

        }
        private void DisablebuttonV(object parameter)
        {
            KeyBoardCl.ButtonV.IsEnabled = false;

        }
        private void DisablebuttonB(object parameter)
        {
            KeyBoardCl.ButtonB.IsEnabled = false;

        }
        private void DisablebuttonN(object parameter)
        {
            KeyBoardCl.ButtonN.IsEnabled = false;

        }
        private void DisablebuttonM(object parameter)
        {
            KeyBoardCl.ButtonM.IsEnabled = false;

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


        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;

            if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));


        }
    }
}
