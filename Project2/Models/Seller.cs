using System;
using System.Collections.Generic;

namespace Project2.Models
{
    public partial class Seller
    {
        public Seller()
        {
            Properties = new HashSet<Property>();
        }

        public int SellerId { get; set; }
        public string FirstName { get; set; } = null!;
        public string Surname { get; set; } = null!;
        public string Address { get; set; } = null!;
        public string Postcode { get; set; } = null!;
        public string Phone { get; set; } = null!;

        public virtual ICollection<Property> Properties { get; set; }
    }
}
