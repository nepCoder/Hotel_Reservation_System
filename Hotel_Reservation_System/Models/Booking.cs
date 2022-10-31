using System;
using System.Collections.Generic;

namespace Hotel_Reservation_System.Models
{
    public partial class Booking
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public int RoomId { get; set; }
        public DateTime? BookingDate { get; set; }
        public string? Status { get; set; }

        public virtual Customer Customer { get; set; } = null!;
        public virtual Room Room { get; set; } = null!;
    }
}
