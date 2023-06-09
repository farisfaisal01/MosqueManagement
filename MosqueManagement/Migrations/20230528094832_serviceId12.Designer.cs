﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using MosqueManagement.Data;

#nullable disable

namespace MosqueManagement.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20230528094832_serviceId12")]
    partial class serviceId12
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("MosqueManagement.Models.Class", b =>
                {
                    b.Property<int?>("classId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int?>("classId"));

                    b.Property<string>("approval")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("approvalMonth")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("approvalYear")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("attachment")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("equipment")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("feedback")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("package")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("paymentId")
                        .HasColumnType("int");

                    b.Property<string>("remarks")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("scheduleId")
                        .HasColumnType("int");

                    b.Property<int?>("serviceId")
                        .HasColumnType("int");

                    b.Property<int?>("userId")
                        .HasColumnType("int");

                    b.HasKey("classId");

                    b.HasIndex("paymentId");

                    b.HasIndex("scheduleId");

                    b.HasIndex("serviceId");

                    b.HasIndex("userId");

                    b.ToTable("Classes");
                });

            modelBuilder.Entity("MosqueManagement.Models.HumanResource", b =>
                {
                    b.Property<int?>("positionId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int?>("positionId"));

                    b.Property<string>("positionDescription")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("positionTitle")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("staffContact")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("staffImagePath")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("staffName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("positionId");

                    b.ToTable("HumanResources");
                });

            modelBuilder.Entity("MosqueManagement.Models.Market", b =>
                {
                    b.Property<int?>("marketId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int?>("marketId"));

                    b.Property<string>("marketContact")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("marketDescription")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("marketImagePath")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("marketName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("marketId");

                    b.ToTable("Markets");
                });

            modelBuilder.Entity("MosqueManagement.Models.Payment", b =>
                {
                    b.Property<int?>("paymentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int?>("paymentId"));

                    b.Property<string>("paymentAmount")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("paymentCardCVC")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("paymentCardExpireMonth")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("paymentCardExpireYear")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("paymentCardNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("paymentContact")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("paymentEmail")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("paymentMethod")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("paymentName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("paymentPurpose")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("paymentId");

                    b.ToTable("Payments");
                });

            modelBuilder.Entity("MosqueManagement.Models.Rental", b =>
                {
                    b.Property<int?>("rentalId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int?>("rentalId"));

                    b.Property<string>("approval")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("approvalMonth")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("approvalYear")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("attachment")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("endDate")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("eventDescription")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("eventName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("feedback")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("paymentId")
                        .HasColumnType("int");

                    b.Property<string>("remarks")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("scheduleId")
                        .HasColumnType("int");

                    b.Property<int?>("serviceId")
                        .HasColumnType("int");

                    b.Property<string>("startDate")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("userId")
                        .HasColumnType("int");

                    b.HasKey("rentalId");

                    b.HasIndex("paymentId");

                    b.HasIndex("scheduleId");

                    b.HasIndex("serviceId");

                    b.HasIndex("userId");

                    b.ToTable("Rentals");
                });

            modelBuilder.Entity("MosqueManagement.Models.Schedule", b =>
                {
                    b.Property<int?>("scheduleId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int?>("scheduleId"));

                    b.Property<string>("occupied")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("scheduleId");

                    b.ToTable("Schedules");
                });

            modelBuilder.Entity("MosqueManagement.Models.Service", b =>
                {
                    b.Property<int?>("serviceId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int?>("serviceId"));

                    b.Property<string>("serviceCategory")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("serviceDescription")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("serviceEquipments")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("serviceImagePath")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("serviceName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double?>("servicePrice")
                        .HasColumnType("float");

                    b.HasKey("serviceId");

                    b.ToTable("Services");
                });

            modelBuilder.Entity("MosqueManagement.Models.Social", b =>
                {
                    b.Property<int?>("socialId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int?>("socialId"));

                    b.Property<string>("approval")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("approvalMonth")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("approvalYear")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("attachment")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("eventDate")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("eventTime")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("feedback")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("package")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("paymentId")
                        .HasColumnType("int");

                    b.Property<string>("remarks")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("scheduleId")
                        .HasColumnType("int");

                    b.Property<int?>("serviceId")
                        .HasColumnType("int");

                    b.Property<int?>("userId")
                        .HasColumnType("int");

                    b.HasKey("socialId");

                    b.HasIndex("paymentId");

                    b.HasIndex("scheduleId");

                    b.HasIndex("serviceId");

                    b.HasIndex("userId");

                    b.ToTable("Socials");
                });

            modelBuilder.Entity("MosqueManagement.Models.User", b =>
                {
                    b.Property<int?>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int?>("id"));

                    b.Property<string>("address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("gender")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ic")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("password")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("phone")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("role")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("username")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("MosqueManagement.Models.Class", b =>
                {
                    b.HasOne("MosqueManagement.Models.Payment", "Payment")
                        .WithMany()
                        .HasForeignKey("paymentId");

                    b.HasOne("MosqueManagement.Models.Schedule", "Schedule")
                        .WithMany()
                        .HasForeignKey("scheduleId");

                    b.HasOne("MosqueManagement.Models.Service", "Service")
                        .WithMany()
                        .HasForeignKey("serviceId");

                    b.HasOne("MosqueManagement.Models.User", "User")
                        .WithMany()
                        .HasForeignKey("userId");

                    b.Navigation("Payment");

                    b.Navigation("Schedule");

                    b.Navigation("Service");

                    b.Navigation("User");
                });

            modelBuilder.Entity("MosqueManagement.Models.Rental", b =>
                {
                    b.HasOne("MosqueManagement.Models.Payment", "Payment")
                        .WithMany()
                        .HasForeignKey("paymentId");

                    b.HasOne("MosqueManagement.Models.Schedule", "Schedule")
                        .WithMany()
                        .HasForeignKey("scheduleId");

                    b.HasOne("MosqueManagement.Models.Service", "Service")
                        .WithMany()
                        .HasForeignKey("serviceId");

                    b.HasOne("MosqueManagement.Models.User", "User")
                        .WithMany()
                        .HasForeignKey("userId");

                    b.Navigation("Payment");

                    b.Navigation("Schedule");

                    b.Navigation("Service");

                    b.Navigation("User");
                });

            modelBuilder.Entity("MosqueManagement.Models.Social", b =>
                {
                    b.HasOne("MosqueManagement.Models.Payment", "Payment")
                        .WithMany()
                        .HasForeignKey("paymentId");

                    b.HasOne("MosqueManagement.Models.Schedule", "Schedule")
                        .WithMany()
                        .HasForeignKey("scheduleId");

                    b.HasOne("MosqueManagement.Models.Service", "Service")
                        .WithMany()
                        .HasForeignKey("serviceId");

                    b.HasOne("MosqueManagement.Models.User", "User")
                        .WithMany()
                        .HasForeignKey("userId");

                    b.Navigation("Payment");

                    b.Navigation("Schedule");

                    b.Navigation("Service");

                    b.Navigation("User");
                });
#pragma warning restore 612, 618
        }
    }
}
