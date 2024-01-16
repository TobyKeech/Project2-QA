using System;
using System.Collections.Generic;

namespace Project2.Models
{
    public partial class Buyer
    {
        public Buyer()
        {
          Bookings = new HashSet<Booking>();
          Properties = new HashSet<Property>();
        }

        public int BuyerId { get; set; }
        public string FirstName { get; set; } = null!;
        public string Surname { get; set; } = null!;
        public string Address { get; set; } = null!;
        public string Postcode { get; set; } = null!;
        public string Phone { get; set; } = null!;

      public virtual ICollection<Booking> Bookings { get; set; }
      public virtual ICollection<Property> Properties { get; set; }
    }
}
