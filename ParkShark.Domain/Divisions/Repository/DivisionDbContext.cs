using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;

namespace ParkShark.Domain.Divisions.Repository
{
    public class DivisionDbContext : DbContext
    {

        private readonly string connectionString;
        private readonly ILoggerFactory loggerFactory;

        public virtual DbSet<Division> Division { get; set; }

        public DivisionDbContext(DbContextOptions options) : base(options)
        { }
        public DivisionDbContext(string connectionString, ILoggerFactory loggerFactory = null)
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
            modelBuilder.Entity<Division>()
                .ToTable("Division", "Div")
                .HasKey(e => e.GuidID);

            modelBuilder.Entity<Division>()
                .Property(d => d.GuidID).HasColumnName("Division_ID");
            modelBuilder.Entity<Division>()
                .Property(d => d.Director).HasColumnName("Division_Director");
            modelBuilder.Entity<Division>()
                .Property(d => d.Name).HasColumnName("Division_Name");
            modelBuilder.Entity<Division>()
                .Property(d => d.OriginalName).HasColumnName("Division_OrgName");
            base.OnModelCreating(modelBuilder);

        }



    }
}
