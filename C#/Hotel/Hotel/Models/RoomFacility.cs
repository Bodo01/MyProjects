//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Hotel.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class RoomFacility
    {
        public int id { get; set; }
        public Nullable<int> room_types { get; set; }
        public Nullable<int> facility_id { get; set; }
        public Nullable<bool> deleted { get; set; }
    
        public virtual Facility Facility { get; set; }
        public virtual RoomType RoomType { get; set; }

        public static implicit operator RoomFacility(bool v)
        {
            throw new NotImplementedException();
        }
    }
}
