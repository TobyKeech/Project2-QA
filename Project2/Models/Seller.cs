using Project2.Business.DTO;
using Project2.Persistence.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Project2.Models
{
    public partial class Seller : EntityBase, IEquatable<Seller>, ICloneable
    {
        public Seller()
        {
            //Properties = new HashSet<Property>();
        }

        [Column("SELLER_ID")]
        [Key]
        public override int Id { get; set; }
        //public int SellerId { get; set; }
        public string FirstName { get; set; } = null!;
        public string Surname { get; set; } = null!;
        public string Address { get; set; } = null!;
        public string Postcode { get; set; } = null!;
        public string Phone { get; set; } = null!;

        public virtual ICollection<Property> Properties { get; set; }

        public object Clone()
        {
            return new SellerDTO
            {
                Id = this.Id,
                //SellerId = this.SellerId,
                FirstName = this.FirstName,
                Surname = this.Surname,
                Address = this.Address,
                Postcode = this.Postcode,
                Phone = this.Phone,
                Properties = this.Properties
            };
        }

        public bool Equals(Seller? other)
        {
            return Id == other.Id;
            //return SellerId == other.SellerId;
        }
    }
}
