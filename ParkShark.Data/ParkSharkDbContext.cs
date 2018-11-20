using Microsoft.EntityFrameworkCore;
using ParkShark.Domain.Divisions;
using ParkShark.Domain.Members;
using ParkShark.Domain.ParkingLots;
using System;

namespace ParkShark.Data
{
    public class ParkSharkDbContext : DbContext
    {

        public virtual DbSet<Division> Division { get; set; }
        public virtual DbSet<Member> Members { get; set; }
        public virtual DbSet<ParkingLot> ParkingLots { get; set; }
        public virtual DbSet<MembershipLevel> MembershipLevel { get; set; }

        public ParkSharkDbContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Division>()
                .ToTable("Division", "Div")
                .HasKey(e => e.ID);

            modelBuilder.Entity<Division>()
                .HasOne(parent => parent.ParentDivision)
                .WithMany(subdivisions => subdivisions.SubdivisionsList)
                .HasForeignKey(key => key.ParentDivisionGuidID);

            modelBuilder.Entity<Division>()
                .Property(d => d.ID).HasColumnName("Division_ID");
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
            modelBuilder.Entity<Member>()
                .Property(d => d.MembershipLevelId).HasConversion(
                    a => Convert.ToInt32(a),
                    b => (MembershipLevelEnum)b)
                .HasColumnName("Member_MembershipLevel_ID");

            modelBuilder.Entity<Member>()
                .OwnsOne(a => a.Address, a =>
                {
                    a.Property(b => b.StreetName).HasColumnName("Member_StreetName");
                    a.Property(s => s.StreetNumber).HasColumnName("Member_StreetNumber");
                    a.Property(z => z.ZIP).HasColumnName("City_ZIP");
                });


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


            modelBuilder.Entity<MembershipLevel>()
             .ToTable("MembershipLevel", "Mem")
             .HasKey(e => e.MembershipId);


            modelBuilder.Entity<MembershipLevel>()
               .Property(ml => ml.MembershipId).HasColumnName("MembershipLevel_ID");
            modelBuilder.Entity<MembershipLevel>()
                .Property(ml => ml.Name).HasColumnName("MembershipLevel_Name");
            modelBuilder.Entity<MembershipLevel>()
               .Property(ml => ml.Description).HasColumnName("MembershipLevel_Description");
            modelBuilder.Entity<MembershipLevel>()
                .Property(ml => ml.MonthlyCost).HasColumnName("MembershipLevel_MonthlyCost");
            modelBuilder.Entity<MembershipLevel>()
                .Property(ml => ml.PSAPriceReductionPercentage).HasColumnName("MembershipLevel_PSA_PriceReduction");
            modelBuilder.Entity<MembershipLevel>()
                .Property(ml => ml.PSAMaxTimeInHours).HasColumnName("MembershipLevel_PSA_MaxTime");

            modelBuilder.Entity<Member>()
                .HasOne(ml => ml.MembershipLevel)
                .WithMany(level => level.Members)
                .HasForeignKey(ml => ml.MembershipLevelId)
                .IsRequired();





            modelBuilder.Entity<ParkingLot>()
                .ToTable("ParkingLots", "PL")
                .HasKey(p => p.ParkingLotID);

            modelBuilder.Entity<ParkingLot>()
                .Property(p => p.ParkingLotID).HasColumnName("ParkingLot_ID");
            modelBuilder.Entity<ParkingLot>()
                .Property(p => p.Name).HasColumnName("ParkingLot_Name");
            modelBuilder.Entity<ParkingLot>()
                .Property(p => p.DivisionID).HasColumnName("Division_ID");
            modelBuilder.Entity<ParkingLot>()
                .Property(p => p.Capacity).HasColumnName("ParkingLot_Capacity");
            modelBuilder.Entity<ParkingLot>()
                .Property(p => p.BuildingType)
                .HasConversion<string>()
                .HasColumnName("BuildingType");
            modelBuilder.Entity<ParkingLot>()
                .Property(p => p.PricePerHour).HasColumnName("ParkingLot_PricePerHour");


            modelBuilder.Entity<ParkingLot>()
             .OwnsOne(a => a.Address, a =>
             {
                 a.Property(b => b.StreetName).HasColumnName("ParkingLot_StreetName");
                 a.Property(s => s.StreetNumber).HasColumnName("ParkingLot_StreetNumber");
                 a.Property(z => z.ZIP).HasColumnName("ParkingLot_City_ZIP");
             });

            modelBuilder.Entity<ParkingLot>()
                .HasOne(p => p.Division)
                .WithMany()
                .HasForeignKey(p => p.DivisionID)
                .IsRequired();

            modelBuilder.Entity<ParkingLot>()
                .OwnsOne(p => p.ContactPerson, p =>
                {
                    p.Property(x => x.FirstName).HasColumnName("ContactPerson_FirstName");
                    p.Property(x => x.LastName).HasColumnName("ContactPerson_LastName");
                    p.Property(x => x.Email).HasColumnName("ContactPerson_Email");
                    p.Property(x => x.PhoneNumber).HasColumnName("ContactPerson_PhoneNumber");
                    p.Property(x => x.MobilePhoneNumber).HasColumnName("ContactPerson_MobileNumber");
                });

            modelBuilder.Entity<ContactPerson>()
                .OwnsOne(a => a.Address, a =>
                {
                    a.Property(x => x.StreetName).HasColumnName("ContactPerson_StreetName");
                    a.Property(x => x.StreetNumber).HasColumnName("ContactPerson_StreetNumber");
                    a.Property(x => x.ZIP).HasColumnName("ContactPerson_City_ZIP");
                });

            modelBuilder.Entity<ParkingLot>()
                .HasOne(div => div.Division)
                .WithMany()
                .HasForeignKey(fr => fr.DivisionID)
                .IsRequired();

            base.OnModelCreating(modelBuilder);

        }

    }
}
