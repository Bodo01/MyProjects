using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hotel.Models;
using Hotel.Tools;
using Hotel.Models.BusinessLogicLayer;
using System.Windows;
using System.Windows.Input;
using System.Collections.ObjectModel;

namespace Hotel.ViewModels
{
    internal class NewReservationViewModel:NotifyProp
    {
        

        private DateTime beginDate;
        private DateTime endDate;
        private User _user;
        private Dictionary<int, int> availableRooms;
        private Dictionary<int, float> roomPrices;
        private List<RoomType> availableRoomTypes;
        private int index;
        private int currentNumberOfRooms;
        private int selectedNumberOfRooms;
        private ObservableCollection<Tuple<RoomType, int>> cart;
        private ObservableCollection<ExtraOption> extraOptions;
        private ObservableCollection<ExtraOption> extraOptionsInCart;
        private float total;
        private int indexOfOption;
        private float currentPrice;
        
        private bool guestMode;
        private string guestMode2;

        public string GuestMode2
        {
            get { return guestMode2; }
            set { guestMode2 = value; OnPropertyChanged("GuestMode2"); }
        }

        public bool GuestMode
        {
            get { return guestMode; }
            set { guestMode = value; OnPropertyChanged("GuestMode"); }

        }
        public float CurrentPrice
        {
            get { return currentPrice; }
            set { currentPrice = value; OnPropertyChanged("CurrentPrice"); }
        }

        public int IndexOfOption
        {
            get
            { return indexOfOption; }
            set { indexOfOption = value; OnPropertyChanged("IndexOfOption"); }
        }

        public float Total
        {
            get { return total; }
            set { total = value; OnPropertyChanged("Total"); }
        }

        public ObservableCollection<ExtraOption> ExtraOptions
        {

            get { return extraOptions; }
            set { extraOptions = value; OnPropertyChanged("ExtraOptions"); }
        }

        public ObservableCollection<ExtraOption> ExtraOptionsInCart
        {

            get { return extraOptionsInCart; }
            set { extraOptionsInCart = value; OnPropertyChanged("ExtraOptionsInCart"); }
       
        }
        public ObservableCollection<Tuple<RoomType,int>> Cart
        {
            get { return cart; }
            set { cart = value; OnPropertyChanged("Cart"); }

        }
        public int CurrentNumberOfRooms
        {
            get { return currentNumberOfRooms; }
            set { currentNumberOfRooms = value; OnPropertyChanged("CurrentNumberOfRooms"); }
        }

        public int SelectedNumberOfRooms
        {
            get { return selectedNumberOfRooms; }
            set {selectedNumberOfRooms = value; OnPropertyChanged("SelectedNumberOfRooms"); }
        }

        private RoomType currentRoom;

        public RoomType CurrentRoom
        {
            get { return currentRoom; }
            set { currentRoom = value; OnPropertyChanged("CurrentRoom"); }
        }

        public DateTime BeginDate
        {
            get { return beginDate; }
            set { beginDate = value; OnPropertyChanged("BeginDate"); }
        }

        public DateTime EndDate
        {
            get { return endDate; }
            set { endDate = value; OnPropertyChanged("EndDate"); }
        }

        public NewReservationViewModel(User user, DateTime begin, DateTime end)
        {
            HotelEntities context = new HotelEntities();
            #region update all reservations


            var reservUpdate = context.Reservations;

            foreach (var reservation in reservUpdate)
            {
                if (reservation.start_date <= DateTime.Now && reservation.status == 1)
                    reservation.status = 2;
                if (reservation.start_date <= DateTime.Now && reservation.status == 0)
                    reservation.status = 3;

            }

            context.SaveChanges();
            #endregion


            if (user == null||user.user_type>0)
            {
                GuestMode = false;
                GuestMode2 = "Logged in as guest, can't \nplace an order!";
            }
            else
            {
                GuestMode = true;
                GuestMode2 = "";
            }

            ExtraOptionsInCart = new ObservableCollection<ExtraOption>();
            Cart = new ObservableCollection<Tuple<RoomType, int>>();

            Total = 0;

            _user = user;
            BeginDate = begin;
            EndDate = end;

            currentRoom = null;

           // HotelEntities context = new HotelEntities();
            var reservations = context.Reservations.Where(s=> ((s.status<=1||s.status==2)&& (s.start_date <= BeginDate && BeginDate <=s.end_date) || ( s.start_date <= EndDate && EndDate <= s.end_date)|| (s.start_date >= BeginDate && EndDate >= s.end_date))).ToList();

            ExtraOptions = new ObservableCollection<ExtraOption>();

            var auxOptions = context.ExtraOptions.ToList();

            foreach(var option in auxOptions)
                ExtraOptions.Add(option);
            

            RoomTypeBLL room = new RoomTypeBLL();

            var roomTypes=room.GetAllRoomTypes();

            availableRooms= new Dictionary<int, int>(roomTypes.Count);

            foreach (var roomType in roomTypes)
            {
                availableRooms.Add(roomType.id, roomType.Rooms.Count);
            }

            foreach(var reservation in reservations)
            {
                foreach(var reservationRoom in reservation.ReservationRooms)
                {
                    availableRooms[(int)reservationRoom.room_type] = availableRooms[(int)reservationRoom.room_type] - (int)reservationRoom.quantity;
                }

            }

            

            availableRoomTypes = new List<RoomType>();

            foreach(var roomType in roomTypes)
            {
                if (availableRooms[roomType.id] != 0) availableRoomTypes.Add(roomType);
            }

            if (availableRoomTypes.Count == 0) MessageBox.Show("NO ROOMS FOUND IN THE SELECTED TIME PERIOD!");
            else
            {
                CurrentRoom = availableRoomTypes[0];

                index = 0;

                CurrentNumberOfRooms = availableRooms[availableRoomTypes[0].id];

                var roomPrices2 = context.RoomPrices.Where(s => (s.start_date <= BeginDate.Date && BeginDate.Date <= s.end_date) || (s.start_date <= EndDate && EndDate <= s.end_date) || (s.start_date >= BeginDate && EndDate >= s.end_date)).ToList();

                roomPrices = new Dictionary<int, float>();

                foreach (var aux in availableRooms)
                {
                    roomPrices.Add(aux.Key, 0);
                }


                    foreach (var aux in availableRooms)
                {
                    for(DateTime i= BeginDate; EndDate.CompareTo(i)>=0; i= i.AddDays(1.0))
                    {
                        foreach(var price in roomPrices2)
                        {
                            if (price.room_type == aux.Key)
                                if (price.start_date.Value.Date <= i.Date && price.end_date.Value.Date >= i.Date) { roomPrices[aux.Key] += (float)price.price; break; }
                        }
                    }

                }

                CurrentPrice = roomPrices[CurrentRoom.id];
            }



        }

