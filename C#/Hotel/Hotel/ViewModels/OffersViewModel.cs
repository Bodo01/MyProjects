using Hotel.Models;
using Hotel.Models.BusinessLogicLayer;
using Hotel.Tools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace Hotel.ViewModels
{
    internal class OffersViewModel:NotifyProp
    {

        private User _user;
        private ICollection<Package> offersList;
        private Package _currentPackage;
        private int index;
        private bool enabled;
        
        public bool Enabled
        {

            get { return enabled; }
            set { enabled = value; OnPropertyChanged("Enabled"); }
        }

        public int Index
        {
            get { return index; }
            set { index = value; OnPropertyChanged("Index"); }

        }

        public Package CurrentPackage
        {
            get { return _currentPackage; }
            set { _currentPackage = value; OnPropertyChanged("CurrentPackage"); }
        }

        public ICollection<Package> OffersList
        {
            get { return offersList; }
            set { offersList = value; OnPropertyChanged("OffersList"); }
        }
        public OffersViewModel(User user)
        { 
            if(user == null||user.user_type>0)
                enabled = false;
            else enabled = true;

            _user = user;

            offersList = new List<Package>();

            HotelEntities context = new HotelEntities();

            var auxOffers = context.Packages.ToList();

           
                


            foreach (var aux in auxOffers)
            {
                var BeginDate = aux.start_date;
                var EndDate = aux.end_date;

                var reservations = context.Reservations.Where(s => (s.start_date <= BeginDate && BeginDate <= s.end_date) || (s.start_date <= EndDate && EndDate <= s.end_date) || (s.start_date >= BeginDate && EndDate >= s.end_date)).ToList();


                RoomTypeBLL room = new RoomTypeBLL();

                var roomTypes = room.GetAllRoomTypes();

               var availableRooms = new Dictionary<int, int>(roomTypes.Count);

                foreach (var roomType in roomTypes)
                {
                    availableRooms.Add(roomType.id, roomType.Rooms.Count);
                }

                foreach (var reservation in reservations)
                {
                    foreach (var reservationRoom in reservation.ReservationRooms)
                    {
                        availableRooms[(int)reservationRoom.room_type] = availableRooms[(int)reservationRoom.room_type] - (int)reservationRoom.quantity;
                    }

                }



               var availableRoomTypes = new List<RoomType>();

                foreach (var roomType in roomTypes)
                {
                    if (availableRooms[roomType.id] != 0&&roomType.id==aux.room_type) availableRoomTypes.Add(roomType);
                }

                if(availableRoomTypes.Count != 0)
                    offersList.Add(aux);
            }

            if (OffersList.Count != 0)
                CurrentPackage = OffersList.ToList()[0];
            else MessageBox.Show("No packages available at the moment! ");
        }

        private void LoadCommand(object parameter)
        {
            var newRes = new Reservation();

            newRes.price = CurrentPackage.price;
            newRes.start_date = CurrentPackage.start_date;
            newRes.end_date = CurrentPackage.end_date;
            newRes.client_id = _user.id;
            newRes.status = 0;
            newRes.deleted = false;
            
            foreach(var aux in CurrentPackage.PackagesOptions)
            {
                var newOpt = new ReservationOption();

                newOpt.option_id=aux.option_id;
                newOpt.deleted = false;

                newRes.ReservationOptions.Add(newOpt);

            }

            var newResRoom = new ReservationRoom();

            newResRoom.room_type = CurrentPackage.room_type;
            newResRoom.quantity = 1;
            newResRoom.deleted = false;

            newRes.ReservationRooms.Add(newResRoom);

            HotelEntities context = new HotelEntities();

            context.Reservations.Add(newRes);
            context.SaveChanges();

            MessageBox.Show("Order placed!");

        }

        private ICommand loadOffer;

        public ICommand LoadOffer
        {
            get {
                loadOffer = new RelayCommand(LoadCommand);
                return loadOffer; }
        }
    }
}
