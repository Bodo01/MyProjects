using Hotel.Models;
using Hotel.Tools;
using Hotel.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;

namespace Hotel.ViewModels
{
    internal class ClientViewModel:NotifyProp
    {

       private DateTime beginDate;
       private DateTime endDate;
        public ICollection<HotelService> Services { get; set; }
       
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

        public ClientViewModel()
        {
            BeginDate = DateTime.Now;
            EndDate = DateTime.Now;
        }

        private User _user;
        public ClientViewModel(User user)
        {
            BeginDate = DateTime.Now;
            EndDate = DateTime.Now;

            HotelEntities context = new HotelEntities();

            Services = context.HotelServices.ToList();
           
            _user = user;
        }

        private ICommand _viewRooms;
        private ICommand _check;
        private ICommand _viewOffers;
        private ICommand _viewRes;

        private void ViewRoomsCommand(object parameter)
        {

            RoomView roomView = new RoomView();
            roomView.DataContext = new RoomViewModel(_user);
            roomView.Show();
        }

        private void CheckCommand(object parameter)
        {
            NewReservation newReservation = new NewReservation();
            newReservation.DataContext = new NewReservationViewModel(_user,BeginDate,EndDate);
            newReservation.Show();
        
        }

        private void ViewCommand(object parameter)
        {
            OffersView offersView = new OffersView();
            offersView.DataContext = new OffersViewModel(_user);
            offersView.Show();


        }

        private void ViewReserv(object parameter)
        {
            ReservationsView reservationsView = new ReservationsView();
            reservationsView.DataContext = new ReservationsVM(_user);
            reservationsView.Show();

        }

        public ICommand ViewRes
        {

            get
            {
                _viewRes = new RelayCommand(ViewReserv);
                return _viewRes;
            }
        }

        public ICommand ViewRooms
        {

            get {
                _viewRooms = new RelayCommand(ViewRoomsCommand);
                return _viewRooms; }
        }

        public ICommand Check
        {

            get
            {
                _check = new RelayCommand(CheckCommand);
                return _check;
            }
        }

        public ICommand ViewOffers
        {

            get
            {
                _viewOffers = new RelayCommand(ViewCommand);
                return _viewOffers;
            }
        }
    }
}
