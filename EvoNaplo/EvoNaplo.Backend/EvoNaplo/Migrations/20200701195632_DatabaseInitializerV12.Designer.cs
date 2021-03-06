﻿// <auto-generated />
using System;
using EvoNaplo.DataAccessLayer;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace EvoNaplo.Migrations
{
    [DbContext(typeof(EvoNaploContext))]
    [Migration("20200701195632_DatabaseInitializerV12")]
    partial class DatabaseInitializerV12
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("EvoNaplo.Models.Attendance", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("AttendanceSheetId")
                        .HasColumnType("int");

                    b.Property<bool>("Attended")
                        .HasColumnType("bit");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<int?>("StudentId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("AttendanceSheetId");

                    b.HasIndex("StudentId");

                    b.ToTable("Attendances");
                });

            modelBuilder.Entity("EvoNaplo.Models.AttendanceSheet", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<DateTime>("MeetingDate")
                        .HasColumnType("datetime2");

                    b.Property<int?>("ProjectId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ProjectId");

                    b.ToTable("AttendanceSheets");
                });

            modelBuilder.Entity("EvoNaplo.Models.Evaluation", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("InterviewReview")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<string>("MentorsReview")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("SemesterId")
                        .HasColumnType("int");

                    b.Property<int?>("StudentDataId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("SemesterId");

                    b.HasIndex("StudentDataId");

                    b.ToTable("Evaluations");
                });

            modelBuilder.Entity("EvoNaplo.Models.Project", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("SemesterId")
                        .HasColumnType("int");

                    b.Property<string>("SourceLink")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UsedTechnologies")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Projects");
                });

            modelBuilder.Entity("EvoNaplo.Models.Semester", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DemoDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Semesters");
                });

            modelBuilder.Entity("EvoNaplo.Models.StudentData", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("ScholarshipTimestamp")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("StudentDatas");
                });

            modelBuilder.Entity("EvoNaplo.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Role")
                        .HasColumnType("int");

                    b.Property<int?>("StudentDataId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("StudentDataId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("EvoNaplo.Models.UserProject", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("projectId")
                        .HasColumnType("int");

                    b.Property<int>("userId")
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.HasIndex("projectId");

                    b.HasIndex("userId");

                    b.ToTable("UserProjects");
                });

            modelBuilder.Entity("EvoNaplo.Models.Attendance", b =>
                {
                    b.HasOne("EvoNaplo.Models.AttendanceSheet", null)
                        .WithMany("AttendancesList")
                        .HasForeignKey("AttendanceSheetId");

                    b.HasOne("EvoNaplo.Models.User", "Student")
                        .WithMany()
                        .HasForeignKey("StudentId");
                });

            modelBuilder.Entity("EvoNaplo.Models.AttendanceSheet", b =>
                {
                    b.HasOne("EvoNaplo.Models.Project", null)
                        .WithMany("AttendanceSheets")
                        .HasForeignKey("ProjectId");
                });

            modelBuilder.Entity("EvoNaplo.Models.Evaluation", b =>
                {
                    b.HasOne("EvoNaplo.Models.Semester", "Semester")
                        .WithMany()
                        .HasForeignKey("SemesterId");

                    b.HasOne("EvoNaplo.Models.StudentData", null)
                        .WithMany("Evaluations")
                        .HasForeignKey("StudentDataId");
                });

            modelBuilder.Entity("EvoNaplo.Models.User", b =>
                {
                    b.HasOne("EvoNaplo.Models.StudentData", "StudentData")
                        .WithMany()
                        .HasForeignKey("StudentDataId");
                });

            modelBuilder.Entity("EvoNaplo.Models.UserProject", b =>
                {
                    b.HasOne("EvoNaplo.Models.Project", "project")
                        .WithMany("userProjects")
                        .HasForeignKey("projectId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("EvoNaplo.Models.User", "user")
                        .WithMany("userProjects")
                        .HasForeignKey("userId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
