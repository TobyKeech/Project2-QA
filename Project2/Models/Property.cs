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
       //     Bookings = new HashSet<Booking>();
       //     booking set that can be tried when booking is created
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

       // public virtual ICollection<Booking> Bookings { get; set; }
       
       //certian areas of the code are commented out as they are not needed for the project currently
        public object Clone()
        {
            return new Property
            {
                Id = this.Id,
                Address = this.Address,
                Postcode = this.Postcode,
                Type = this.Type,
                NumberOfBedrooms = this.NumberOfBedrooms,
                NumberOfBathrooms = this.NumberOfBathrooms,
                Garden = this.Garden,
                Price = this.Price,
                Status = this.Status,
                SellerId = this.SellerId,
                BuyerId = this.BuyerId
            };
        }

        public bool Equals(Property? other)
        {
            return Id == other.Id;
        }
    }
}
