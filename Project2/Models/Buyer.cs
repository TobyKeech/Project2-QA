using Project2.Persistence.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Project2.Models
{
    public partial class Buyer : EntityBase, IEquatable<Buyer>
    {
        public Buyer()
        {
          //  Bookings = new HashSet<Booking>();
           // Properties = new HashSet<Property>();
            //  Bookings = new HashSet<Booking>();
            // Properties = new HashSet<Property>();
        }

        [Column("BuyerId")]
        [Key]
        public override int Id { get; set; }
        public string FirstName { get; set; } = null!;
        public string Surname { get; set; } = null!;
        public string Address { get; set; } = null!;
        public string Postcode { get; set; } = null!;
        public string Phone { get; set; } = null!;

        public virtual ICollection<Booking> Bookings { get; set; }
        public virtual ICollection<Property> Properties { get; set; }
    }
}
