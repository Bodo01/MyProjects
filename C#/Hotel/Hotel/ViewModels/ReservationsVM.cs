using Hotel.Models;
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
    internal class ReservationsVM:NotifyProp
    {
        private ICollection<Reservation> reservations;
        private User _user;
        private Reservation currentReservation;

        public Reservation CurrentReservation
        {
            get { return currentReservation; }
            set { currentReservation = value; OnPropertyChanged("CurrentReservation"); }

        }
        public ICollection<Reservation> Reservations
        {
            get { return reservations; }
            set { reservations = value; OnPropertyChanged("Reservations"); }
        }


        private void CancelCommand(object parameter)
        {
            if(CurrentReservation.status>1)
            {
                MessageBox.Show("Can't cancel an already canceled reservation, or a finalized one!");
            }
            else
            {
                MessageBox.Show("Reservation canceled!");

               HotelEntities context = new HotelEntities();

                CurrentReservation.status = 3;
                CurrentReservation.STATUS = "Canceled";

                Reservations = new List<Reservation>(reservations);



                var reserv = context.Reservations.FirstOrDefault(s => (s.id==CurrentReservation.id));
                reserv.status = 3;

                foreach(var aux in reserv.ReservationRooms)
                {
                    aux.deleted = true;
                }

               
                context.SaveChanges();
            }


        }


        private void PayCommand(object parameter)
        {
            if (CurrentReservation.status != 0)
            {

                MessageBox.Show("Reservation already paid!");

            }
            else
            {
                MessageBox.Show("Reservation paid!");

                HotelEntities context = new HotelEntities();

                CurrentReservation.status = 1;
                CurrentReservation.STATUS = "Confirmed";

                Reservations = new List<Reservation>(reservations);

                var reserv = context.Reservations.FirstOrDefault(s => (s.id == CurrentReservation.id));
                reserv.status = 1;
                context.SaveChanges();


            }

        }

        private ICommand _cancelRes;
        private ICommand _payRes;

        public ICommand CancelRes
        {
            get
            {

                _cancelRes = new RelayCommand(CancelCommand);
                return _cancelRes;
            }


        }

        public ICommand PayRes
        {
            get
            {

                _payRes = new RelayCommand(PayCommand);
                return _payRes;
            }


        }


        public ReservationsVM(User user)
        {
            #region update all reservations
            HotelEntities context = new HotelEntities();

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


            _user = user;
            if (user == null)
                MessageBox.Show("Logged as guest!");
            else {
            
            Reservations = new List<Reservation>();

                var reservs= new List<Reservation>();

                if (user.user_type > 0)
                    reservs = context.Reservations.ToList();
                else
                {
                    var aux =context.Users.FirstOrDefault(s => s.id == user.id);
                    reservs = aux.Reservations.ToList();
                }
                foreach (var res in reservs)
                {
                    switch (res.status)
                    {
                        case 0:
                        
                        res.STATUS = "Unpaid";

                            break;
                        case 1:
                            res.STATUS = "Confirmed";

                            break;

                        case 2:
                            res.STATUS = "Finalised";
                            break;
                        case 3:
                            res.STATUS = "Canceled";
                            break;

                        default:
                            res.STATUS = "Unknown";
                            break;

                    }


                

                Reservations.Add(res);
                }
                
            
            }
        }

    }
}
