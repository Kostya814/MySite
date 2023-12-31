﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using MySite;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace MySite.Migrations
{
    [DbContext(typeof(PostgresContext))]
    [Migration("20231205123850_new")]
    partial class @new
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("MySite.Address", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("LeterHome")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("NameLocality")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("NameStreet")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("NumberApartments")
                        .HasColumnType("integer");

                    b.Property<int>("NumberCase")
                        .HasColumnType("integer");

                    b.Property<int>("NumberHouse")
                        .HasColumnType("integer");

                    b.Property<int>("NumberRoom")
                        .HasColumnType("integer");

                    b.Property<string>("PrefixLocality")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("PrefixStreet")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Addresses");
                });
#pragma warning restore 612, 618
        }
    }
}
