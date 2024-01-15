using Project2.Persistence.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Project2.Models
{
    public partial class Property : EntityBase, IEquatable<Property>
    {
        public Property()
        {
            //Bookings = new HashSet<Booking>();
        }

        [Column("Property_Id")]
        [Key]
        public override int Id { get; set; }
        public string Address { get; set; } = null!;
        public string Postcode { get; set; } = null!;
        public string Type { get; set; } = null!;
        public int NumberOfBedrooms { get; set; }
        public int NumberOfBathrooms { get; set; }
        public bool Garden { get; set; }
        public decimal? Price { get; set; }
        public string Status { get; set; } = null!;
        public int SellerId { get; set; }
        public int? BuyerId { get; set; }

        public virtual Buyer? Buyer { get; set; }
        public virtual Seller Seller { get; set; } = null!;
        public virtual ICollection<Booking> Bookings { get; set; }

        public bool Equals(Property? other)
        {
            return Id == other.Id;
        }
    }
}
