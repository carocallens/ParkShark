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
            LinkDivisionTableToDivision(modelBuilder);
            LinkCityTableToCity(modelBuilder);
            LinkMemberTableToMember(modelBuilder);
            LinkLicensePlateTableToLicensePlate(modelBuilder);
            LinkPhoneNumberTableToPhoneNumber(modelBuilder);
            LinkMemberShipLevelTableToMemberShipLevel(modelBuilder);
            LinkParkingLotTableToParkingLot(modelBuilder);

            base.OnModelCreating(modelBuilder);

        }

        private static void LinkDivisionTableToDivision(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Division>()
                .ToTable("Division", "Div")
                .HasKey(d => d.DivisionID);

            modelBuilder.Entity<Division>()
                .Property(d => d.DivisionID).HasColumnName("Division_ID");
            modelBuilder.Entity<Division>()
                .Property(d => d.Director).HasColumnName("Division_Director");
            modelBuilder.Entity<Division>()
                .Property(d => d.Name).HasColumnName("Division_Name");
            modelBuilder.Entity<Division>()
                .Property(d => d.OriginalName).HasColumnName("Division_OrgName");
            modelBuilder.Entity<Division>()
                .Property(d => d.ParentDivisionID).HasColumnName("Division_ParentDivisionGuidId");

            modelBuilder.Entity<Division>()
                .HasOne(pard => pard.ParentDivision)
                .WithMany(subd => subd.SubdivisionsList)
                .HasForeignKey(d => d.ParentDivisionID);
        }

        private static void LinkCityTableToCity(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<City>()
                .ToTable("Cities", "Mem")
                .HasKey(c => c.ZIP);

            modelBuilder.Entity<City>()
                .Property(c => c.ZIP).HasColumnName("City_ZIP");
            modelBuilder.Entity<City>()
                .Property(c => c.CityName).HasColumnName("City_Name");
            modelBuilder.Entity<City>()
                .Property(c => c.CountryName).HasColumnName("City_CountryName");

            modelBuilder.Entity<Address>()
                .HasOne(a => a.City)
                .WithMany()
                .HasForeignKey(a => a.ZIP)
                .IsRequired();
        }

        private static void LinkMemberTableToMember(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Member>()
                .ToTable("Members", "Mem")
                .HasKey(m => m.MemberId);

            modelBuilder.Entity<Member>()
                .Property(m => m.MemberId).HasColumnName("Member_ID");
            modelBuilder.Entity<Member>()
                .Property(m => m.FirstName).HasColumnName("Member_FirstName");
            modelBuilder.Entity<Member>()
                .Property(m => m.LastName).HasColumnName("Member_LastName");
            modelBuilder.Entity<Member>()
                .Property(m => m.RegistrationDate).HasColumnName("Member_RegistrationDate");
            modelBuilder.Entity<Member>()
                .Property(m => m.MembershipLevelId).HasConversion(
                    ml => Convert.ToInt32(ml),
                    mlid => (MembershipLevelEnum)mlid)
                .HasColumnName("Member_MembershipLevel_ID");

            modelBuilder.Entity<Member>()
                .OwnsOne(m => m.Address, a =>
                {
                    a.Property(b => b.StreetName).HasColumnName("Member_StreetName");
                    a.Property(s => s.StreetNumber).HasColumnName("Member_StreetNumber");
                    a.Property(z => z.ZIP).HasColumnName("City_ZIP");
                });
        }

        private static void LinkLicensePlateTableToLicensePlate(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<LicensePlate>()
                .ToTable("LicensePlates", "Mem")
                .HasKey(lp => new
                {
                    lp.MemberId,
                    lp.LicensePlateValue
                });

            modelBuilder.Entity<LicensePlate>()
                .Property(lp => lp.MemberId).HasColumnName("Member_ID");
            modelBuilder.Entity<LicensePlate>()
                .Property(lp => lp.LicensePlateValue).HasColumnName("LicensePlate");
            modelBuilder.Entity<LicensePlate>()
                .Property(lp => lp.IssueingCountry).HasColumnName("IssueingCountry");

            modelBuilder.Entity<LicensePlate>()
                .HasOne(lp => lp.Member)
                .WithMany()
                .HasForeignKey(lp => lp.MemberId)
                .IsRequired();
        }

        private static void LinkPhoneNumberTableToPhoneNumber(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PhoneNumber>()
                .ToTable("PhoneNumbers", "Mem")
                .HasKey(ph => new
                {
                    ph.MemberId,
                    ph.PhoneNumberValue
                });

            modelBuilder.Entity<PhoneNumber>()
                .HasOne(ph => ph.Member)
                .WithMany()
                .HasForeignKey(ph => ph.MemberId)
                .IsRequired();
        }

        private static void LinkMemberShipLevelTableToMemberShipLevel(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MembershipLevel>()
             .ToTable("MembershipLevel", "Mem")
             .HasKey(ml => ml.MemberShipLevelId);
                        
            modelBuilder.Entity<MembershipLevel>()
               .Property(ml => ml.MemberShipLevelId).HasColumnName("MembershipLevel_ID");
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
                .HasForeignKey(m => m.MembershipLevelId)
                .IsRequired();
        }

        private static void LinkParkingLotTableToParkingLot(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ParkingLot>()
                .ToTable("ParkingLots", "PL")
                .HasKey(pl => pl.ParkingLotID);

            modelBuilder.Entity<ParkingLot>()
                .Property(pl => pl.ParkingLotID).HasColumnName("ParkingLot_ID");
            modelBuilder.Entity<ParkingLot>()
                .Property(pl => pl.Name).HasColumnName("ParkingLot_Name");
            modelBuilder.Entity<ParkingLot>()
                .Property(pl => pl.DivisionID).HasColumnName("Division_ID");
            modelBuilder.Entity<ParkingLot>()
                .Property(pl => pl.Capacity).HasColumnName("ParkingLot_Capacity");
            modelBuilder.Entity<ParkingLot>()
                .Property(pl => pl.BuildingType)
                .HasConversion<string>()
                .HasColumnName("BuildingType");
            modelBuilder.Entity<ParkingLot>()
                .Property(pl => pl.PricePerHour).HasColumnName("ParkingLot_PricePerHour");
            
            modelBuilder.Entity<ParkingLot>()
             .OwnsOne(pl => pl.Address, a =>
             {
                 a.Property(ad => ad.StreetName).HasColumnName("ParkingLot_StreetName");
                 a.Property(ad => ad.StreetNumber).HasColumnName("ParkingLot_StreetNumber");
                 a.Property(ad => ad.ZIP).HasColumnName("ParkingLot_City_ZIP");
             });

            modelBuilder.Entity<ParkingLot>()
                .OwnsOne(pl => pl.ContactPerson, cp =>
                {
                    cp.Property(p => p.FirstName).HasColumnName("ContactPerson_FirstName");
                    cp.Property(p => p.LastName).HasColumnName("ContactPerson_LastName");
                    cp.Property(p => p.Email).HasColumnName("ContactPerson_Email");
                    cp.Property(p => p.PhoneNumber).HasColumnName("ContactPerson_PhoneNumber");
                    cp.Property(p => p.MobilePhoneNumber).HasColumnName("ContactPerson_MobileNumber");
                });
            modelBuilder.Entity<ContactPerson>()
                .OwnsOne(cp => cp.Address, a =>
                {
                    a.Property(ad => ad.StreetName).HasColumnName("ContactPerson_StreetName");
                    a.Property(ad => ad.StreetNumber).HasColumnName("ContactPerson_StreetNumber");
                    a.Property(ad => ad.ZIP).HasColumnName("ContactPerson_City_ZIP");
                });

            modelBuilder.Entity<ParkingLot>()
                .HasOne(div => div.Division)
                .WithMany()
                .HasForeignKey(fr => fr.DivisionID)
                .IsRequired();
        }






    }
}
