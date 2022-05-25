﻿// <auto-generated />
using System;
using AziendaTicketAMM_EF;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace AziendaTicketAMM_EF.Migrations
{
    [DbContext(typeof(Context))]
    [Migration("20220225140731_First")]
    partial class First
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.19")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("AziendaTicketAMM_CORE.Models.Categoria", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Descrizione")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NomeCategoria")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Categorie");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Descrizione = "Descrizione System",
                            NomeCategoria = "System"
                        },
                        new
                        {
                            Id = 2,
                            Descrizione = "descrizione Development",
                            NomeCategoria = "Development"
                        },
                        new
                        {
                            Id = 3,
                            Descrizione = "descrizione Office App",
                            NomeCategoria = "Office Application"
                        },
                        new
                        {
                            Id = 4,
                            Descrizione = "descrizione SAP",
                            NomeCategoria = "SAP"
                        },
                        new
                        {
                            Id = 5,
                            Descrizione = "descrizione other",
                            NomeCategoria = "Other"
                        });
                });

            modelBuilder.Entity("AziendaTicketAMM_CORE.Models.Stato", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("NomeStato")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Stati");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            NomeStato = "Nuovo"
                        },
                        new
                        {
                            Id = 2,
                            NomeStato = "Assegnato"
                        },
                        new
                        {
                            Id = 3,
                            NomeStato = "In Risoluzione"
                        },
                        new
                        {
                            Id = 4,
                            NomeStato = "Chiuso"
                        });
                });

            modelBuilder.Entity("AziendaTicketAMM_CORE.Models.Ticket", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Assegnatario")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("DataChiusura")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DataCreazione")
                        .HasColumnType("datetime2");

                    b.Property<string>("DescrizioneBreve")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DescrizioneLunga")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("IDCategoria")
                        .HasColumnType("int");

                    b.Property<int>("IDStato")
                        .HasColumnType("int");

                    b.Property<string>("Richiedente")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("IDCategoria");

                    b.HasIndex("IDStato");

                    b.ToTable("Tickets");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            DataCreazione = new DateTime(2022, 1, 12, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            DescrizioneBreve = "descrizione breve 1",
                            DescrizioneLunga = "descrizione lunga 1",
                            IDCategoria = 1,
                            IDStato = 1,
                            Richiedente = "Alessia"
                        });
                });

            modelBuilder.Entity("AziendaTicketAMM_CORE.Models.Ticket", b =>
                {
                    b.HasOne("AziendaTicketAMM_CORE.Models.Categoria", "Categoria")
                        .WithMany("Tickets")
                        .HasForeignKey("IDCategoria")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("AziendaTicketAMM_CORE.Models.Stato", "Stato")
                        .WithMany("Tickets")
                        .HasForeignKey("IDStato")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}