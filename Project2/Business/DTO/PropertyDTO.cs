using Project2.Models;
using Project2.Persistence.Repositories.Contracts;
using System.ComponentModel.DataAnnotations;

namespace Project2.Business.DTO
{
    public class PropertyDTO : EntityBase, IEquatable<PropertyDTO>
    {
        public PropertyDTO()
        {
            //Bookings = new HashSet<BookingDTO>();
        }


        [Key]
        public override int Id { get; set; }
        public string Address { get; set; }
        public string Postcode { get; set; }
        public string Type { get; set; }
        public int NumberOfBedrooms { get; set; }
        public int NumberOfBathrooms { get; set; }
        public bool Garden { get; set; }
        public decimal? Price { get; set; }
        public string Status { get; set; }
        public int SellerId { get; set; }
        public int? BuyerId { get; set; }

        //public virtual ICollection<BookingDTO>? Bookings { get; set; }

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
