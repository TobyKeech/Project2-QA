using Project2.Models;
using Project2.Persistence.Repositories.Contracts;
using System.ComponentModel.DataAnnotations;

namespace Project2.Business.DTO
{

    public class BuyerDTO : EntityBase, IEquatable<BuyerDTO>
    {
	public BuyerDTO()
	{
            Bookings = new HashSet<BookingDTO>();
            Properties = new HashSet<PropertyDTO>();
        }
        [Key]
        public override int Id { get; set; }
       /// <summary>
       /// public int BuyerId { get { return Id; } set { Id = value; } }
       /// </summary>
        public string FirstName { get; set; }
        public string Surname { get; set; }
        public string Address { get; set; }
        public string Postcode { get; set; }
        public string Phone { get; set; }

        public virtual ICollection<PropertyDTO> Properties { get; set; }
        public virtual ICollection<BookingDTO> Bookings{ get; set; }

        public bool Equals(BuyerDTO? other)
        {
            return Id == other.Id;
        }

        public object Clone()
        {
            return new BuyerDTO
            {
                Id = this.Id,
                FirstName = this.FirstName,
                Surname = this.Surname,
                Address = this.Address,
                Postcode = this.Postcode,
                Phone = this.Phone,

            };
        }
	}
}
