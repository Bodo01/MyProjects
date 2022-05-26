using Hotel.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Hotel.Tools
{
    internal class EnhancedRoomType:NotifyProp
    {

        private int indexPicture;
        private int indexFacility;

        public int IndexPicture
        {
            get { return indexPicture; }
            set { indexPicture = value; OnPropertyChanged("IndexPicture"); }
        }

        public int IndexFacility
        {
            get { return indexFacility; }
            set { indexFacility = value; OnPropertyChanged("IndexFacility"); }
        }

        private RoomType currentRoom;

        public RoomType CurrentRoom
        {
            get { return currentRoom; }
            set { currentRoom = value; OnPropertyChanged("CurrentRoom"); }
        }

        public EnhancedRoomType()
        { }
        public EnhancedRoomType(EnhancedRoomType enhancedRoomType)
        {
            this.CurrentRoom = enhancedRoomType.CurrentRoom;
            this.IndexPicture = enhancedRoomType.IndexPicture;
            this.IndexFacility = enhancedRoomType.IndexFacility;
        }
    }
}
