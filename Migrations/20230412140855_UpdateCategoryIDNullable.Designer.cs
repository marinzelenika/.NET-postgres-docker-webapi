﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using sample_app.Data;

#nullable disable

namespace SampleAPI.Migrations
{
    [DbContext(typeof(MyDbContext))]
    [Migration("20230412140855_UpdateCategoryIDNullable")]
    partial class UpdateCategoryIDNullable
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("SampleAPI.Models.Category", b =>
                {
                    b.Property<int>("CategoryID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("CategoryID"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("CategoryID");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("SampleAPI.Models.Order", b =>
                {
                    b.Property<int>("OrderID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("OrderID"));

                    b.Property<DateTime>("OrderDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("OrderStatus")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<decimal>("TotalAmount")
                        .HasColumnType("numeric");

                    b.Property<Guid>("UserID")
                        .HasColumnType("uuid");

                    b.HasKey("OrderID");

                    b.HasIndex("UserID");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("SampleAPI.Models.OrderDetail", b =>
                {
                    b.Property<int>("OrderDetailID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("OrderDetailID"));

                    b.Property<int>("OrderID")
                        .HasColumnType("integer");

                    b.Property<decimal>("Price")
                        .HasColumnType("numeric");

                    b.Property<int>("Quantity")
                        .HasColumnType("integer");

                    b.Property<int>("TShirtID")
                        .HasColumnType("integer");

                    b.HasKey("OrderDetailID");

                    b.HasIndex("OrderID");

                    b.HasIndex("TShirtID");

                    b.ToTable("OrderDetails");
                });

            modelBuilder.Entity("SampleAPI.Models.TShirt", b =>
                {
                    b.Property<int>("TShirtID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("TShirtID"));

                    b.Property<int?>("CategoryID")
                        .IsRequired()
                        .HasColumnType("integer");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("ImageUrl")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<decimal>("Price")
                        .HasColumnType("numeric");

                    b.Property<string>("Sizes")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("Stock")
                        .HasColumnType("integer");

                    b.HasKey("TShirtID");

                    b.HasIndex("CategoryID");

                    b.ToTable("TShirts");
                });

            modelBuilder.Entity("SampleAPI.Models.User", b =>
                {
                    b.Property<Guid>("UserID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("City")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Country")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("GoogleID")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("State")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("ZipCode")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("UserID");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("SampleAPI.Models.Order", b =>
                {
                    b.HasOne("SampleAPI.Models.User", "User")
                        .WithMany("Orders")
                        .HasForeignKey("UserID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("SampleAPI.Models.OrderDetail", b =>
                {
                    b.HasOne("SampleAPI.Models.Order", "Order")
                        .WithMany("OrderDetails")
                        .HasForeignKey("OrderID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SampleAPI.Models.TShirt", "TShirt")
                        .WithMany("OrderDetails")
                        .HasForeignKey("TShirtID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Order");

                    b.Navigation("TShirt");
                });

            modelBuilder.Entity("SampleAPI.Models.TShirt", b =>
                {
                    b.HasOne("SampleAPI.Models.Category", "Category")
                        .WithMany("TShirts")
                        .HasForeignKey("CategoryID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");
                });

            modelBuilder.Entity("SampleAPI.Models.Category", b =>
                {
                    b.Navigation("TShirts");
                });

            modelBuilder.Entity("SampleAPI.Models.Order", b =>
                {
                    b.Navigation("OrderDetails");
                });

            modelBuilder.Entity("SampleAPI.Models.TShirt", b =>
                {
                    b.Navigation("OrderDetails");
                });

            modelBuilder.Entity("SampleAPI.Models.User", b =>
                {
                    b.Navigation("Orders");
                });
#pragma warning restore 612, 618
        }
    }
}