﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using NixMdm.Data;

namespace NixMdm.Migrations
{
    [DbContext(typeof(MDMContext))]
    [Migration("20191201211830_InitialCreate")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079");

            modelBuilder.Entity("NixMdm.Models.Device", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("DateAdded");

                    b.Property<string>("IMEI");

                    b.Property<string>("Name");

                    b.Property<string>("OsVersion");

                    b.Property<string>("PhoneNumber");

                    b.Property<int>("UserID");

                    b.HasKey("Id");

                    b.ToTable("Device");
                });
#pragma warning restore 612, 618
        }
    }
}
