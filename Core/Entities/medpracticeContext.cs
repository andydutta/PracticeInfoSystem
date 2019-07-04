using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace PracticeInfoSystem
{
    public partial class medpracticeContext : DbContext
    {
        public medpracticeContext()
        {
        }

        public medpracticeContext(DbContextOptions<medpracticeContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Doctor> Doctor { get; set; }
        public virtual DbSet<DoctorSpecialty> DoctorSpecialty { get; set; }
        public virtual DbSet<Language> Language { get; set; }
        public virtual DbSet<MedicalSchool> MedicalSchool { get; set; }
        public virtual DbSet<PatientRating> PatientRating { get; set; }
        public virtual DbSet<Specialty> Specialty { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlite("Datasource=C:\\SqlLite\\medpractice.db");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Doctor>(entity =>
            {
                entity.HasIndex(e => e.Id)
                    .IsUnique();

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Gender).HasColumnType("STRING");

                entity.Property(e => e.Name).HasColumnType("STRING");

                entity.HasOne(d => d.Language)
                    .WithMany(p => p.Doctor)
                    .HasForeignKey(d => d.LanguageId)
                    .OnDelete(DeleteBehavior.ClientSetNull);

                entity.HasOne(d => d.MedicalSchool)
                    .WithMany(p => p.Doctor)
                    .HasForeignKey(d => d.MedicalSchoolId)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });

            modelBuilder.Entity<DoctorSpecialty>(entity =>
            {
                entity.HasKey(e => e.DoctorId);

                entity.Property(e => e.DoctorId).ValueGeneratedNever();

                entity.HasOne(d => d.Doctor)
                    .WithOne(p => p.DoctorSpecialty)
                    .HasForeignKey<DoctorSpecialty>(d => d.DoctorId)
                    .OnDelete(DeleteBehavior.ClientSetNull);

                entity.HasOne(d => d.Specialty)
                    .WithMany(p => p.DoctorSpecialty)
                    .HasForeignKey(d => d.SpecialtyId)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });

            modelBuilder.Entity<Language>(entity =>
            {
                entity.HasIndex(e => e.Id)
                    .IsUnique();

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Name).HasColumnType("STRING");
            });

            modelBuilder.Entity<MedicalSchool>(entity =>
            {
                entity.HasIndex(e => e.Id)
                    .IsUnique();

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Name).HasColumnType("STRING");
            });

            modelBuilder.Entity<PatientRating>(entity =>
            {
                entity.HasKey(e => e.DoctorId);

                entity.Property(e => e.DoctorId).ValueGeneratedNever();

                entity.Property(e => e.Comments).HasColumnType("STRING");

                entity.Property(e => e.Rating).HasColumnType("STRING");

                entity.HasOne(d => d.Doctor)
                    .WithOne(p => p.PatientRating)
                    .HasForeignKey<PatientRating>(d => d.DoctorId)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });

            modelBuilder.Entity<Specialty>(entity =>
            {
                entity.HasIndex(e => e.Id)
                    .IsUnique();

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Name).HasColumnType("STRING");
            });
        }
    }
}
