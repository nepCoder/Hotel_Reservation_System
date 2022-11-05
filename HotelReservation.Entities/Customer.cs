using System;
using System.Collections.Generic;

namespace HotelReservation.Entities
{
    public partial class Customer
    {
        public Customer()
        {
            Bookings = new HashSet<Booking>();
            Invoices = new HashSet<Invoice>();
        }

        public int Id { get; set; }
        public string FullName { get; set; } = null!;
        public string? Address { get; set; }
        public string? Phone { get; set; }

        public virtual ICollection<Booking> Bookings { get; set; }
        public virtual ICollection<Invoice> Invoices { get; set; }
    }
}
