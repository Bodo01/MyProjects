using Hotel.Models;
using Hotel.Tools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Forms;
using System.Windows.Input;

namespace Hotel.ViewModels
{
    internal class ModifyRoomVM : NotifyProp
    {
        //private RoomType currentRoom;

        //private int index;
        //public RoomType CurrentRoom
        //{
        //    get { return currentRoom; }
        //    set { currentRoom = value; OnPropertyChanged("CurrentRoom"); }
        //}

        private EnhancedRoomType enhanced;
        private HotelEntities context;

        private Facility currentFacility;
        private RoomPrice currentRoomPrice;

        private DateTime newStartDate;
        private DateTime newEndDate;
        private float newPrice;

        public float NewPrice
        {
            get { return newPrice; }
            set { newPrice = value; OnPropertyChanged("NewPrice"); }

        }

        public DateTime StartDate
        {
            get { return newStartDate; }
            set { newStartDate = value; OnPropertyChanged("StartDate"); }
        }

        public DateTime EndDate
        {
            get { return newEndDate; }
            set { newEndDate = value; OnPropertyChanged("EndDate"); }
        }

        public RoomPrice CurrentRoomPrice
        {

            get { return currentRoomPrice; }
            set { currentRoomPrice = value; OnPropertyChanged("CurrentRoomPrice"); }
        }
        public Facility CurrentFacility
        {
            get { return currentFacility; }
            set { currentFacility = value; OnPropertyChanged("CurrentFacility"); }

        }


        public ICollection<Facility> FacilitiesList { get; set; }
        public EnhancedRoomType Enhanced
        {

            get { return enhanced; }
            set { enhanced = value; OnPropertyChanged("Enhanced"); }
        }

        public ModifyRoomVM(RoomType room)
        {
            StartDate=DateTime.Now;
            EndDate=DateTime.Now;

            context = new HotelEntities();
            Enhanced = new EnhancedRoomType();
            Enhanced.CurrentRoom = context.RoomTypes.FirstOrDefault(s => (s.id == room.id));
            Enhanced.CurrentRoom.RoomFacilities = DeletedMethods.DeletedRoomFacilities(Enhanced.CurrentRoom.RoomFacilities.ToList());
            Enhanced.CurrentRoom.RoomPrices = DeletedMethods.DeletedRoomPrices(Enhanced.CurrentRoom.RoomPrices.ToList());
            Enhanced.CurrentRoom.RoomTypesImages = DeletedMethods.DeletedRoomTypesImage(Enhanced.CurrentRoom.RoomTypesImages.ToList());
            //CurrentRoom = room;
            //FacilitiesList = new List<Facility>();
            FacilitiesList = context.Facilities.ToList();
        }


        private void DeletePic(object parameter)
        {
            Enhanced.CurrentRoom.RoomTypesImages.ToList()[Enhanced.IndexPicture].deleted = true;


            context.SaveChanges();

            Enhanced.CurrentRoom.RoomTypesImages = DeletedMethods.DeletedRoomTypesImage(Enhanced.CurrentRoom.RoomTypesImages.ToList());

            Enhanced = new EnhancedRoomType(Enhanced);


        }

        private void BrowseMethod()
        {
            


        }
        private void AddPic(object parameter)
        {
            var fac = new RoomTypesImage();
            fac.deleted = false;


            OpenFileDialog dlg = new OpenFileDialog();
            dlg.InitialDirectory = "d:\\" ;
            dlg.Filter = "Image jpeg(*.jpg)|*.jpg|Image png(*.png)|*.png";
            dlg.DefaultExt = ".jpeg";

            dlg.ShowDialog();

            fac.path = dlg.FileName;



            if (fac.path != null)
                if (fac.path != "")
                {
                    //  Enhanced.CurrentRoom = context.RoomTypes.FirstOrDefault(s => (s.id == Enhanced.CurrentRoom.id));

                    Enhanced.CurrentRoom.RoomTypesImages.Add(fac);

                    context.SaveChanges();

                    // Enhanced.CurrentRoom.RoomFacilities = Enhanced.CurrentRoom.RoomFacilities;
                    Enhanced.CurrentRoom.RoomTypesImages = DeletedMethods.DeletedRoomTypesImage(Enhanced.CurrentRoom.RoomTypesImages.ToList());


                    Enhanced = new EnhancedRoomType(Enhanced);
                }

        }

