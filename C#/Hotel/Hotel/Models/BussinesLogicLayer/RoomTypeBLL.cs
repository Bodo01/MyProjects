using System.Collections.Generic;
using System.Linq;
using System.Collections.ObjectModel;
using Hotel.Tools;

namespace Hotel.Models.BusinessLogicLayer
{
    public class RoomTypeBLL
    {
        public RoomTypeBLL()
        {
            RoomTypesList = new ObservableCollection<RoomType>();

        }

        private HotelEntities context = new HotelEntities();
        public ObservableCollection<RoomType> RoomTypesList { get; set; }
        public string ErrorMessage { get; set; }

        public void AddMethod(RoomType room)
        {


            if (room != null)
            {
                if (string.IsNullOrEmpty(room.name) )
                {
                    ErrorMessage = "You cannot create an account with empty fields!";
                }
                else
                {
                    context.RoomTypes.Add(new RoomType()
                    {
                        
                       name = room.name,
                        
                        deleted = false
                    });
                    context.SaveChanges();
                    RoomTypesList.Add(room);
                    ErrorMessage = "";
                }
            }
        }

        public ObservableCollection<RoomType> GetAllRoomTypes()
        {
            List<RoomType> users = context.RoomTypes.ToList();
            ObservableCollection<RoomType> result = new ObservableCollection<RoomType>();

            foreach (RoomType user in users)
            {
                if (user.deleted == false) { 
                user.RoomTypesImages = DeletedMethods.DeletedRoomTypesImage(user.RoomTypesImages.ToList());
                user.RoomFacilities = DeletedMethods.DeletedRoomFacilities(user.RoomFacilities.ToList());
                user.RoomPrices = DeletedMethods.DeletedRoomPrices(user.RoomPrices.ToList());

                result.Add(user); }
            }



            return result;
        }

      
      
    }
}