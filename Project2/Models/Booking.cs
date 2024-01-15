using System;
using System.Collections.Generic;

namespace Project2.Models
{
    public partial class Booking
    {
        public int BookingId { get; set; }
        public int BuyerId { get; set; }
        public int PropertyId { get; set; }
        public DateTime? Time { get; set; }

        public virtual Buyer Buyer { get; set; } = null!;
        public virtual Property Property { get; set; } = null!;
    }
}
