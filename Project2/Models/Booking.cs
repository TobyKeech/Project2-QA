using Project2.Persistence.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Project2.Models
{
    public partial class Booking : EntityBase, IEquatable<Booking>
    {
        [Column("BOOKING_ID")]
        [Key]
        public override int Id { get; set; }
        public int BuyerId { get; set; }
        public int PropertyId { get; set; }
        public DateTime? Time { get; set; }
        
        public virtual Buyer Buyer { get; set; } = null!;
        public virtual Property Property { get; set; } = null!;

        public object Clone()
        {
            return new Booking
            {
                Id = this.Id,
                BuyerId = this.BuyerId,
                PropertyId = this.PropertyId,
                Time = this.Time
            };
        }

        public bool Equals(Booking? other)
        {
            return Id == other.Id;
        }
    }
}