        private ICommand deleteFacility;
        private ICommand deletePicture;
        private ICommand addFacility;
        private ICommand addPicture;
        private ICommand deletePrice;
        private ICommand addPrice;

        public ICommand AddPicture
        {
            get {
                addPicture = new RelayCommand(AddPic);
                return addPicture; }
        }

        public ICommand DeletePicture
        {
            get {
                deletePicture = new RelayCommand(DeletePic);
                return deletePicture; }
        }

        private void DeleteFac(object parameter)
        {
           // Enhanced.CurrentRoom= context.RoomTypes.FirstOrDefault(s => (s.id == Enhanced.CurrentRoom.id)); //scap de null

            Enhanced.CurrentRoom.RoomFacilities.ToList()[Enhanced.IndexFacility].deleted = true;


            context.SaveChanges();

            Enhanced.CurrentRoom.RoomFacilities = DeletedMethods.DeletedRoomFacilities(Enhanced.CurrentRoom.RoomFacilities.ToList());

            Enhanced = new EnhancedRoomType(Enhanced);
        }

        private void AddFac(object parameter)
        {
            foreach(RoomFacility aux in Enhanced.CurrentRoom.RoomFacilities.ToList())
            {

                if(aux.facility_id== CurrentFacility.id)
                {
                    System.Windows.MessageBox.Show("Facility already added!");
                    return;
                }
            }

            var fac = new RoomFacility();
            fac.deleted = false;
            fac.facility_id = CurrentFacility.id;

          //  Enhanced.CurrentRoom = context.RoomTypes.FirstOrDefault(s => (s.id == Enhanced.CurrentRoom.id));

            Enhanced.CurrentRoom.RoomFacilities.Add(fac);

            context.SaveChanges();

            // Enhanced.CurrentRoom.RoomFacilities = Enhanced.CurrentRoom.RoomFacilities;
            Enhanced.CurrentRoom.RoomFacilities = DeletedMethods.DeletedRoomFacilities(Enhanced.CurrentRoom.RoomFacilities.ToList());


            Enhanced = new EnhancedRoomType(Enhanced);


        }

        private void AddPrc(object parameter)
        {
            if (NewPrice==null||NewPrice==0)
            { System.Windows.MessageBox.Show("Please insert a price!"); }
            else
            {

                if (StartDate > EndDate)
                {
                    var aux = StartDate;
                    StartDate = EndDate;
                    EndDate = aux;
                }
                    
                    var listAux = Enhanced.CurrentRoom.RoomPrices.Where(s => (s.start_date <= StartDate && EndDate <= s.end_date) || (s.start_date <= EndDate && EndDate <= s.end_date) || (s.start_date >= StartDate && EndDate >= s.end_date)).ToList();
                
                    if(listAux.Count!=0)
                    {
                        System.Windows.MessageBox.Show("There is already a price in the selected time frame!");
                    }
                    else
                    {
                        Enhanced.CurrentRoom.RoomPrices.Add(new RoomPrice()
                        {
                            start_date = StartDate,
                            end_date = EndDate,
                            price = NewPrice,
                            deleted = false
                        }) ;
                        context.SaveChanges();

                        Enhanced.CurrentRoom.RoomPrices = DeletedMethods.DeletedRoomPrices(Enhanced.CurrentRoom.RoomPrices.ToList());


                        Enhanced = new EnhancedRoomType(Enhanced);



                    }
                
            }

        }
        private void DeletePrc(object parameter)
        {
            CurrentRoomPrice.deleted = true;
            context.SaveChanges();
            Enhanced.CurrentRoom.RoomPrices = DeletedMethods.DeletedRoomPrices(Enhanced.CurrentRoom.RoomPrices.ToList());

            Enhanced = new EnhancedRoomType(Enhanced);
        }

       
        public ICommand DeleteFacility
        {

            get
            {
                deleteFacility = new RelayCommand(DeleteFac);
                return deleteFacility;
            }
        }

        public ICommand DeletePrice
        {

            get
            {
                deletePrice = new RelayCommand(DeletePrc);
                return deletePrice;
            }
        }

        public ICommand AddFacility
        {
            get
            {

                addFacility = new RelayCommand(AddFac);
                return addFacility;
            }
        }

        public ICommand AddPrice
        {
            get
            {

                addPrice = new RelayCommand(AddPrc);
                return addPrice;
            }
        }
    }
}
