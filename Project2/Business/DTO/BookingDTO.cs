using Microsoft.AspNetCore.Mvc;
using Project2.Models;
using Project2.Persistence.Repositories.Contracts;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Project2.Business.DTO
{
    public class BookingDTO : EntityBase, IEquatable<BookingDTO>
    {
        public BookingDTO()
        {
           
        }

        [Key]
        public override int Id { get; set; }
        public int BuyerId { get { return Id; } set { Id = value; } }

        public int PropertyId { get { return Id; } set { Id = value; } }
        public string Time { get; set; }

        public bool Equals(BookingDTO? other)
        {
            return Id == other.Id;
        }

        public object Clone()
        {
            return new BookingDTO
            {
                Id = this.Id,
                BuyerId = this.BuyerId,
                PropertyId = this.PropertyId,
                Time = this.Time,
            };
        }
    }
}

