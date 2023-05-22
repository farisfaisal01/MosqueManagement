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
    [Migration("20230522020702_imageAll")]
    partial class imageAll
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
                    b.Property<int?>("formId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int?>("formId"));

                    b.Property<int?>("Userid")
                        .HasColumnType("int");

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

                    b.Property<int?>("serviceId")
                        .HasColumnType("int");

                    b.HasKey("formId");

                    b.HasIndex("Userid");

                    b.HasIndex("paymentId");

                    b.HasIndex("serviceId");

                    b.ToTable("Classes");
                });

            modelBuilder.Entity("MosqueManagement.Models.Donation", b =>
                {
                    b.Property<int?>("donationId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int?>("donationId"));

                    b.Property<double?>("donationAmount")
                        .HasColumnType("float");

                    b.Property<string>("donationSuccess")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("donationId");

                    b.ToTable("Donations");
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

                    b.Property<int?>("Userid")
                        .HasColumnType("int");

                    b.Property<double?>("amount")
                        .HasColumnType("float");

                    b.Property<string>("paymentContact")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("paymentEmail")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("paymentName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("paymentId");

                    b.HasIndex("Userid");

                    b.ToTable("Payments");
                });

            modelBuilder.Entity("MosqueManagement.Models.Rental", b =>
                {
                    b.Property<int?>("formId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int?>("formId"));

                    b.Property<int?>("Userid")
                        .HasColumnType("int");

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

                    b.Property<string>("package")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("paymentId")
                        .HasColumnType("int");

                    b.Property<string>("remarks")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("serviceId")
                        .HasColumnType("int");

                    b.Property<string>("startDate")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("formId");

                    b.HasIndex("Userid");

                    b.HasIndex("paymentId");

                    b.HasIndex("serviceId");

                    b.ToTable("Rentals");
                });

            modelBuilder.Entity("MosqueManagement.Models.Schedule", b =>
                {
                    b.Property<int?>("scheduleId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int?>("scheduleId"));

                    b.Property<int?>("ClassformId")
                        .HasColumnType("int");

                    b.Property<int?>("RentalformId")
                        .HasColumnType("int");

                    b.Property<int?>("SocialformId")
                        .HasColumnType("int");

                    b.Property<string>("occupied")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("scheduleId");

                    b.HasIndex("ClassformId");

                    b.HasIndex("RentalformId");

                    b.HasIndex("SocialformId");

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

                    b.Property<string>("serviceName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double?>("servicePrice")
                        .HasColumnType("float");

                    b.HasKey("serviceId");

                    b.ToTable("Services");
                });

            modelBuilder.Entity("MosqueManagement.Models.Social", b =>
                {
                    b.Property<int?>("formId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int?>("formId"));

                    b.Property<int?>("Userid")
                        .HasColumnType("int");

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

                    b.Property<int?>("serviceId")
                        .HasColumnType("int");

                    b.HasKey("formId");

                    b.HasIndex("Userid");

                    b.HasIndex("paymentId");

                    b.HasIndex("serviceId");

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
                    b.HasOne("MosqueManagement.Models.User", null)
                        .WithMany("Classs")
                        .HasForeignKey("Userid");

                    b.HasOne("MosqueManagement.Models.Payment", null)
                        .WithMany("Classs")
                        .HasForeignKey("paymentId");

                    b.HasOne("MosqueManagement.Models.Service", null)
                        .WithMany("Classs")
                        .HasForeignKey("serviceId");
                });

            modelBuilder.Entity("MosqueManagement.Models.Payment", b =>
                {
                    b.HasOne("MosqueManagement.Models.User", null)
                        .WithMany("Payments")
                        .HasForeignKey("Userid");
                });

            modelBuilder.Entity("MosqueManagement.Models.Rental", b =>
                {
                    b.HasOne("MosqueManagement.Models.User", null)
                        .WithMany("Rentals")
                        .HasForeignKey("Userid");

                    b.HasOne("MosqueManagement.Models.Payment", null)
                        .WithMany("Rentals")
                        .HasForeignKey("paymentId");

                    b.HasOne("MosqueManagement.Models.Service", null)
                        .WithMany("Rentals")
                        .HasForeignKey("serviceId");
                });

            modelBuilder.Entity("MosqueManagement.Models.Schedule", b =>
                {
                    b.HasOne("MosqueManagement.Models.Class", null)
                        .WithMany("Schedules")
                        .HasForeignKey("ClassformId");

                    b.HasOne("MosqueManagement.Models.Rental", null)
                        .WithMany("Schedules")
                        .HasForeignKey("RentalformId");

                    b.HasOne("MosqueManagement.Models.Social", null)
                        .WithMany("Schedules")
                        .HasForeignKey("SocialformId");
                });

            modelBuilder.Entity("MosqueManagement.Models.Social", b =>
                {
                    b.HasOne("MosqueManagement.Models.User", null)
                        .WithMany("Socials")
                        .HasForeignKey("Userid");

                    b.HasOne("MosqueManagement.Models.Payment", null)
                        .WithMany("Socials")
                        .HasForeignKey("paymentId");

                    b.HasOne("MosqueManagement.Models.Service", null)
                        .WithMany("Socials")
                        .HasForeignKey("serviceId");
                });

            modelBuilder.Entity("MosqueManagement.Models.Class", b =>
                {
                    b.Navigation("Schedules");
                });

            modelBuilder.Entity("MosqueManagement.Models.Payment", b =>
                {
                    b.Navigation("Classs");

                    b.Navigation("Rentals");

                    b.Navigation("Socials");
                });

            modelBuilder.Entity("MosqueManagement.Models.Rental", b =>
                {
                    b.Navigation("Schedules");
                });

            modelBuilder.Entity("MosqueManagement.Models.Service", b =>
                {
                    b.Navigation("Classs");

                    b.Navigation("Rentals");

                    b.Navigation("Socials");
                });

            modelBuilder.Entity("MosqueManagement.Models.Social", b =>
                {
                    b.Navigation("Schedules");
                });

            modelBuilder.Entity("MosqueManagement.Models.User", b =>
                {
                    b.Navigation("Classs");

                    b.Navigation("Payments");

                    b.Navigation("Rentals");

                    b.Navigation("Socials");
                });
#pragma warning restore 612, 618
        }
    }
}
