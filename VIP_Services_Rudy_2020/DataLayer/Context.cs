using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;
using VIP_Services_Rudy_2020.BusinessLayer;
using VIP_Services_Rudy_2020.BusinessLayer.Models;

namespace VIP_Services_Rudy_2020.DataLayer
{
    public class Context : DbContext
    {
        private string connectionString;

        public DbSet<Klant> Klanten { get; set; }
        public DbSet<Staffelkorting> Staffelkortingen { get; set; }
        public DbSet<Limousine> Limousines { get; set; }
        public DbSet<Locatie> Locaties { get; set; }
        public DbSet<Reservering> Reserveringen { get; set; }
        public Context()
        {
        }

        public Context(string db = "Production") : base()
        {
            SetConnectionString(db);
        }

        private void SetConnectionString(string db = "Production")
        {
            var builder = new ConfigurationBuilder();
            builder.AddJsonFile(@"AppSettings.json", optional: false);

            var configuration = builder.Build();
            switch (db)
            {
                case "Production":
                    connectionString = configuration.GetConnectionString("ProdSQLconnection").ToString();
                    break;
                case "Test":
                    connectionString = configuration.GetConnectionString("TestSQLconnection").ToString();
                    break;
            }
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (connectionString == null)
            {
                SetConnectionString();
            }
            optionsBuilder.UseSqlServer(connectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Klant>().ToTable("Klanten");
            modelBuilder.Entity<Staffelkorting>().ToTable("Staffelkortingen");
            modelBuilder.Entity<Limousine>().ToTable("Limousines");
            modelBuilder.Entity<Locatie>().ToTable("Locaties");
            modelBuilder.Entity<Reservering>().ToTable("Reserveringen");


            modelBuilder.Entity<Reservering>()
                .HasOne(rs => rs.Klant)
                .WithMany();
            modelBuilder.Entity<Reservering>()
                .HasOne(rs => rs.StartPlaats)
                .WithMany();
            modelBuilder.Entity<Reservering>()
                .HasOne(rs => rs.EindPlaats)
                .WithMany();
            modelBuilder.Entity<Reservering>()
                .HasOne(rs => rs.Limousine)
                .WithMany();

            
        }


    }
}
