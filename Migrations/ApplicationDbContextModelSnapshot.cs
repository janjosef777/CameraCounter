﻿// <auto-generated />
using System;
using CameraCounter.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace CameraCounter.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.8-servicing-32085");

            modelBuilder.Entity("CameraCounter.Models.Issue", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("DateDone");

                    b.Property<string>("Details");

                    b.Property<int>("LineID");

                    b.Property<int>("Severity");

                    b.HasKey("ID");

                    b.HasIndex("LineID");

                    b.ToTable("Issues");
                });

            modelBuilder.Entity("CameraCounter.Models.Line", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("DailyTarget");

                    b.Property<string>("Name");

                    b.HasKey("ID");

                    b.ToTable("Lines");
                });

            modelBuilder.Entity("CameraCounter.Models.ProductionOrder", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("CamerasFailed");

                    b.Property<int>("CamerasMade");

                    b.Property<DateTime>("DateDone");

                    b.Property<int>("LineID");

                    b.HasKey("ID");

                    b.HasIndex("LineID");

                    b.ToTable("ProductionOrders");
                });

            modelBuilder.Entity("CameraCounter.Models.Issue", b =>
                {
                    b.HasOne("CameraCounter.Models.Line", "Line")
                        .WithMany("Issues")
                        .HasForeignKey("LineID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("CameraCounter.Models.ProductionOrder", b =>
                {
                    b.HasOne("CameraCounter.Models.Line", "Line")
                        .WithMany("ProductionOrders")
                        .HasForeignKey("LineID")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
