﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WorkShop.Data;

#nullable disable

namespace WorkShop.Migrations
{
    [DbContext(typeof(WorkshopDbContext))]
    [Migration("20230630113503_First")]
    partial class First
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("ItemKit", b =>
                {
                    b.Property<int>("ID_Item")
                        .HasColumnType("int");

                    b.Property<int>("ID_Kit")
                        .HasColumnType("int");

                    b.HasKey("ID_Item", "ID_Kit");

                    b.HasIndex("ID_Kit");

                    b.ToTable("ItemKit");
                });

            modelBuilder.Entity("ItemOrder", b =>
                {
                    b.Property<int>("ItemsID")
                        .HasColumnType("int");

                    b.Property<int>("OrdersID")
                        .HasColumnType("int");

                    b.HasKey("ItemsID", "OrdersID");

                    b.HasIndex("OrdersID");

                    b.ToTable("ItemOrder");
                });

            modelBuilder.Entity("KitOrder", b =>
                {
                    b.Property<int>("KitsID")
                        .HasColumnType("int");

                    b.Property<int>("OrdersID")
                        .HasColumnType("int");

                    b.HasKey("KitsID", "OrdersID");

                    b.HasIndex("OrdersID");

                    b.ToTable("KitOrder");
                });

            modelBuilder.Entity("WorkShop.Models.Client", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("ID_Client");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FIO")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("WorkShop.Models.Item", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("ID_Item");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<byte[]>("Photo")
                        .HasColumnType("varbinary(max)")
                        .HasColumnName("Image");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("ID");

                    b.ToTable("Items");
                });

            modelBuilder.Entity("WorkShop.Models.Kit", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("ID_Kit");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<byte[]>("Photo")
                        .HasColumnType("varbinary(max)")
                        .HasColumnName("Image");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("ID");

                    b.ToTable("Kits");
                });

            modelBuilder.Entity("WorkShop.Models.Order", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("ID_Order");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<int>("ClientID")
                        .HasColumnType("int");

                    b.Property<string>("CurentStatus")
                        .IsRequired()
                        .HasColumnType("nvarchar(MAX)");

                    b.Property<DateTime>("DateAdd")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DateEnd")
                        .HasColumnType("datetime2");

                    b.HasKey("ID");

                    b.HasIndex("ClientID");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("ItemKit", b =>
                {
                    b.HasOne("WorkShop.Models.Kit", null)
                        .WithMany()
                        .HasForeignKey("ID_Item")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WorkShop.Models.Item", null)
                        .WithMany()
                        .HasForeignKey("ID_Kit")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("ItemOrder", b =>
                {
                    b.HasOne("WorkShop.Models.Item", null)
                        .WithMany()
                        .HasForeignKey("ItemsID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WorkShop.Models.Order", null)
                        .WithMany()
                        .HasForeignKey("OrdersID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("KitOrder", b =>
                {
                    b.HasOne("WorkShop.Models.Kit", null)
                        .WithMany()
                        .HasForeignKey("KitsID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WorkShop.Models.Order", null)
                        .WithMany()
                        .HasForeignKey("OrdersID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("WorkShop.Models.Order", b =>
                {
                    b.HasOne("WorkShop.Models.Client", "Client")
                        .WithMany()
                        .HasForeignKey("ClientID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Client");
                });
#pragma warning restore 612, 618
        }
    }
}
