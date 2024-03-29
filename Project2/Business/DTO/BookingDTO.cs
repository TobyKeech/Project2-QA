﻿using Microsoft.AspNetCore.Mvc;
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
        [Column("id")]
        public override int Id { get; set; }
        public int BuyerId { get; set; }

        public int PropertyId { get; set; }
        public DateTime Time { get; set; }

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

