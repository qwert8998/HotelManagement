﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TzuChing.HotelManagement.Infrastructure.Data;

namespace TzuChing.HotelManagement.Infrastructure.Migrations
{
    [DbContext(typeof(HotelManagementDBContext))]
    [Migration("20210519010519_RoomUpdated")]
    partial class RoomUpdated
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.5")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("TzuChing.HotelManagement.ApplicationCore.Entities.Customers", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Address")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<decimal?>("Advance")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int?>("BookingDays")
                        .HasColumnType("int");

                    b.Property<string>("CName")
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<DateTime?>("CheckIn")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .HasMaxLength(40)
                        .HasColumnType("nvarchar(40)");

                    b.Property<string>("Phone")
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<int?>("RoomId")
                        .HasColumnType("int")
                        .HasColumnName("RoomNo");

                    b.Property<int?>("TotalPersons")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("RoomId");

                    b.ToTable("Customer");
                });

            modelBuilder.Entity("TzuChing.HotelManagement.ApplicationCore.Entities.RoomTypes", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("RTDESC")
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<decimal?>("Rent")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.ToTable("RoomType");
                });

            modelBuilder.Entity("TzuChing.HotelManagement.ApplicationCore.Entities.Rooms", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("RoomTypeId")
                        .HasMaxLength(20)
                        .HasColumnType("int")
                        .HasColumnName("RTCode");

                    b.Property<bool?>("Status")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(true);

                    b.HasKey("Id");

                    b.HasIndex("RoomTypeId");

                    b.ToTable("Room");
                });

            modelBuilder.Entity("TzuChing.HotelManagement.ApplicationCore.Entities.Services", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("RoomId")
                        .HasColumnType("int")
                        .HasColumnName("RoomNo");

                    b.Property<string>("SDESC")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<DateTime?>("ServiceDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("RoomId");

                    b.ToTable("Service");
                });

            modelBuilder.Entity("TzuChing.HotelManagement.ApplicationCore.Entities.Customers", b =>
                {
                    b.HasOne("TzuChing.HotelManagement.ApplicationCore.Entities.Rooms", "Room")
                        .WithMany("Customer")
                        .HasForeignKey("RoomId");

                    b.Navigation("Room");
                });

            modelBuilder.Entity("TzuChing.HotelManagement.ApplicationCore.Entities.Rooms", b =>
                {
                    b.HasOne("TzuChing.HotelManagement.ApplicationCore.Entities.RoomTypes", "RoomType")
                        .WithMany("Room")
                        .HasForeignKey("RoomTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("RoomType");
                });

            modelBuilder.Entity("TzuChing.HotelManagement.ApplicationCore.Entities.Services", b =>
                {
                    b.HasOne("TzuChing.HotelManagement.ApplicationCore.Entities.Rooms", "Room")
                        .WithMany("Service")
                        .HasForeignKey("RoomId");

                    b.Navigation("Room");
                });

            modelBuilder.Entity("TzuChing.HotelManagement.ApplicationCore.Entities.RoomTypes", b =>
                {
                    b.Navigation("Room");
                });

            modelBuilder.Entity("TzuChing.HotelManagement.ApplicationCore.Entities.Rooms", b =>
                {
                    b.Navigation("Customer");

                    b.Navigation("Service");
                });
#pragma warning restore 612, 618
        }
    }
}