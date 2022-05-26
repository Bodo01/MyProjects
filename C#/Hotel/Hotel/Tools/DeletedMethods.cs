using Hotel.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.Tools
{
    internal class DeletedMethods
    {
        
        public static List<RoomFacility> DeletedRoomFacilities (List<RoomFacility> list)
        {
            List<RoomFacility> aux = new List<RoomFacility>();

            foreach (RoomFacility facility in list)
                if(facility.deleted==false)
                    aux.Add(facility);

            return aux;

        }

        public static List<RoomPrice> DeletedRoomPrices (List<RoomPrice> list)
        {
            List<RoomPrice> aux     = new List<RoomPrice>();

            foreach (var price in list)
                if (price.deleted == false)
                    aux.Add(price);

            return aux;
        }

        public static List<RoomTypesImage> DeletedRoomTypesImage(List<RoomTypesImage> list)
        {
            List<RoomTypesImage> aux = new List<RoomTypesImage>();

            foreach (var price in list)
                if (price.deleted == false)
                    aux.Add(price);

            return aux;
        }
    }
}
