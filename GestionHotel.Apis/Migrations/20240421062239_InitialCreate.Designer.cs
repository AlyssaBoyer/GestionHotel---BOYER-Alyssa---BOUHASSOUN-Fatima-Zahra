﻿// <auto-generated />
using System;
using GestionHotel.Apis;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace GestionHotel.Apis.Migrations
{
    [DbContext(typeof(HotelDbContext))]
    [Migration("20240421062239_InitialCreate")]
    partial class InitialCreate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "9.0.0-preview.3.24172.4");

            modelBuilder.Entity("GestionHotel.Apis.Models.Chambre", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("Capacite")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("EstANettoyer")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("EstNettoyee")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("EstOccupee")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("Etat")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Numero")
                        .HasColumnType("INTEGER");

                    b.Property<decimal>("Tarif")
                        .HasColumnType("TEXT");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Chambres");
                });

            modelBuilder.Entity("GestionHotel.Apis.Models.Personne", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasMaxLength(21)
                        .HasColumnType("TEXT");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("MotPasse")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Nom")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Prenom")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Personne");

                    b.HasDiscriminator<string>("Discriminator").HasValue("Personne");

                    b.UseTphMappingStrategy();
                });

            modelBuilder.Entity("GestionHotel.Apis.Models.Reservation", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("ChambreReserveeId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("ClientId")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("DateDebut")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("DateFin")
                        .HasColumnType("TEXT");

                    b.Property<bool>("EstAnnulee")
                        .HasColumnType("INTEGER");

                    b.Property<decimal>("Montant")
                        .HasColumnType("TEXT");

                    b.Property<bool>("StatutPaiement")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("ChambreReserveeId");

                    b.HasIndex("ClientId");

                    b.ToTable("Reservations");
                });

            modelBuilder.Entity("GestionHotel.Apis.Models.Client", b =>
                {
                    b.HasBaseType("GestionHotel.Apis.Models.Personne");

                    b.Property<string>("NumeroCarteCredit")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasDiscriminator().HasValue("Client");
                });

            modelBuilder.Entity("GestionHotel.Apis.Models.Receptionniste", b =>
                {
                    b.HasBaseType("GestionHotel.Apis.Models.Personne");

                    b.HasDiscriminator().HasValue("Receptionniste");
                });

            modelBuilder.Entity("GestionHotel.Models.PersonnelMenage", b =>
                {
                    b.HasBaseType("GestionHotel.Apis.Models.Personne");

                    b.Property<string>("Fonction")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasDiscriminator().HasValue("PersonnelMenage");
                });

            modelBuilder.Entity("GestionHotel.Apis.Models.Reservation", b =>
                {
                    b.HasOne("GestionHotel.Apis.Models.Chambre", "ChambreReservee")
                        .WithMany()
                        .HasForeignKey("ChambreReserveeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("GestionHotel.Apis.Models.Client", "Client")
                        .WithMany()
                        .HasForeignKey("ClientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ChambreReservee");

                    b.Navigation("Client");
                });
#pragma warning restore 612, 618
        }
    }
}
