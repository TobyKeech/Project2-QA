using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Project2.Models;

namespace Project2.EF
{
    public partial class EstateContext : DbContext
    {
        public EstateContext()
        {
        }

        public EstateContext(DbContextOptions<EstateContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Booking> Bookings { get; set; } = null!;
        public virtual DbSet<Buyer> Buyers { get; set; } = null!;
        public virtual DbSet<Property> Properties { get; set; } = null!;
        public virtual DbSet<Seller> Sellers { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=(local);Database=estateagent;Trusted_Connection=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Booking>(entity =>
            {
                entity.ToTable("booking");

                entity.Property(e => e.BookingId).HasColumnName("BOOKING_ID");

                entity.Property(e => e.BuyerId).HasColumnName("BUYER_ID");

                entity.Property(e => e.PropertyId).HasColumnName("PROPERTY_ID");

                entity.Property(e => e.Time)
                    .HasColumnType("datetime")
                    .HasColumnName("TIME");

                entity.HasOne(d => d.Buyer)
                    .WithMany(p => p.Bookings)
                    .HasForeignKey(d => d.BuyerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("booking$booking_ibfk_1");

                entity.HasOne(d => d.Property)
                    .WithMany(p => p.Bookings)
                    .HasForeignKey(d => d.PropertyId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("booking$booking_ibfk_2");
            });

            modelBuilder.Entity<Buyer>(entity =>
            {
                entity.ToTable("buyer");

                entity.Property(e => e.Id).HasColumnName("BUYER_ID");

                entity.Property(e => e.Address)
                    .HasMaxLength(255)
                    .HasColumnName("ADDRESS");

                entity.Property(e => e.FirstName)
                    .HasMaxLength(255)
                    .HasColumnName("FIRST_NAME");

                entity.Property(e => e.Phone)
                    .HasMaxLength(20)
                    .HasColumnName("PHONE");

                entity.Property(e => e.Postcode)
                    .HasMaxLength(255)
                    .HasColumnName("POSTCODE");

                entity.Property(e => e.Surname)
                    .HasMaxLength(255)
                    .HasColumnName("SURNAME");
            });

            modelBuilder.Entity<Property>(entity =>
            {
                entity.ToTable("property");

                entity.Property(e => e.PropertyId).HasColumnName("PROPERTY_ID");

                entity.Property(e => e.Address)
                    .HasMaxLength(255)
                    .HasColumnName("ADDRESS");

                entity.Property(e => e.BuyerId).HasColumnName("BUYER_ID");

                entity.Property(e => e.Garden)
                    .HasMaxLength(1)
                    .HasColumnName("GARDEN")
                    .IsFixedLength();

                entity.Property(e => e.NumberOfBathrooms).HasColumnName("NUMBER_OF_BATHROOMS");

                entity.Property(e => e.NumberOfBedrooms).HasColumnName("NUMBER_OF_BEDROOMS");

                entity.Property(e => e.Postcode)
                    .HasMaxLength(255)
                    .HasColumnName("POSTCODE");

                entity.Property(e => e.Price)
                    .HasColumnType("decimal(11, 2)")
                    .HasColumnName("PRICE");

                entity.Property(e => e.SellerId).HasColumnName("SELLER_ID");

                entity.Property(e => e.Status)
                    .HasMaxLength(9)
                    .HasColumnName("STATUS");

                entity.Property(e => e.Type)
                    .HasMaxLength(9)
                    .HasColumnName("TYPE");

                entity.HasOne(d => d.Buyer)
                    .WithMany(p => p.Properties)
                    .HasForeignKey(d => d.BuyerId)
                    .HasConstraintName("property$property_ibfk_2");

                entity.HasOne(d => d.Seller)
                    .WithMany(p => p.Properties)
                    .HasForeignKey(d => d.SellerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("property$property_ibfk_1");
            });

            modelBuilder.Entity<Seller>(entity =>
            {
                entity.ToTable("seller");

                entity.Property(e => e.SellerId).HasColumnName("SELLER_ID");

                entity.Property(e => e.Address)
                    .HasMaxLength(255)
                    .HasColumnName("ADDRESS");

                entity.Property(e => e.FirstName)
                    .HasMaxLength(255)
                    .HasColumnName("FIRST_NAME");

                entity.Property(e => e.Phone)
                    .HasMaxLength(20)
                    .HasColumnName("PHONE");

                entity.Property(e => e.Postcode)
                    .HasMaxLength(255)
                    .HasColumnName("POSTCODE");

                entity.Property(e => e.Surname)
                    .HasMaxLength(255)
                    .HasColumnName("SURNAME");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
