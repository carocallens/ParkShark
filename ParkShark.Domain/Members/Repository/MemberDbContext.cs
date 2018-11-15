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
                .Property(m => m.AddressId).HasColumnName("Address_ID");
            modelBuilder.Entity<Member>()
                .Property(m => m.RegistrationDate).HasColumnName("Member_RegistrationDate");

            //A member must have one address and an address can have only one member
            modelBuilder.Entity<Member>()
                .HasOne(m => m.AddressId)
                .f
                .WithOne(m => )


            //An Address has one city but a city can have many addresses

            //A member can have many phone numbers but a phone number can have only one member

            //A member can have many license plates but a license plate can have only one member

            base.OnModelCreating(modelBuilder);

        }
    }
}
