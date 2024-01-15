﻿// <auto-generated />
using System;
using FireDetection.Backend.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace FireDetection.Backend.Domain.Migrations
{
    [DbContext(typeof(FireDetectionDbContext))]
    partial class FireDetectionDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("FireDetection.Backend.Domain.Entity.ActionType", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("ID"));

                    b.Property<string>("ActionDescription")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("ActionName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("ID");

                    b.ToTable("ActionType");

                    b.HasData(
                        new
                        {
                            ID = 1,
                            ActionDescription = "actiondes",
                            ActionName = "action"
                        },
                        new
                        {
                            ID = 2,
                            ActionDescription = "actiondes",
                            ActionName = "action"
                        },
                        new
                        {
                            ID = 3,
                            ActionDescription = "actiondes",
                            ActionName = "action"
                        });
                });

            modelBuilder.Entity("FireDetection.Backend.Domain.Entity.AlarmRate", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid>("CreatedBy")
                        .HasColumnType("uuid");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int>("LevelID")
                        .HasColumnType("integer");

                    b.Property<Guid>("RecordID")
                        .HasColumnType("uuid");

                    b.Property<string>("Time")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<Guid>("UserID")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("LevelID");

                    b.HasIndex("RecordID");

                    b.HasIndex("UserID");

                    b.ToTable("AlarmRate");
                });

            modelBuilder.Entity("FireDetection.Backend.Domain.Entity.Camera", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid>("LocationID")
                        .HasColumnType("uuid");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("LocationID");

                    b.ToTable("Cameras");
                });

            modelBuilder.Entity("FireDetection.Backend.Domain.Entity.ControlCamera", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid>("LocationID")
                        .HasColumnType("uuid");

                    b.Property<Guid>("UserID")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("LocationID");

                    b.HasIndex("UserID");

                    b.ToTable("ControlCameras");
                });

            modelBuilder.Entity("FireDetection.Backend.Domain.Entity.Level", b =>
                {
                    b.Property<int>("LevelID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("LevelID"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("LevelID");

                    b.ToTable("Level");

                    b.HasData(
                        new
                        {
                            LevelID = 1,
                            Description = "Small Fire",
                            Name = "Level 1"
                        },
                        new
                        {
                            LevelID = 2,
                            Description = "Fire ",
                            Name = "Level 2"
                        },
                        new
                        {
                            LevelID = 3,
                            Description = "Fire ",
                            Name = "Level 3"
                        },
                        new
                        {
                            LevelID = 4,
                            Description = "Fire ",
                            Name = "Level 4"
                        },
                        new
                        {
                            LevelID = 5,
                            Description = "Fire ",
                            Name = "Level 5"
                        });
                });

            modelBuilder.Entity("FireDetection.Backend.Domain.Entity.Location", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid>("CreatedBy")
                        .HasColumnType("uuid");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<Guid?>("DeleteBy")
                        .HasColumnType("uuid");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("boolean");

                    b.Property<DateTime>("LastModified")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("LocationName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<Guid>("ModifiedBy")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.ToTable("Location");
                });

            modelBuilder.Entity("FireDetection.Backend.Domain.Entity.MediaRecord", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<int>("MediaTypeId")
                        .HasColumnType("integer");

                    b.Property<Guid>("RecordId")
                        .HasColumnType("uuid");

                    b.Property<string>("Url")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("MediaTypeId");

                    b.HasIndex("RecordId");

                    b.ToTable("MediaRecords");
                });

            modelBuilder.Entity("FireDetection.Backend.Domain.Entity.MediaType", b =>
                {
                    b.Property<int>("MediaTypeID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("MediaTypeID"));

                    b.Property<string>("MediaName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("MediaTypeID");

                    b.ToTable("MediaTypes");

                    b.HasData(
                        new
                        {
                            MediaTypeID = 1,
                            MediaName = "video"
                        },
                        new
                        {
                            MediaTypeID = 2,
                            MediaName = "image"
                        });
                });

            modelBuilder.Entity("FireDetection.Backend.Domain.Entity.Record", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid>("CameraID")
                        .HasColumnType("uuid");

                    b.Property<decimal>("PredictedPercent")
                        .HasColumnType("numeric");

                    b.Property<string>("RecordTime")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<decimal>("UserRatingPercent")
                        .HasColumnType("numeric");

                    b.HasKey("Id");

                    b.HasIndex("CameraID");

                    b.ToTable("Records");
                });

            modelBuilder.Entity("FireDetection.Backend.Domain.Entity.RecordProcess", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<int>("ActionTypeId")
                        .HasColumnType("integer");

                    b.Property<Guid>("CreatedBy")
                        .HasColumnType("uuid");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<Guid>("RecordID")
                        .HasColumnType("uuid");

                    b.Property<Guid>("UserID")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("ActionTypeId");

                    b.HasIndex("RecordID");

                    b.HasIndex("UserID");

                    b.ToTable("RecordProcess");
                });

            modelBuilder.Entity("FireDetection.Backend.Domain.Entity.Role", b =>
                {
                    b.Property<int>("RoleId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("RoleId"));

                    b.Property<string>("RoleName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("RoleId");

                    b.ToTable("Roles");

                    b.HasData(
                        new
                        {
                            RoleId = 1,
                            RoleName = "Manager"
                        },
                        new
                        {
                            RoleId = 2,
                            RoleName = "User"
                        });
                });

            modelBuilder.Entity("FireDetection.Backend.Domain.Entity.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid>("CreatedBy")
                        .HasColumnType("uuid");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<Guid?>("DeleteBy")
                        .HasColumnType("uuid");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("boolean");

                    b.Property<DateTime>("LastModified")
                        .HasColumnType("timestamp with time zone");

                    b.Property<Guid>("ModifiedBy")
                        .HasColumnType("uuid");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("RoleId")
                        .HasColumnType("integer");

                    b.Property<string>("SecurityCode")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<bool>("isActive")
                        .HasColumnType("boolean");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("FireDetection.Backend.Domain.Entity.AlarmRate", b =>
                {
                    b.HasOne("FireDetection.Backend.Domain.Entity.Level", "Level")
                        .WithMany("AlarmRates")
                        .HasForeignKey("LevelID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("FireDetection.Backend.Domain.Entity.Record", "Record")
                        .WithMany("AlarmRates")
                        .HasForeignKey("RecordID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("FireDetection.Backend.Domain.Entity.User", "User")
                        .WithMany()
                        .HasForeignKey("UserID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Level");

                    b.Navigation("Record");

                    b.Navigation("User");
                });

            modelBuilder.Entity("FireDetection.Backend.Domain.Entity.Camera", b =>
                {
                    b.HasOne("FireDetection.Backend.Domain.Entity.Location", "Location")
                        .WithMany("Cameras")
                        .HasForeignKey("LocationID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Location");
                });

            modelBuilder.Entity("FireDetection.Backend.Domain.Entity.ControlCamera", b =>
                {
                    b.HasOne("FireDetection.Backend.Domain.Entity.Location", "Location")
                        .WithMany("ControlCameras")
                        .HasForeignKey("LocationID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("FireDetection.Backend.Domain.Entity.User", "User")
                        .WithMany("ControlCameras")
                        .HasForeignKey("UserID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Location");

                    b.Navigation("User");
                });

            modelBuilder.Entity("FireDetection.Backend.Domain.Entity.MediaRecord", b =>
                {
                    b.HasOne("FireDetection.Backend.Domain.Entity.MediaType", "MediaType")
                        .WithMany("MediaRecords")
                        .HasForeignKey("MediaTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("FireDetection.Backend.Domain.Entity.Record", "Record")
                        .WithMany("MediaRecords")
                        .HasForeignKey("RecordId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("MediaType");

                    b.Navigation("Record");
                });

            modelBuilder.Entity("FireDetection.Backend.Domain.Entity.Record", b =>
                {
                    b.HasOne("FireDetection.Backend.Domain.Entity.Camera", "Camera")
                        .WithMany("Records")
                        .HasForeignKey("CameraID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Camera");
                });

            modelBuilder.Entity("FireDetection.Backend.Domain.Entity.RecordProcess", b =>
                {
                    b.HasOne("FireDetection.Backend.Domain.Entity.ActionType", "ActionType")
                        .WithMany("RecordProcesses")
                        .HasForeignKey("ActionTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("FireDetection.Backend.Domain.Entity.Record", "Record")
                        .WithMany("RecordProcesses")
                        .HasForeignKey("RecordID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("FireDetection.Backend.Domain.Entity.User", "User")
                        .WithMany("RecordProcesses")
                        .HasForeignKey("UserID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ActionType");

                    b.Navigation("Record");

                    b.Navigation("User");
                });

            modelBuilder.Entity("FireDetection.Backend.Domain.Entity.User", b =>
                {
                    b.HasOne("FireDetection.Backend.Domain.Entity.Role", "Role")
                        .WithMany("Users")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Role");
                });

            modelBuilder.Entity("FireDetection.Backend.Domain.Entity.ActionType", b =>
                {
                    b.Navigation("RecordProcesses");
                });

            modelBuilder.Entity("FireDetection.Backend.Domain.Entity.Camera", b =>
                {
                    b.Navigation("Records");
                });

            modelBuilder.Entity("FireDetection.Backend.Domain.Entity.Level", b =>
                {
                    b.Navigation("AlarmRates");
                });

            modelBuilder.Entity("FireDetection.Backend.Domain.Entity.Location", b =>
                {
                    b.Navigation("Cameras");

                    b.Navigation("ControlCameras");
                });

            modelBuilder.Entity("FireDetection.Backend.Domain.Entity.MediaType", b =>
                {
                    b.Navigation("MediaRecords");
                });

            modelBuilder.Entity("FireDetection.Backend.Domain.Entity.Record", b =>
                {
                    b.Navigation("AlarmRates");

                    b.Navigation("MediaRecords");

                    b.Navigation("RecordProcesses");
                });

            modelBuilder.Entity("FireDetection.Backend.Domain.Entity.Role", b =>
                {
                    b.Navigation("Users");
                });

            modelBuilder.Entity("FireDetection.Backend.Domain.Entity.User", b =>
                {
                    b.Navigation("ControlCameras");

                    b.Navigation("RecordProcesses");
                });
#pragma warning restore 612, 618
        }
    }
}
