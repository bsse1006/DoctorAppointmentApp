using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;

namespace ServerApp.Model
{
    public class DatabaseContext: DbContext
    {
        private const string ConnectionString = @"Server=DESKTOP-F0K8OEK;Database=DoctorAppointmentAppDatabase;Trusted_Connection=true";

        public DbSet<Doctor> doctors { get; set; }

        public DbSet<Patient> patients { get; set; }

        public DbSet<Appointment> appointments { get; set; }

        public DbSet<Admin> admins { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(ConnectionString);
        }
    }
}