        private void Next(object parameter)
        {
            if (index < availableRoomTypes.Count - 1) index++;

            CurrentRoom = availableRoomTypes[index];

            CurrentNumberOfRooms = availableRooms[availableRoomTypes[index].id];

            CurrentPrice = roomPrices[CurrentRoom.id];
        }

        private void Prev(object parameter)
        {
            if (index > 0) index--;

            CurrentRoom = availableRoomTypes[index];

            CurrentNumberOfRooms = availableRooms[availableRoomTypes[index].id];

            CurrentPrice = roomPrices[CurrentRoom.id];
        }

        private void AddToCartCommand(object parameter)
        { if (SelectedNumberOfRooms != 0)
            {
                if (SelectedNumberOfRooms <= availableRooms[currentRoom.id])
                {
                    Tuple<RoomType, int> aux = null;
                    int i = 0;
                    int? j = null;
                    foreach (var tuple in Cart)
                    {

                        if (currentRoom.id == tuple.Item1.id)
                        {
                            aux = new Tuple<RoomType, int>(tuple.Item1, tuple.Item2 + SelectedNumberOfRooms);
                            j = i;
                        }
                        i++;
                    }
                    //Complicatie inutila :)
                    if (j != null) Cart[(int)j] = aux;
                    else
                        Cart.Add(new Tuple<RoomType, int>(CurrentRoom, SelectedNumberOfRooms));

                    availableRooms[currentRoom.id] -= SelectedNumberOfRooms;
                    CurrentNumberOfRooms -= SelectedNumberOfRooms;

                    Total += roomPrices[currentRoom.id] * SelectedNumberOfRooms;
                }
                else MessageBox.Show("No more rooms left of this kind!");
            }
        }

        private void AddToCartOptionCommand(object parameter)
        {
            foreach(var aux in ExtraOptionsInCart)
            {
                if(aux.id==ExtraOptions[indexOfOption].id)
                {
                    MessageBox.Show("This option is already added!");
                    return;
                }
            }

            ExtraOptionsInCart.Add(ExtraOptions[IndexOfOption]);
            Total += (float)ExtraOptions[IndexOfOption].price;
        }

        private void PlaceReserv(object parameter)
        {
            HotelEntities context = new HotelEntities();

                     
            

            var newRes = new Reservation();
            newRes.client_id =_user.id;
            newRes.price = Total;
            newRes.end_date = EndDate;
            newRes.start_date = BeginDate;
            newRes.status = 0;
            newRes.deleted = false;
            
            

            
            foreach (var aux in Cart)
            {
                var newRoomRes = new ReservationRoom();

                newRoomRes.deleted = false;
                newRoomRes.room_type = aux.Item1.id;
                newRoomRes.quantity = aux.Item2;
            
               newRes.ReservationRooms.Add(newRoomRes);
            
            }

            foreach(var aux in ExtraOptionsInCart)

            {
                var newOption = new ReservationOption();

                newOption.option_id = aux.id;
                newOption.deleted = false;

                newRes.ReservationOptions.Add(newOption);

            }


            context.Reservations.Add(newRes);
            context.SaveChanges();

            MessageBox.Show("Order placed!");
        }

        private ICommand m_nextRoom;
        private ICommand m_prevRoom;
        private ICommand m_addToCart;
        private ICommand m_addToCartOption;
        private ICommand m_placeReservation;


        public ICommand PlaceReservation
        {
            get
            {
                m_placeReservation = new RelayCommand(PlaceReserv);
                return m_placeReservation;

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

        public ICommand AddToCart
        {
            get
            {
                m_addToCart = new RelayCommand(AddToCartCommand);
                return m_addToCart;

            }

        }

        public ICommand AddToCartOption
        {
            get
            {
                m_addToCartOption = new RelayCommand(AddToCartOptionCommand);
                return m_addToCartOption;

            }

        }
    }
}
