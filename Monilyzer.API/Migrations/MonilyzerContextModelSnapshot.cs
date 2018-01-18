﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using Monilyzer.Model;
using Monilyzer.Model.Enums;
using System;
using Monilyzer.API.Data;

namespace Monilyzer.API.Migrations
{
    [DbContext(typeof(MonilyzerContext))]
    partial class MonilyzerContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.1-rtm-125")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Monilyzer.Model.Customer", b =>
                {
                    b.Property<Guid>("Guid")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("LastUpdated");

                    b.Property<string>("Name");

                    b.HasKey("Guid");

                    b.ToTable("Customers");
                });

            modelBuilder.Entity("Monilyzer.Model.Interface", b =>
                {
                    b.Property<Guid>("Guid")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("Duplex");

                    b.Property<string>("ExternalId");

                    b.Property<DateTime>("LastPolled");

                    b.Property<DateTime>("LastUpdated");

                    b.Property<string>("Name");

                    b.Property<Guid>("NodeGuid");

                    b.Property<decimal>("RecieveBandwidth");

                    b.Property<decimal>("RecieveUtilization");

                    b.Property<decimal>("Speed");

                    b.Property<decimal>("TransmitBandwidth");

                    b.Property<decimal>("TransmitUtilization");

                    b.HasKey("Guid");

                    b.HasIndex("NodeGuid");

                    b.ToTable("Interfaces");
                });

            modelBuilder.Entity("Monilyzer.Model.Location", b =>
                {
                    b.Property<Guid>("Guid")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("City");

                    b.Property<string>("Country");

                    b.Property<Guid>("CustomerGuid");

                    b.Property<DateTime>("LastPolled");

                    b.Property<DateTime>("LastUpdated");

                    b.Property<double>("Latitude");

                    b.Property<double>("Longitude");

                    b.Property<string>("Name");

                    b.Property<string>("State");

                    b.HasKey("Guid");

                    b.HasIndex("CustomerGuid");

                    b.ToTable("Locations");
                });

            modelBuilder.Entity("Monilyzer.Model.Node", b =>
                {
                    b.Property<Guid>("Guid")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid>("CustomerGuid");

                    b.Property<string>("ExternalId");

                    b.Property<string>("IPAddress");

                    b.Property<DateTime>("LastPolled");

                    b.Property<DateTime>("LastUpdated");

                    b.Property<Guid?>("LocationGuid");

                    b.Property<string>("Name");

                    b.Property<decimal>("PacketLoss");

                    b.Property<decimal>("ResponseTime");

                    b.Property<int>("Status");

                    b.HasKey("Guid");

                    b.HasIndex("CustomerGuid");

                    b.HasIndex("LocationGuid");

                    b.ToTable("Nodes");
                });

            modelBuilder.Entity("Monilyzer.Model.User", b =>
                {
                    b.Property<Guid>("Guid")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Displayname");

                    b.Property<string>("Email");

                    b.Property<string>("Password");

                    b.Property<string>("Username");

                    b.HasKey("Guid");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("Monilyzer.Model.UserRole", b =>
                {
                    b.Property<Guid>("Guid")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("Role");

                    b.Property<Guid?>("UserGuid");

                    b.HasKey("Guid");

                    b.HasIndex("UserGuid");

                    b.ToTable("UserRoles");
                });

            modelBuilder.Entity("Monilyzer.Model.Volume", b =>
                {
                    b.Property<Guid>("Guid")
                        .ValueGeneratedOnAdd();

                    b.Property<decimal>("Capacity");

                    b.Property<decimal>("CapacityUtilization");

                    b.Property<string>("ExternalId");

                    b.Property<DateTime>("LastPolled");

                    b.Property<DateTime>("LastUpdated");

                    b.Property<string>("Name");

                    b.Property<Guid>("NodeGuid");

                    b.HasKey("Guid");

                    b.HasIndex("NodeGuid");

                    b.ToTable("Volumes");
                });

            modelBuilder.Entity("Monilyzer.Model.Interface", b =>
                {
                    b.HasOne("Monilyzer.Model.Node")
                        .WithMany("Interfaces")
                        .HasForeignKey("NodeGuid")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Monilyzer.Model.Location", b =>
                {
                    b.HasOne("Monilyzer.Model.Customer")
                        .WithMany("Locations")
                        .HasForeignKey("CustomerGuid")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Monilyzer.Model.Node", b =>
                {
                    b.HasOne("Monilyzer.Model.Customer")
                        .WithMany("Nodes")
                        .HasForeignKey("CustomerGuid")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Monilyzer.Model.Location")
                        .WithMany("Nodes")
                        .HasForeignKey("LocationGuid");
                });

            modelBuilder.Entity("Monilyzer.Model.UserRole", b =>
                {
                    b.HasOne("Monilyzer.Model.User")
                        .WithMany("UserRoles")
                        .HasForeignKey("UserGuid");
                });

            modelBuilder.Entity("Monilyzer.Model.Volume", b =>
                {
                    b.HasOne("Monilyzer.Model.Node")
                        .WithMany("Volumes")
                        .HasForeignKey("NodeGuid")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
