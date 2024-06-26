﻿// <auto-generated />
using System;
using Graduation_Project.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Graduation_Project.Migrations
{
    [DbContext(typeof(Context))]
    [Migration("20240604141429_init")]
    partial class init
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.18")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Graduation_Project.Models.Admin", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("Admins");
                });

            modelBuilder.Entity("Graduation_Project.Models.Client", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("Clients");
                });

            modelBuilder.Entity("Graduation_Project.Models.Department", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("Departments");
                });

            modelBuilder.Entity("Graduation_Project.Models.Notifications", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<int?>("ClientId")
                        .HasColumnType("int");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<string>("Messege")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("WorkerId")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("ClientId");

                    b.HasIndex("WorkerId");

                    b.ToTable("Notifications");
                });

            modelBuilder.Entity("Graduation_Project.Models.Order", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<int>("AdminId")
                        .HasColumnType("int");

                    b.Property<string>("ClientAddress")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ClientId")
                        .HasColumnType("int");

                    b.Property<string>("Date")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Problem")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Time")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("WorkerId")
                        .HasColumnType("int");

                    b.Property<int>("typeOfOrder")
                        .HasColumnType("int");

                    b.Property<int>("typeOfPayment")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("AdminId");

                    b.HasIndex("ClientId");

                    b.HasIndex("WorkerId");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("Graduation_Project.Models.Payment", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<int>("ClientId")
                        .HasColumnType("int");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Price")
                        .HasColumnType("int");

                    b.Property<string>("WalletPassword")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.HasIndex("ClientId");

                    b.ToTable("Payments");
                });

            modelBuilder.Entity("Graduation_Project.Models.SpareParts", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<int>("ClientId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Price")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("ClientId");

                    b.ToTable("SpareParts");
                });

            modelBuilder.Entity("Graduation_Project.Models.Worker", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("AdminId")
                        .HasColumnType("int");

                    b.Property<int>("Age")
                        .HasColumnType("int");

                    b.Property<int>("DeptId")
                        .HasColumnType("int");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.HasIndex("AdminId");

                    b.HasIndex("DeptId");

                    b.ToTable("Workers");
                });

            modelBuilder.Entity("Graduation_Project.Models.Notifications", b =>
                {
                    b.HasOne("Graduation_Project.Models.Client", "Client")
                        .WithMany("Notifications")
                        .HasForeignKey("ClientId");

                    b.HasOne("Graduation_Project.Models.Worker", "Worker")
                        .WithMany("Notifications")
                        .HasForeignKey("WorkerId");

                    b.Navigation("Client");

                    b.Navigation("Worker");
                });

            modelBuilder.Entity("Graduation_Project.Models.Order", b =>
                {
                    b.HasOne("Graduation_Project.Models.Admin", "Admin")
                        .WithMany("Order")
                        .HasForeignKey("AdminId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Graduation_Project.Models.Client", "Client")
                        .WithMany("Order")
                        .HasForeignKey("ClientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Graduation_Project.Models.Worker", "Worker")
                        .WithMany("Order")
                        .HasForeignKey("WorkerId");

                    b.Navigation("Admin");

                    b.Navigation("Client");

                    b.Navigation("Worker");
                });

            modelBuilder.Entity("Graduation_Project.Models.Payment", b =>
                {
                    b.HasOne("Graduation_Project.Models.Client", "Client")
                        .WithMany("Payment")
                        .HasForeignKey("ClientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Client");
                });

            modelBuilder.Entity("Graduation_Project.Models.SpareParts", b =>
                {
                    b.HasOne("Graduation_Project.Models.Client", "Client")
                        .WithMany("SpareParts")
                        .HasForeignKey("ClientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Client");
                });

            modelBuilder.Entity("Graduation_Project.Models.Worker", b =>
                {
                    b.HasOne("Graduation_Project.Models.Admin", "Admin")
                        .WithMany("Worker")
                        .HasForeignKey("AdminId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Graduation_Project.Models.Department", "Department")
                        .WithMany("Worker")
                        .HasForeignKey("DeptId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Admin");

                    b.Navigation("Department");
                });

            modelBuilder.Entity("Graduation_Project.Models.Admin", b =>
                {
                    b.Navigation("Order");

                    b.Navigation("Worker");
                });

            modelBuilder.Entity("Graduation_Project.Models.Client", b =>
                {
                    b.Navigation("Notifications");

                    b.Navigation("Order");

                    b.Navigation("Payment");

                    b.Navigation("SpareParts");
                });

            modelBuilder.Entity("Graduation_Project.Models.Department", b =>
                {
                    b.Navigation("Worker");
                });

            modelBuilder.Entity("Graduation_Project.Models.Worker", b =>
                {
                    b.Navigation("Notifications");

                    b.Navigation("Order");
                });
#pragma warning restore 612, 618
        }
    }
}
