using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Project2.Models
{
    public partial class Property
    {
        public Property()
        {
            Bookings = new HashSet<Booking>();
        }

        [Column("PropertyId")]
        [Key]
        public int PropertyId { get; set; }
        public string Address { get; set; } = null!;
        public string Postcode { get; set; } = null!;
        public string Type { get; set; } = null!;
        public int NumberOfBedrooms { get; set; }
        public int NumberOfBathrooms { get; set; }
        public byte[] Garden { get; set; } = null!;
        public decimal? Price { get; set; }
        public string Status { get; set; } = null!;
        public int SellerId { get; set; }
        public int? BuyerId { get; set; }

        public virtual Buyer? Buyer { get; set; }
        public virtual Seller Seller { get; set; } = null!;
        public virtual ICollection<Booking> Bookings { get; set; }
    }
}
