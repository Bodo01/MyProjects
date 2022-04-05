using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hangman.Models
{
    internal class KeyBoardCls:INotifyPropertyChanged
    {
        #region Buttons Private
        private ButtonKey _buttonQ;
        private ButtonKey _buttonW;
        private ButtonKey _buttonE;
        private ButtonKey _buttonR;
        private ButtonKey _buttonT;
        private ButtonKey _buttonY;
        private ButtonKey _buttonU;
        private ButtonKey _buttonI;
        private ButtonKey _buttonO;
        private ButtonKey _buttonP;
        private ButtonKey _buttonA;
        private ButtonKey _buttonS;
        private ButtonKey _buttonD;
        private ButtonKey _buttonF;
        private ButtonKey _buttonG;
        private ButtonKey _buttonH;
        private ButtonKey _buttonJ;
        private ButtonKey _buttonK;
        private ButtonKey _buttonL;
        private ButtonKey _buttonZ;
        private ButtonKey _buttonX;
        private ButtonKey _buttonC;
        private ButtonKey _buttonV;
        private ButtonKey _buttonB;
        private ButtonKey _buttonN;
        private ButtonKey _buttonM;
        #endregion

        #region Buttons Public

        public ButtonKey ButtonQ { get { return _buttonQ; } set { _buttonQ = value; OnPropertyChanged("ButtonQ"); } }
        public ButtonKey ButtonW { get { return _buttonW; } set { _buttonW = value; OnPropertyChanged("ButtonW"); } }
        public ButtonKey ButtonE { get { return _buttonE; } set { _buttonE = value; OnPropertyChanged("ButtonE"); } }
        public ButtonKey ButtonR { get { return _buttonR; } set { _buttonR = value; OnPropertyChanged("ButtonR"); } }
        public ButtonKey ButtonT { get { return _buttonT; } set { _buttonT = value; OnPropertyChanged("ButtonT"); } }
        public ButtonKey ButtonY { get { return _buttonY; } set { _buttonY = value; OnPropertyChanged("ButtonY"); } }
        public ButtonKey ButtonU { get { return _buttonU; } set { _buttonU = value; OnPropertyChanged("ButtonU"); } }
        public ButtonKey ButtonI { get { return _buttonI; } set { _buttonI = value; OnPropertyChanged("ButtonI"); } }
        public ButtonKey ButtonO { get { return _buttonO; } set { _buttonO = value; OnPropertyChanged("ButtonO"); } }
        public ButtonKey ButtonP { get { return _buttonP; } set { _buttonP = value; OnPropertyChanged("ButtonP"); } }
        public ButtonKey ButtonA { get { return _buttonA; } set { _buttonA = value; OnPropertyChanged("ButtonA"); } }
        public ButtonKey ButtonS { get { return _buttonS; } set { _buttonS = value; OnPropertyChanged("ButtonS"); } }
        public ButtonKey ButtonD { get { return _buttonD; } set { _buttonD = value; OnPropertyChanged("ButtonD"); } }
        public ButtonKey ButtonF { get { return _buttonF; } set { _buttonF = value; OnPropertyChanged("ButtonF"); } }
        public ButtonKey ButtonG { get { return _buttonG; } set { _buttonG = value; OnPropertyChanged("ButtonG"); } }
        public ButtonKey ButtonH { get { return _buttonH; } set { _buttonH = value; OnPropertyChanged("ButtonH"); } }
        public ButtonKey ButtonJ { get { return _buttonJ; } set { _buttonJ = value; OnPropertyChanged("ButtonJ"); } }
        public ButtonKey ButtonK { get { return _buttonK; } set { _buttonK = value; OnPropertyChanged("ButtonK"); } }
        public ButtonKey ButtonL { get { return _buttonL; } set { _buttonL = value; OnPropertyChanged("ButtonL"); } }
        public ButtonKey ButtonZ { get { return _buttonZ; } set { _buttonZ = value; OnPropertyChanged("ButtonZ"); } }
        public ButtonKey ButtonX { get { return _buttonX; } set { _buttonX = value; OnPropertyChanged("ButtonX"); } }
        public ButtonKey ButtonC { get { return _buttonC; } set { _buttonC = value; OnPropertyChanged("ButtonC"); } }
        public ButtonKey ButtonV { get { return _buttonV; } set { _buttonV = value; OnPropertyChanged("ButtonV"); } }
        public ButtonKey ButtonB { get { return _buttonB; } set { _buttonB = value; OnPropertyChanged("ButtonB"); } }
        public ButtonKey ButtonN { get { return _buttonN; } set { _buttonN = value; OnPropertyChanged("ButtonN"); } }
        public ButtonKey ButtonM { get { return _buttonM; } set { _buttonM = value; OnPropertyChanged("ButtonM"); } }



        #endregion

        
        public KeyBoardCls()
        {
            ButtonQ = new ButtonKey("Q");
            ButtonW = new ButtonKey("W");
            ButtonE = new ButtonKey("E");
            ButtonR = new ButtonKey("R");
            ButtonT = new ButtonKey("T");
            ButtonY = new ButtonKey("Y");
            ButtonU = new ButtonKey("U");
            ButtonI = new ButtonKey("I");
            ButtonO = new ButtonKey("O");
            ButtonP = new ButtonKey("P");
            ButtonA = new ButtonKey("A");
            ButtonS = new ButtonKey("S");
            ButtonD = new ButtonKey("D");
            ButtonF = new ButtonKey("F");
            ButtonG = new ButtonKey("G");
            ButtonH = new ButtonKey("H");
            ButtonJ = new ButtonKey("J");
            ButtonK = new ButtonKey("K");
            ButtonL = new ButtonKey("L");
            ButtonZ = new ButtonKey("Z");
            ButtonX = new ButtonKey("X");
            ButtonC = new ButtonKey("C");
            ButtonV = new ButtonKey("V");
            ButtonB = new ButtonKey("B");
            ButtonN = new ButtonKey("N");
            ButtonM = new ButtonKey("M");

        }

        public void ResetKeys()
        {
            ButtonQ.IsEnabled = true;
            ButtonW.IsEnabled = true;
            ButtonE.IsEnabled = true;
            ButtonR.IsEnabled = true;
            ButtonT.IsEnabled = true;
            ButtonY.IsEnabled = true;
            ButtonU.IsEnabled = true;
            ButtonI.IsEnabled = true;
            ButtonO.IsEnabled = true;
            ButtonP.IsEnabled = true;
            ButtonA.IsEnabled = true;
            ButtonS.IsEnabled = true;
            ButtonD.IsEnabled = true;
            ButtonF.IsEnabled = true;
            ButtonG.IsEnabled = true;
            ButtonH.IsEnabled = true;
            ButtonJ.IsEnabled = true;
            ButtonK.IsEnabled = true;
            ButtonL.IsEnabled = true;
            ButtonZ.IsEnabled = true;
            ButtonX.IsEnabled = true;
            ButtonC.IsEnabled = true;
            ButtonV.IsEnabled = true;
            ButtonB.IsEnabled = true;
            ButtonN.IsEnabled = true;
            ButtonM.IsEnabled = true;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;

            if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));


        }
    }
}
