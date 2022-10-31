using System;
using System.Collections.Generic;

namespace Hotel_Reservation_System.Models
{
    public partial class Room
    {
        public Room()
        {
            Bookings = new HashSet<Booking>();
        }

        public int Id { get; set; }
        public string RoomName { get; set; } = null!;
        public string? RoomDescription { get; set; }
        public int RoomCategoryId { get; set; }
        public string? Status { get; set; }
        public double? Cost { get; set; }

        public virtual RoomCategory RoomCategory { get; set; } = null!;
        public virtual ICollection<Booking> Bookings { get; set; }
    }
}
