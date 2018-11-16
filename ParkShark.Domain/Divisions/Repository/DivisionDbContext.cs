using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;

namespace ParkShark.Domain.Divisions.Repository
{
    public class DivisionDbContext : DbContext
    {
        public virtual DbSet<Division> Division { get; set; }

        public DivisionDbContext(DbContextOptions options) : base(options)
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
                .Property(d => d.OriginalName).HasColumnName("Division_ParentDivisionID");

            base.OnModelCreating(modelBuilder);

        }



    }
}
