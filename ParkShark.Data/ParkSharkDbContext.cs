﻿using Microsoft.EntityFrameworkCore;
using ParkShark.Domain.Divisions;
using ParkShark.Domain.Members;
using ParkShark.Domain.ParkingLots;

namespace ParkShark.Data
{
    public class ParkSharkDbContext : DbContext
    {

        public virtual DbSet<Division> Division { get; set; }
        public virtual DbSet<Member> Members { get; set; }

        public ParkSharkDbContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Division>()
                .ToTable("Division", "Div")
                .HasKey(e => e.GuidID);

            modelBuilder.Entity<Division>()
                .HasOne(parent => parent.ParentDivision)
                .WithMany(subdivisions => subdivisions.SubdivisionsList)
                .HasForeignKey(key => key.ParentDivisionGuidID);

            modelBuilder.Entity<Division>()
                .Property(d => d.GuidID).HasColumnName("Division_ID");
            modelBuilder.Entity<Division>()
                .Property(d => d.Director).HasColumnName("Division_Director");
            modelBuilder.Entity<Division>()
                .Property(d => d.Name).HasColumnName("Division_Name");
            modelBuilder.Entity<Division>()
                .Property(d => d.OriginalName).HasColumnName("Division_OrgName");
            modelBuilder.Entity<Division>()
                .Property(d => d.ParentDivisionGuidID).HasColumnName("Division_ParentDivisionGuidId");
            modelBuilder.Entity<Member>()
                .ToTable("Members", "Mem")
                .HasKey(m => m.MemberId);

            modelBuilder.Entity<City>()
                .ToTable("Cities", "Mem")
                .HasKey(m => m.ZIP);

            modelBuilder.Entity<LicensePlate>()
                .ToTable("LicensePlates", "Mem")
                .HasKey(l => new
                {
                    l.MemberId,
                    l.LicensePlateValue
                });

            modelBuilder.Entity<PhoneNumber>()
                .ToTable("PhoneNumbers", "Mem")
                .HasKey(l => new
                {
                    l.MemberId,
                    l.PhoneNumberValue
                });



            modelBuilder.Entity<Member>()
                .Property(m => m.MemberId).HasColumnName("Member_ID");
            modelBuilder.Entity<Member>()
                .Property(m => m.FirstName).HasColumnName("Member_FirstName");
            modelBuilder.Entity<Member>()
                .Property(m => m.LastName).HasColumnName("Member_LastName");
            modelBuilder.Entity<Member>()
                .Property(m => m.RegistrationDate).HasColumnName("Member_RegistrationDate");
            modelBuilder.Entity<LicensePlate>()
                .Property(m => m.IssueingCountry).HasColumnName("IssueingCountry");
            modelBuilder.Entity<LicensePlate>()
                .Property(lcp => lcp.LicensePlateValue).HasColumnName("LicensePlate");
            modelBuilder.Entity<LicensePlate>()
                .Property(m => m.MemberId).HasColumnName("Member_ID");
            modelBuilder.Entity<City>()
                .Property(t => t.ZIP).HasColumnName("City_ZIP");
            modelBuilder.Entity<City>()
                .Property(u => u.CityName).HasColumnName("City_Name");
            modelBuilder.Entity<City>()
                .Property(v => v.CountryName).HasColumnName("City_CountryName");


            modelBuilder.Entity<Member>()
                .OwnsOne(a => a.Address, a =>
                {
                    a.Property(b => b.StreetName).HasColumnName("Member_StreetName");
                    a.Property(s => s.StreetNumber).HasColumnName("Member_StreetNumber");
                    a.Property(z => z.ZIP).HasColumnName("City_ZIP");
                });


            modelBuilder.Entity<Address>()
                .HasOne(m => m.City)
                .WithMany()
                .HasForeignKey(m => m.ZIP)
                .IsRequired();

            modelBuilder.Entity<PhoneNumber>()
                .HasOne(p => p.Member)
                .WithMany()
                .HasForeignKey(p => p.MemberId)
                .IsRequired();

            modelBuilder.Entity<LicensePlate>()
                .HasOne(l => l.Member)
                .WithMany()
                .HasForeignKey(l => l.MemberId)
                .IsRequired();

            modelBuilder.Entity<ParkingLot>()
                .ToTable("ParkingLots", "PL")
                .HasKey(p => p.ParkingLotID);

            modelBuilder.Entity<ParkingLot>()
                .Property(p => p.Name).HasColumnName("ParkingLot_Name");
            modelBuilder.Entity<ParkingLot>()
                .Property(p => p.DivisionID).HasColumnName("Division_ID");
            modelBuilder.Entity<ParkingLot>()
                .Property(p => p.Capacity).HasColumnName("ParkingLot_Capacity");
            modelBuilder.Entity<ParkingLot>()
                .Property(p => p.BuildingtypeID).HasColumnName("BuildingType_ID");
            modelBuilder.Entity<ParkingLot>()
                .Property(p => p.ContactPersonID).HasColumnName("ContactPerson_Id");
            modelBuilder.Entity<ParkingLot>()
                .Property(p => p.PricePerHour).HasColumnName("ParkingLot_PricePerHour");


            modelBuilder.Entity<ParkingLot>()
             .OwnsOne(a => a.Address, a =>
             {
                 a.Property(b => b.StreetName).HasColumnName("ParkingLot_StreetName");
                 a.Property(s => s.StreetNumber).HasColumnName("ParkingLot_StreetNumber");
                 a.Property(z => z.ZIP).HasColumnName("City_ZIP");
             });

            modelBuilder.Entity<ParkingLot>()
                .HasOne(p => p.ContactPerson)
                .WithMany()
                .HasForeignKey(fr => fr.ContactPersonID)
                .IsRequired();

            modelBuilder.Entity<ParkingLot>()
                .HasOne(div => div.Division)
                .WithMany()
                .HasForeignKey(fr => fr.DivisionID)
                .IsRequired();

            base.OnModelCreating(modelBuilder);

        }

    }
}
