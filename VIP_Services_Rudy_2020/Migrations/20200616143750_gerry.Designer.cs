﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using VIP_Services_Rudy_2020.DataLayer;

namespace VIP_Services_Rudy_2020.Migrations
{
    [DbContext(typeof(Context))]
    [Migration("20200616143750_gerry")]
    partial class gerry
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("VIP_Services_Rudy_2020.BusinessLayer.Models.Klant", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Adres")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("BTWnummer")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Categorie")
                        .HasColumnType("int");

                    b.Property<string>("Naam")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("Klanten");
                });

            modelBuilder.Entity("VIP_Services_Rudy_2020.BusinessLayer.Models.Limousine", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<double>("EersteUur")
                        .HasColumnType("float");

                    b.Property<string>("Naam")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Nightlife")
                        .HasColumnType("float");

                    b.Property<double>("Wedding")
                        .HasColumnType("float");

                    b.Property<double>("Wellness")
                        .HasColumnType("float");

                    b.HasKey("ID");

                    b.ToTable("Limousines");
                });

            modelBuilder.Entity("VIP_Services_Rudy_2020.BusinessLayer.Models.Locatie", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Naam")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("StraatNaam")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("straatNummer")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("Locaties");
                });

            modelBuilder.Entity("VIP_Services_Rudy_2020.BusinessLayer.Models.Reservering", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<double>("Cost")
                        .HasColumnType("float");

                    b.Property<int?>("EindPlaatsID")
                        .HasColumnType("int");

                    b.Property<int>("GereserveerdeTijd")
                        .HasColumnType("int");

                    b.Property<int?>("KlantID")
                        .HasColumnType("int");

                    b.Property<int?>("LimousineID")
                        .HasColumnType("int");

                    b.Property<int>("ReservatieType")
                        .HasColumnType("int");

                    b.Property<DateTime>("StartDatum")
                        .HasColumnType("datetime2");

                    b.Property<int?>("StratPlaatsID")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("EindPlaatsID");

                    b.HasIndex("KlantID");

                    b.HasIndex("LimousineID");

                    b.HasIndex("StratPlaatsID");

                    b.ToTable("Reserveringen");
                });

            modelBuilder.Entity("VIP_Services_Rudy_2020.BusinessLayer.Models.Staffelkorting", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Aantal")
                        .HasColumnType("int");

                    b.Property<int>("KlantType")
                        .HasColumnType("int");

                    b.Property<double>("Korting")
                        .HasColumnType("float");

                    b.HasKey("ID");

                    b.ToTable("Staffelkortingen");
                });

            modelBuilder.Entity("VIP_Services_Rudy_2020.BusinessLayer.Models.Reservering", b =>
                {
                    b.HasOne("VIP_Services_Rudy_2020.BusinessLayer.Models.Locatie", "EindPlaats")
                        .WithMany()
                        .HasForeignKey("EindPlaatsID");

                    b.HasOne("VIP_Services_Rudy_2020.BusinessLayer.Models.Klant", "Klant")
                        .WithMany()
                        .HasForeignKey("KlantID");

                    b.HasOne("VIP_Services_Rudy_2020.BusinessLayer.Models.Limousine", "Limousine")
                        .WithMany()
                        .HasForeignKey("LimousineID");

                    b.HasOne("VIP_Services_Rudy_2020.BusinessLayer.Models.Locatie", "StratPlaats")
                        .WithMany()
                        .HasForeignKey("StratPlaatsID");
                });
#pragma warning restore 612, 618
        }
    }
}
