﻿// <auto-generated />
using System;
using DemoDMS.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace DemoDMS.Migrations
{
    [DbContext(typeof(DemoDMSContext))]
    [Migration("20230117170936_#43")]
    partial class _43
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "7.0.0");

            modelBuilder.Entity("DemoDMS.Models.Document", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("AuthorName")
                        .HasColumnType("TEXT");

                    b.Property<DateTimeOffset>("DateCreated")
                        .HasColumnType("TEXT");

                    b.Property<DateTimeOffset>("DateModified")
                        .HasColumnType("TEXT");

                    b.Property<int>("Department")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Extension")
                        .HasColumnType("TEXT");

                    b.Property<int>("Faculty")
                        .HasColumnType("INTEGER");

                    b.Property<string>("FilePath")
                        .HasColumnType("TEXT");

                    b.Property<string>("FileType")
                        .HasColumnType("TEXT");

                    b.Property<int>("Level")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("ParentId")
                        .HasColumnType("INTEGER");

                    b.Property<DateTimeOffset>("PublicationDate")
                        .HasColumnType("TEXT");

                    b.Property<double?>("Size")
                        .HasColumnType("REAL");

                    b.Property<string>("SupervisorName")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Document");
                });

            modelBuilder.Entity("DemoDMS.Models.Folder", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTimeOffset>("DateCreated")
                        .HasColumnType("TEXT");

                    b.Property<DateTimeOffset>("DateModified")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.Property<int>("ParentId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.ToTable("Folder");
                });
#pragma warning restore 612, 618
        }
    }
}