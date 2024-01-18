using Project2.Models;
using Project2.Persistence.Repositories.Contracts;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Project2.Business.DTO
{
    public class PropertyDTO : EntityBase, IEquatable<PropertyDTO>
    {
        public PropertyDTO()
        {
            Bookings = new HashSet<BookingDTO>();
        }


        [Key]
        [Column("id")]
        public override int Id { get; set; }
        [Column("address")]
        public string Address { get; set; }
        [Column("postcode")]
        public string Postcode { get; set; }
        [Column("type")]
        public string Type { get; set; }
        [Column("numberOfBedrooms")]
        public int NumberOfBedrooms { get; set; }
        [Column("numberOfBathrooms")]
        public int NumberOfBathrooms { get; set; }
        [Column("garden")]
        public bool Garden { get; set; }
        [Column("price")]
        public decimal? Price { get; set; }
        [Column("status")]
        public string Status { get; set; }
        [Column("sellerId")]
        public int SellerId { get; set; }
        [Column("buyerId")]
        public int? BuyerId { get; set; }

        public virtual ICollection<BookingDTO>? Bookings { get; set; }

        public bool Equals(PropertyDTO? other)
        {
            return Id == other.Id;
        }

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

    }
}
