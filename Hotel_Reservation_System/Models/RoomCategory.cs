﻿using System;
using System.Collections.Generic;

namespace Hotel_Reservation_System.Models
{
    public partial class RoomCategory
    {
        public RoomCategory()
        {
            Rooms = new HashSet<Room>();
        }

        public int Id { get; set; }
        public string CategoryName { get; set; } = null!;
        public string? CategoryDescription { get; set; }

        public virtual ICollection<Room> Rooms { get; set; }
    }
}
