using Microsoft.AspNetCore.Mvc;
using Project2.Models;
using Project2.Persistence.Repositories.Contracts;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Project2.Business.DTO
{
    public class SellerDTO : EntityBase, IEquatable<SellerDTO>
    {
        public SellerDTO() { }

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

        public bool Equals(SellerDTO? other)
        {
            return Id == other.Id;
        }

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
    }
}
