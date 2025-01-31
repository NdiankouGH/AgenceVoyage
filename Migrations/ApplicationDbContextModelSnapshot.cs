﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace AgenceVoyage.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Agence_voyage.Models.Agence", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Adresse")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("character varying(200)");

                    b.Property<int>("GestionnaireId")
                        .HasColumnType("integer");

                    b.Property<float>("Latitude")
                        .HasColumnType("real");

                    b.Property<float>("Longitude")
                        .HasColumnType("real");

                    b.Property<string>("Ninea")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("character varying(20)");

                    b.Property<int>("Notes")
                        .HasColumnType("integer");

                    b.Property<string>("RCCM")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)");

                    b.HasKey("Id");

                    b.HasIndex("GestionnaireId");

                    b.ToTable("Agences");
                });

            modelBuilder.Entity("Agence_voyage.Models.Chauffeur", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<bool>("EstDisponible")
                        .HasColumnType("boolean");

                    b.Property<string>("Nom")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.HasKey("Id");

                    b.ToTable("Chauffeurs");
                });

            modelBuilder.Entity("Agence_voyage.Models.Flotte", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<bool>("EstDisponible")
                        .HasColumnType("boolean");

                    b.Property<string>("Matricule")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("character varying(20)");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)");

                    b.HasKey("Id");

                    b.ToTable("Flottes");
                });

            modelBuilder.Entity("Agence_voyage.Models.Offre", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("AgenceId")
                        .HasColumnType("integer");

                    b.Property<DateTime>("DateCreation")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("character varying(500)");

                    b.Property<bool>("Disponible")
                        .HasColumnType("boolean");

                    b.Property<int?>("GestionnaireId")
                        .HasColumnType("integer");

                    b.Property<decimal>("Prix")
                        .HasColumnType("numeric");

                    b.HasKey("Id");

                    b.HasIndex("AgenceId");

                    b.HasIndex("GestionnaireId");

                    b.ToTable("Offres");
                });

            modelBuilder.Entity("Agence_voyage.Models.Reservation", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("ClientId")
                        .HasColumnType("integer");

                    b.Property<DateTime>("Date")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Statut")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)");

                    b.Property<int>("VoyageId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("ClientId");

                    b.HasIndex("VoyageId");

                    b.ToTable("Reservations");
                });

            modelBuilder.Entity("Agence_voyage.Models.Utilisateur", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int?>("AdministrateurId")
                        .HasColumnType("integer");

                    b.Property<DateTime>("DateCreation")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.Property<string>("Nom")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)");

                    b.Property<string>("NumTel")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.Property<string>("Prenom")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)");

                    b.HasKey("Id");

                    b.HasIndex("AdministrateurId");

                    b.ToTable("Utilisateurs");

                    b.UseTptMappingStrategy();
                });

            modelBuilder.Entity("Agence_voyage.Models.Voyage", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("ChauffeurId")
                        .HasColumnType("integer");

                    b.Property<DateTime>("DateDepart")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime>("DateRetour")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("character varying(500)");

                    b.Property<int>("FlotteId")
                        .HasColumnType("integer");

                    b.Property<float>("Prix")
                        .HasColumnType("real");

                    b.HasKey("Id");

                    b.HasIndex("ChauffeurId");

                    b.HasIndex("FlotteId");

                    b.ToTable("Voyages");
                });

            modelBuilder.Entity("Agence_voyage.Models.Administrateur", b =>
                {
                    b.HasBaseType("Agence_voyage.Models.Utilisateur");

                    b.ToTable("Administrateurs", (string)null);
                });

            modelBuilder.Entity("Agence_voyage.Models.Client", b =>
                {
                    b.HasBaseType("Agence_voyage.Models.Utilisateur");

                    b.Property<string>("Adresse")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("character varying(200)");

                    b.Property<string>("NumPasseport")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("character varying(20)");

                    b.ToTable("Clients", (string)null);
                });

            modelBuilder.Entity("Agence_voyage.Models.Gestionnaire", b =>
                {
                    b.HasBaseType("Agence_voyage.Models.Utilisateur");

                    b.ToTable("Gestionnaires", (string)null);
                });

            modelBuilder.Entity("Agence_voyage.Models.Agence", b =>
                {
                    b.HasOne("Agence_voyage.Models.Gestionnaire", "Gestionnaire")
                        .WithMany("Agences")
                        .HasForeignKey("GestionnaireId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Gestionnaire");
                });

            modelBuilder.Entity("Agence_voyage.Models.Offre", b =>
                {
                    b.HasOne("Agence_voyage.Models.Agence", "Agence")
                        .WithMany("Offres")
                        .HasForeignKey("AgenceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Agence_voyage.Models.Gestionnaire", null)
                        .WithMany("Offres")
                        .HasForeignKey("GestionnaireId");

                    b.Navigation("Agence");
                });

            modelBuilder.Entity("Agence_voyage.Models.Reservation", b =>
                {
                    b.HasOne("Agence_voyage.Models.Client", "Client")
                        .WithMany("Reservations")
                        .HasForeignKey("ClientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Agence_voyage.Models.Voyage", "Voyage")
                        .WithMany("Reservations")
                        .HasForeignKey("VoyageId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Client");

                    b.Navigation("Voyage");
                });

            modelBuilder.Entity("Agence_voyage.Models.Utilisateur", b =>
                {
                    b.HasOne("Agence_voyage.Models.Administrateur", null)
                        .WithMany("UtilisateursGeres")
                        .HasForeignKey("AdministrateurId");
                });

            modelBuilder.Entity("Agence_voyage.Models.Voyage", b =>
                {
                    b.HasOne("Agence_voyage.Models.Chauffeur", "Chauffeur")
                        .WithMany("Voyages")
                        .HasForeignKey("ChauffeurId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Agence_voyage.Models.Flotte", "Flotte")
                        .WithMany("Voyages")
                        .HasForeignKey("FlotteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Chauffeur");

                    b.Navigation("Flotte");
                });

            modelBuilder.Entity("Agence_voyage.Models.Administrateur", b =>
                {
                    b.HasOne("Agence_voyage.Models.Utilisateur", null)
                        .WithOne()
                        .HasForeignKey("Agence_voyage.Models.Administrateur", "Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Agence_voyage.Models.Client", b =>
                {
                    b.HasOne("Agence_voyage.Models.Utilisateur", null)
                        .WithOne()
                        .HasForeignKey("Agence_voyage.Models.Client", "Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Agence_voyage.Models.Gestionnaire", b =>
                {
                    b.HasOne("Agence_voyage.Models.Utilisateur", null)
                        .WithOne()
                        .HasForeignKey("Agence_voyage.Models.Gestionnaire", "Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Agence_voyage.Models.Agence", b =>
                {
                    b.Navigation("Offres");
                });

            modelBuilder.Entity("Agence_voyage.Models.Chauffeur", b =>
                {
                    b.Navigation("Voyages");
                });

            modelBuilder.Entity("Agence_voyage.Models.Flotte", b =>
                {
                    b.Navigation("Voyages");
                });

            modelBuilder.Entity("Agence_voyage.Models.Voyage", b =>
                {
                    b.Navigation("Reservations");
                });

            modelBuilder.Entity("Agence_voyage.Models.Administrateur", b =>
                {
                    b.Navigation("UtilisateursGeres");
                });

            modelBuilder.Entity("Agence_voyage.Models.Client", b =>
                {
                    b.Navigation("Reservations");
                });

            modelBuilder.Entity("Agence_voyage.Models.Gestionnaire", b =>
                {
                    b.Navigation("Agences");

                    b.Navigation("Offres");
                });
#pragma warning restore 612, 618
        }
    }
}
