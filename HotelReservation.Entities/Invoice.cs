using System;
using System.Collections.Generic;

namespace HotelReservation.Entities
{
    public partial class Invoice
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public double Amount { get; set; }
        public double? Discount { get; set; }
        public double NetAmount { get; set; }
        public string? Status { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime? CheckOutTime { get; set; }

        public virtual Customer Customer { get; set; } = null!;
    }
}
