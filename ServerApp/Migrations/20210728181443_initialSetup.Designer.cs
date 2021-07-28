﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using ServerApp.Model;
using System;

namespace ServerApp.Migrations
{
    [DbContext(typeof(DatabaseContext))]
    [Migration("20210728181443_initialSetup")]
    partial class initialSetup
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.0-rtm-26452")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("ServerApp.Model.Admin", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("password");

                    b.Property<string>("username");

                    b.HasKey("id");

                    b.ToTable("admins");
                });

            modelBuilder.Entity("ServerApp.Model.Appointment", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("doctorID");

                    b.Property<int>("patientID");

                    b.Property<string>("time");

                    b.HasKey("id");

                    b.ToTable("appointments");
                });

            modelBuilder.Entity("ServerApp.Model.Doctor", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("degrees");

                    b.Property<string>("description");

                    b.Property<string>("name");

                    b.Property<string>("specialty");

                    b.HasKey("id");

                    b.ToTable("doctors");
                });

            modelBuilder.Entity("ServerApp.Model.Patient", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("email");

                    b.Property<string>("name");

                    b.Property<string>("password");

                    b.HasKey("id");

                    b.ToTable("patients");
                });
#pragma warning restore 612, 618
        }
    }
}
