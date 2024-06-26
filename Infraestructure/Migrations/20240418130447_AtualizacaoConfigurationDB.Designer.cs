﻿// <auto-generated />
using System;
using Infraestructure.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Infraestructure.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20240418130447_AtualizacaoConfigurationDB")]
    partial class AtualizacaoConfigurationDB
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.18")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Core.Entities.Cliente", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INT");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("CPF")
                        .IsRequired()
                        .HasColumnType("VARCHAR(11)")
                        .HasColumnName("CPF");

                    b.Property<DateTime>("Criado")
                        .HasColumnType("DATETIME")
                        .HasColumnName("Criado");

                    b.Property<string>("DataNascimento")
                        .IsRequired()
                        .HasColumnType("VARCHAR(100)")
                        .HasColumnName("Data_Nascimento");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("VARCHAR(100)")
                        .HasColumnName("Nome");

                    b.HasKey("Id");

                    b.ToTable("Cliente", (string)null);
                });

            modelBuilder.Entity("Core.Entities.Livro", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INT");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("Criado")
                        .HasColumnType("DATETIME")
                        .HasColumnName("Criado");

                    b.Property<string>("Editora")
                        .IsRequired()
                        .HasColumnType("VARCHAR(100)")
                        .HasColumnName("Editora");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("VARCHAR(100)")
                        .HasColumnName("Nome");

                    b.HasKey("Id");

                    b.ToTable("Livro", (string)null);
                });

            modelBuilder.Entity("Core.Entities.Pedido", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INT");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("ClienteId")
                        .HasColumnType("INT");

                    b.Property<DateTime>("Criado")
                        .HasColumnType("DATETIME")
                        .HasColumnName("Criado");

                    b.Property<int>("LivroId")
                        .HasColumnType("INT");

                    b.HasKey("Id");

                    b.HasIndex("ClienteId");

                    b.HasIndex("LivroId");

                    b.ToTable("Pedido", (string)null);
                });

            modelBuilder.Entity("Core.Entities.Pedido", b =>
                {
                    b.HasOne("Core.Entities.Cliente", "Cliente")
                        .WithMany("Pedidos")
                        .HasForeignKey("ClienteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Core.Entities.Livro", "Livro")
                        .WithMany("Pedidos")
                        .HasForeignKey("LivroId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Cliente");

                    b.Navigation("Livro");
                });

            modelBuilder.Entity("Core.Entities.Cliente", b =>
                {
                    b.Navigation("Pedidos");
                });

            modelBuilder.Entity("Core.Entities.Livro", b =>
                {
                    b.Navigation("Pedidos");
                });
#pragma warning restore 612, 618
        }
    }
}
