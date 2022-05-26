using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hotel.Models.BusinessLogicLayer;
using Hotel.Models;
using Hotel.Tools;
using System.Collections.ObjectModel;
using System.Windows.Input;
using System.Windows;
using Hotel.Views;

namespace Hotel.ViewModels
{
    internal class RoomViewModel:NotifyProp
    {
        private Visibility adminMode;

        public Visibility AdminMode
        {
            get { return adminMode; }
            set { adminMode = value; OnPropertyChanged("AdminMode"); }
        }



       private RoomTypeBLL roomTypeBll;

       private ObservableCollection<RoomType> roomList;

        private EnhancedRoomType enhanced;

        public EnhancedRoomType Enhanced
        {
            get { return enhanced; }
            set { enhanced = value; OnPropertyChanged("Enhanced"); }
        }

        private RoomType currentRoom;

        private int index;
        public RoomType CurrentRoom
        {
            get { return currentRoom; }
            set { currentRoom = value; OnPropertyChanged("CurrentRoom"); }
        }
         public ObservableCollection<RoomType> RoomList
        {
            get { return roomList; }
            set { roomList = value; OnPropertyChanged("RoomList"); }
        }

        
        public RoomViewModel(User user)
        {
            Enhanced = new EnhancedRoomType();

            AdminMode = Visibility.Hidden;
             index = 0;
            if(user != null)
            if(user.user_type==2)
                AdminMode = Visibility.Visible;
            
             roomTypeBll = new RoomTypeBLL();
            RoomList = roomTypeBll.GetAllRoomTypes();
            if (RoomList.Count != 0)
            {
                CurrentRoom = RoomList[index];
                Enhanced.CurrentRoom = CurrentRoom;
            }

            else
            {
                MessageBox.Show("there are no rooms!");
                
            }
        }

        private void Next(object parameter)
        {
            if (index < RoomList.Count - 1) index++;

            CurrentRoom = RoomList[index];
            Enhanced.CurrentRoom = CurrentRoom;

        }

        private void Prev(object parameter)
        {
            if (index > 0) index--;

            CurrentRoom = RoomList[index];
            Enhanced.CurrentRoom = CurrentRoom;

        }

        private string newRoomName;

        public string NewRoomName
        {
                get { return newRoomName; }
            set { newRoomName = value; OnPropertyChanged("NewRoomName"); }
        }
        private void NewRoomCommand(object parameter)
        {
            if (NewRoomName != "")
            {


                var room = new RoomType();
                room.name = NewRoomName;

                roomTypeBll.AddMethod(room);

                newRoomName = "";
                MessageBox.Show("Room succesfully added!");
                roomList = roomTypeBll.GetAllRoomTypes();
            }
            else MessageBox.Show("Please insert a name");
            
        }

        private void ModifyRoomCommand(object parameter)
        {
            ModifyRoom modifyRoomView = new ModifyRoom();
            modifyRoomView.DataContext =new  ModifyRoomVM(CurrentRoom);
            modifyRoomView.Show();

        }

        private void DeleteRoomCommand(object parameter)
        {
            HotelEntities context = new HotelEntities();

            var aux = context.RoomTypes.FirstOrDefault(s=>(CurrentRoom.id==s.id));

            aux.deleted = true;

            context.SaveChanges();

            RoomList.Remove(CurrentRoom);

            CurrentRoom = RoomList[0];

        }

        private ICommand m_nextRoom;
        private ICommand m_prevRoom;
        private ICommand m_newRoom;
        private ICommand m_ModifyRoom;
        private ICommand m_deleteRoom;


        public ICommand DeleteRoom
        {
            get
            {
                m_deleteRoom = new RelayCommand(DeleteRoomCommand);
                return m_deleteRoom;
            }
        }
        public ICommand ModifyRoom
        {
            get {
                m_ModifyRoom = new RelayCommand(ModifyRoomCommand);
                return m_ModifyRoom; }
        }
        public ICommand NewRoom
        {

            get
            {
                m_newRoom = new RelayCommand(NewRoomCommand);
                return m_newRoom;
            }

        }

        public ICommand NextRoom
        {
            get
            {
                m_nextRoom = new RelayCommand(Next);
                return m_nextRoom;

            }

        }

        public ICommand PrevRoom
        {
            get
            {
                m_prevRoom = new RelayCommand(Prev);
                return m_prevRoom;

            }

        }
    }
}
