﻿using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace WebAPI.Models
{
    public partial class ClinicContext : IdentityDbContext<User>
    {
        protected readonly IConfiguration configuration;

        public ClinicContext(IConfiguration configuration) 
        {
            this.configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Doctor>(entity =>
            {
                entity.HasOne(d => d.Specialization)
                .WithMany(p => p.Doctor)
                .HasForeignKey(d => d.SpecializationId);
            });

            modelBuilder.Entity<ScheduleWeek>(entity =>
            {
                entity.HasOne(d => d.Doctor)
                .WithMany(p => p.ScheduleWeek)
                .HasForeignKey(d => d.DoctorId);
            });

            modelBuilder.Entity<ScheduleDay>(entity =>
            {
                entity.HasOne(d => d.ScheduleWeek)
                .WithMany(p => p.ScheduleDay)
                .HasForeignKey(d => d.ScheduleWeekId);
            });

            modelBuilder.Entity<ScheduleDay>(entity =>
            {
                entity.HasOne(d => d.DayOfWeek)
                .WithMany(p => p.ScheduleDay)
                .HasForeignKey(d => d.DayOfWeekId);
            });

            modelBuilder.Entity<Appointment>(entity =>
            {
                entity.HasOne(d => d.Patient)
                .WithMany(p => p.Appointment)
                .HasForeignKey(d => d.PatientId);
            });

            modelBuilder.Entity<Appointment>(entity =>
            {
                entity.HasOne(d => d.Doctor)
                .WithMany(p => p.Appointment)
                .HasForeignKey(d => d.DoctorId);
            });

            modelBuilder.Entity<Appointment>(entity =>
            {
                entity.HasOne(d => d.Service)
                .WithMany(p => p.Appointment)
                .HasForeignKey(d => d.ServiceId);
            });

        }

        public virtual DbSet<Appointment> Appointment { get; set; }
        public virtual DbSet<DayOfWeek> DayOfWeek { get; set; }
        public virtual DbSet<Doctor> Doctor { get; set; }
        public virtual DbSet<Patient> Patient { get; set; }
        public virtual DbSet<ScheduleDay> ScheduleDay { get; set; }
        public virtual DbSet<ScheduleWeek> ScheduleWeek { get; set; }
        public virtual DbSet<Service> Service { get; set; }
        public virtual DbSet<Specialization> Specialization { get; set; }
    }
}
