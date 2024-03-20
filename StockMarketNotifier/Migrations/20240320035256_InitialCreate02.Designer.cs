﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using StockUpdates.Context;

namespace StockMarketNotifier.Migrations
{
    [DbContext(typeof(StockUpdatesContext))]
    [Migration("20240320035256_InitialCreate02")]
    partial class InitialCreate02
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("StockMarketNotifier.Models.Client", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Country")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("clientsId")
                        .HasColumnType("int");

                    b.Property<bool>("isUpdated")
                        .HasColumnType("bit");

                    b.Property<DateTime>("lastupdated")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("clientsId");

                    b.ToTable("clients");
                });

            modelBuilder.Entity("StockMarketNotifier.Models.Stock", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<decimal>("c")
                        .HasColumnName("close_price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("h")
                        .HasColumnName("highest_price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("l")
                        .HasColumnName("lowest_price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("n")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("o")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("v")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("vw")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.ToTable("Stocks");
                });

            modelBuilder.Entity("StockMarketNotifier.Models.Client", b =>
                {
                    b.HasOne("StockMarketNotifier.Models.Client", "clients")
                        .WithMany()
                        .HasForeignKey("clientsId");
                });
#pragma warning restore 612, 618
        }
    }
}
