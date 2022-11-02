using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace WebApplication_P.Models
{
    public partial class doctorContext : DbContext
    {
        public doctorContext()
        {
        }

        public doctorContext(DbContextOptions<doctorContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Tbldoctor> Tbldoctors { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=Q3JP00103;Initial Catalog=doctor;Integrated Security=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Tbldoctor>(entity =>
            {
                entity.ToTable("Tbldoctor");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Gender).HasMaxLength(50);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
