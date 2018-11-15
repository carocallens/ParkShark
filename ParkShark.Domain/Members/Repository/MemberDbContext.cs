using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;

namespace ParkShark.Domain.Members.Repository
{
    public class MemberDbContext : DbContext
    {
        private readonly string connectionString;
        private readonly ILoggerFactory loggerFactory;

        public virtual DbSet<Member> Members { get; set; }

        public MemberDbContext(string connectionString, ILoggerFactory loggerFactory = null)
        {
            this.connectionString = connectionString;
            this.loggerFactory = loggerFactory;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder
                .UseSqlServer(connectionString);

            if (loggerFactory != null)
                optionsBuilder.UseLoggerFactory(loggerFactory);

            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Member>()
                .ToTable("Members", "Div")
                .HasKey(m => m.MemberId);

            modelBuilder.Entity<Member>()
                .Property(m => m.MemberId).HasColumnName("Member_ID");
            modelBuilder.Entity<Member>()
                .Property(m => m.FirstName).HasColumnName("Member_FirstName");
            modelBuilder.Entity<Member>()
                .Property(m => m.LastName).HasColumnName("Member_LastName");
            modelBuilder.Entity<Member>()
                .Property(m => m.Address.StreetName).HasColumnName("Member_StreetName");
            modelBuilder.Entity<Member>()
                .Property(m => m.Address.StreetNumber).HasColumnName("Member_StreetNumber");
            modelBuilder.Entity<Member>()
                .Property(m => m.Address.ZIP).HasColumnName("City_ZIP");
            modelBuilder.Entity<Member>()
                .Property(m => m.RegistrationDate).HasColumnName("Member_RegistrationDate");

            modelBuilder.Entity<Member>()
                .HasOne(m => m.Address.City)
                .WithMany()
                .HasForeignKey(m => m.Address.ZIP)
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

            base.OnModelCreating(modelBuilder);
        }
    }
}
