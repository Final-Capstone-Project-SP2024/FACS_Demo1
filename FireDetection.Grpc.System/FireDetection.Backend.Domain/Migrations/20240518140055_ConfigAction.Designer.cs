﻿// <auto-generated />
using System;
using FireDetection.Backend.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace FireDetection.Backend.Domain.Migrations
{
    [DbContext(typeof(FireDetectionDbContext))]
    [Migration("20240518140055_ConfigAction")]
    partial class ConfigAction
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
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

                    b.Property<decimal>("Max")
                        .HasColumnType("numeric");

                    b.Property<decimal>("Min")
                        .HasColumnType("numeric");

                    b.HasKey("ID");

                    b.ToTable("ActionTypes");

                    b.HasData(
                        new
                        {
                            ID = 1,
                            ActionDescription = "Small fire can be extinguished immediately",
                            ActionName = "Alarm Level 1",
                            Max = 60m,
                            Min = 0m
                        },
                        new
                        {
                            ID = 2,
                            ActionDescription = "the fire needs to mobilize more people in the nearby area",
                            ActionName = "Alarm Level 2",
                            Max = 70m,
                            Min = 60m
                        },
                        new
                        {
                            ID = 3,
                            ActionDescription = "a large fire can affect and cause damage, mobilizing everyone",
                            ActionName = "Alarm Level 3",
                            Max = 80m,
                            Min = 70m
                        },
                        new
                        {
                            ID = 4,
                            ActionDescription = "a large fire can affect and cause damage, mobilizing everyone",
                            ActionName = "Alarm Level 4",
                            Max = 90m,
                            Min = 80m
                        },
                        new
                        {
                            ID = 5,
                            ActionDescription = "a large fire can affect and cause damage, mobilizing everyone",
                            ActionName = "Alarm Level 5",
                            Max = 100m,
                            Min = 90m
                        },
                        new
                        {
                            ID = 6,
                            ActionDescription = "a large fire can affect and cause damage, mobilizing everyone",
                            ActionName = "End Action",
                            Max = 0m,
                            Min = 0m
                        },
                        new
                        {
                            ID = 7,
                            ActionDescription = "",
                            ActionName = "Fake  Alarm",
                            Max = 0m,
                            Min = 0m
                        },
                        new
                        {
                            ID = 8,
                            ActionDescription = "AI model is disconnected from the camera",
                            ActionName = "Repair the camera",
                            Max = 0m,
                            Min = 0m
                        });
                });

            modelBuilder.Entity("FireDetection.Backend.Domain.Entity.AlarmConfiguration", b =>
                {
                    b.Property<int>("AlarmConfigurationId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("AlarmConfigurationId"));

                    b.Property<string>("AlarmNameConfiguration")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<decimal>("End")
                        .HasColumnType("numeric");

                    b.Property<int?>("NumberOfNotification")
                        .HasColumnType("integer");

                    b.Property<decimal>("Start")
                        .HasColumnType("numeric");

                    b.HasKey("AlarmConfigurationId");

                    b.ToTable("AlarmConfigurations");

                    b.HasData(
                        new
                        {
                            AlarmConfigurationId = 1,
                            AlarmNameConfiguration = "Fake Alarm",
                            End = 20m,
                            Start = 0m
                        },
                        new
                        {
                            AlarmConfigurationId = 2,
                            AlarmNameConfiguration = "Fire",
                            End = 10m,
                            Start = 20m
                        });
                });

            modelBuilder.Entity("FireDetection.Backend.Domain.Entity.Camera", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("CameraDestination")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("CameraImage")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("CameraName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<Guid>("CreatedBy")
                        .HasColumnType("uuid");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<Guid?>("DeleteBy")
                        .HasColumnType("uuid");

                    b.Property<DateTime>("DeletedDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("boolean");

                    b.Property<DateTime>("LastModified")
                        .HasColumnType("timestamp without time zone");

                    b.Property<Guid>("LocationID")
                        .HasColumnType("uuid");

                    b.Property<Guid>("ModifiedBy")
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

            modelBuilder.Entity("FireDetection.Backend.Domain.Entity.Location", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid>("CreatedBy")
                        .HasColumnType("uuid");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<Guid?>("DeleteBy")
                        .HasColumnType("uuid");

                    b.Property<DateTime>("DeletedDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("boolean");

                    b.Property<DateTime>("LastModified")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("LocationImage")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("LocationName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<Guid>("ModifiedBy")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.ToTable("Locations");
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

            modelBuilder.Entity("FireDetection.Backend.Domain.Entity.NotificationLog", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<int>("Count")
                        .HasColumnType("integer");

                    b.Property<Guid>("CreatedBy")
                        .HasColumnType("uuid");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<Guid?>("DeleteBy")
                        .HasColumnType("uuid");

                    b.Property<DateTime>("DeletedDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("boolean");

                    b.Property<DateTime>("LastModified")
                        .HasColumnType("timestamp without time zone");

                    b.Property<Guid>("ModifiedBy")
                        .HasColumnType("uuid");

                    b.Property<int>("NotificationTypeId")
                        .HasColumnType("integer");

                    b.Property<Guid>("RecordId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("NotificationTypeId");

                    b.HasIndex("RecordId");

                    b.ToTable("NotificationLogs");
                });

            modelBuilder.Entity("FireDetection.Backend.Domain.Entity.NotificationType", b =>
                {
                    b.Property<int>("NotificationTypeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("NotificationTypeId"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("NotificationTypeId");

                    b.ToTable("NotificationType");

                    b.HasData(
                        new
                        {
                            NotificationTypeId = 1,
                            Name = "FireNotify"
                        },
                        new
                        {
                            NotificationTypeId = 2,
                            Name = "Voting"
                        },
                        new
                        {
                            NotificationTypeId = 3,
                            Name = "Alarm Level 1"
                        },
                        new
                        {
                            NotificationTypeId = 4,
                            Name = "Alarm Level 2"
                        },
                        new
                        {
                            NotificationTypeId = 5,
                            Name = "Alarm Level 3 "
                        },
                        new
                        {
                            NotificationTypeId = 6,
                            Name = "Alarm Level 4"
                        },
                        new
                        {
                            NotificationTypeId = 7,
                            Name = "Alarm Level 5"
                        },
                        new
                        {
                            NotificationTypeId = 8,
                            Name = "Fake Alarm"
                        },
                        new
                        {
                            NotificationTypeId = 9,
                            Name = "Disconnect Camera"
                        });
                });

            modelBuilder.Entity("FireDetection.Backend.Domain.Entity.Record", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<int>("AlarmConfigurationId")
                        .HasColumnType("integer");

                    b.Property<Guid>("CameraID")
                        .HasColumnType("uuid");

                    b.Property<Guid>("CreatedBy")
                        .HasColumnType("uuid");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<DateTime>("FinishAlarmTime")
                        .HasColumnType("timestamp without time zone");

                    b.Property<decimal>("PredictedPercent")
                        .HasColumnType("numeric");

                    b.Property<string>("RecommendAlarmLevel")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("RecordTime")
                        .HasColumnType("timestamp without time zone");

                    b.Property<int>("RecordTypeID")
                        .HasColumnType("integer");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("AlarmConfigurationId");

                    b.HasIndex("CameraID");

                    b.HasIndex("RecordTypeID");

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
                        .HasColumnType("timestamp without time zone");

                    b.Property<Guid>("RecordID")
                        .HasColumnType("uuid");

                    b.Property<Guid>("UserID")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("ActionTypeId");

                    b.HasIndex("RecordID");

                    b.HasIndex("UserID");

                    b.ToTable("RecordProcesses");
                });

            modelBuilder.Entity("FireDetection.Backend.Domain.Entity.RecordType", b =>
                {
                    b.Property<int>("RecordTypeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("RecordTypeId"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("RecordTypeId");

                    b.ToTable("RecordTypes");

                    b.HasData(
                        new
                        {
                            RecordTypeId = 1,
                            Name = "Detection"
                        },
                        new
                        {
                            RecordTypeId = 2,
                            Name = "ElectricalIncident"
                        },
                        new
                        {
                            RecordTypeId = 3,
                            Name = "AlarmByUser"
                        });
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
                        .HasColumnType("timestamp without time zone");

                    b.Property<Guid?>("DeleteBy")
                        .HasColumnType("uuid");

                    b.Property<DateTime>("DeletedDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("boolean");

                    b.Property<DateTime>("LastModified")
                        .HasColumnType("timestamp without time zone");

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

                    b.Property<string>("RefreshToken")
                        .HasColumnType("text");

                    b.Property<int>("RoleId")
                        .HasColumnType("integer");

                    b.Property<string>("SecurityCode")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            Id = new Guid("3c9a2a1b-f4dc-4468-a89c-f6be8ca3b541"),
                            CreatedBy = new Guid("00000000-0000-0000-0000-000000000000"),
                            CreatedDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            DeletedDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Email = "Admin@gmail.com",
                            IsDeleted = false,
                            LastModified = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            ModifiedBy = new Guid("00000000-0000-0000-0000-000000000000"),
                            Name = "Admin",
                            Password = "NJt3DCzVWSRDN7SigMcj+v/M8v+OWeZPBW/lApGrc+thCg3X",
                            Phone = "0902311453",
                            RefreshToken = "",
                            RoleId = 1,
                            SecurityCode = "XAD_000",
                            Status = "Active"
                        });
                });

            modelBuilder.Entity("FireDetection.Backend.Domain.Entity.UserReponsibility", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid>("CreatedBy")
                        .HasColumnType("uuid");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<Guid>("RecordId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("RecordId");

                    b.HasIndex("UserId");

                    b.ToTable("UserReponsibilities");
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

            modelBuilder.Entity("FireDetection.Backend.Domain.Entity.NotificationLog", b =>
                {
                    b.HasOne("FireDetection.Backend.Domain.Entity.NotificationType", "notificationType")
                        .WithMany("Log")
                        .HasForeignKey("NotificationTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("FireDetection.Backend.Domain.Entity.Record", "Record")
                        .WithMany("NotificationLogs")
                        .HasForeignKey("RecordId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Record");

                    b.Navigation("notificationType");
                });

            modelBuilder.Entity("FireDetection.Backend.Domain.Entity.Record", b =>
                {
                    b.HasOne("FireDetection.Backend.Domain.Entity.AlarmConfiguration", "AlarmConfiguration")
                        .WithMany("Records")
                        .HasForeignKey("AlarmConfigurationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("FireDetection.Backend.Domain.Entity.Camera", "Camera")
                        .WithMany("Records")
                        .HasForeignKey("CameraID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("FireDetection.Backend.Domain.Entity.RecordType", "RecordType")
                        .WithMany("Records")
                        .HasForeignKey("RecordTypeID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("AlarmConfiguration");

                    b.Navigation("Camera");

                    b.Navigation("RecordType");
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

            modelBuilder.Entity("FireDetection.Backend.Domain.Entity.UserReponsibility", b =>
                {
                    b.HasOne("FireDetection.Backend.Domain.Entity.Record", "Record")
                        .WithMany("userReponsibilities")
                        .HasForeignKey("RecordId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("FireDetection.Backend.Domain.Entity.User", "User")
                        .WithMany("UserReponsibilities")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Record");

                    b.Navigation("User");
                });

            modelBuilder.Entity("FireDetection.Backend.Domain.Entity.ActionType", b =>
                {
                    b.Navigation("RecordProcesses");
                });

            modelBuilder.Entity("FireDetection.Backend.Domain.Entity.AlarmConfiguration", b =>
                {
                    b.Navigation("Records");
                });

            modelBuilder.Entity("FireDetection.Backend.Domain.Entity.Camera", b =>
                {
                    b.Navigation("Records");
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

            modelBuilder.Entity("FireDetection.Backend.Domain.Entity.NotificationType", b =>
                {
                    b.Navigation("Log");
                });

            modelBuilder.Entity("FireDetection.Backend.Domain.Entity.Record", b =>
                {
                    b.Navigation("MediaRecords");

                    b.Navigation("NotificationLogs");

                    b.Navigation("RecordProcesses");

                    b.Navigation("userReponsibilities");
                });

            modelBuilder.Entity("FireDetection.Backend.Domain.Entity.RecordType", b =>
                {
                    b.Navigation("Records");
                });

            modelBuilder.Entity("FireDetection.Backend.Domain.Entity.Role", b =>
                {
                    b.Navigation("Users");
                });

            modelBuilder.Entity("FireDetection.Backend.Domain.Entity.User", b =>
                {
                    b.Navigation("ControlCameras");

                    b.Navigation("RecordProcesses");

                    b.Navigation("UserReponsibilities");
                });
#pragma warning restore 612, 618
        }
    }
}
