﻿// <auto-generated />
using System;
using AWork.Candidatos.Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace AWork.Infra.Migrations
{
    [DbContext(typeof(CandidateContext))]
    [Migration("20210325170756_RenameTablePhoneToPhones")]
    partial class RenameTablePhoneToPhones
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.4")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("AWork.Candidates.Domain.Models.AcademicEducation", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("CandidateId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("College")
                        .IsRequired()
                        .HasColumnType("varchar(100)");

                    b.Property<Guid>("CourseId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("CourseStatus")
                        .HasColumnType("int");

                    b.Property<string>("CustomCourse")
                        .HasColumnType("varchar(100)");

                    b.Property<DateTime?>("EndDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("CandidateId");

                    b.HasIndex("CourseId");

                    b.ToTable("AcademicEducations");
                });

            modelBuilder.Entity("AWork.Candidates.Domain.Models.Address", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("City")
                        .IsRequired()
                        .HasColumnType("varchar(100)");

                    b.Property<string>("Complement")
                        .HasColumnType("varchar(200)");

                    b.Property<Guid>("CountryId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("District")
                        .IsRequired()
                        .HasColumnType("varchar(100)");

                    b.Property<string>("Number")
                        .IsRequired()
                        .HasColumnType("varchar(15)");

                    b.Property<string>("State")
                        .IsRequired()
                        .HasColumnType("varchar(70)");

                    b.Property<string>("Street")
                        .IsRequired()
                        .HasColumnType("varchar(100)");

                    b.Property<string>("ZipCode")
                        .HasColumnType("varchar(8)");

                    b.HasKey("Id");

                    b.HasIndex("CountryId");

                    b.ToTable("Address");
                });

            modelBuilder.Entity("AWork.Candidates.Domain.Models.Candidate", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("AddressId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("BirthDate")
                        .HasColumnType("datetime");

                    b.Property<string>("CPF")
                        .IsRequired()
                        .HasColumnType("varchar(11)");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("Deleted")
                        .HasColumnType("bit");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("varchar(100)");

                    b.Property<string>("FullName")
                        .HasColumnType("varchar(300)");

                    b.Property<int>("Gender")
                        .HasColumnType("int");

                    b.Property<string>("Goal")
                        .HasColumnType("varchar(450)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("varchar(200)");

                    b.Property<string>("LinkedIn")
                        .HasColumnType("varchar(500)");

                    b.Property<Guid?>("MaritalStatusId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("NationalityId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("PPD")
                        .HasColumnType("bit");

                    b.Property<string>("PhotoProfile")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("ReligionId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("SpecialNeedsId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Summary")
                        .HasColumnType("varchar(500)");

                    b.Property<DateTime>("UpdatedDate")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("AddressId");

                    b.HasIndex("MaritalStatusId");

                    b.HasIndex("NationalityId");

                    b.HasIndex("ReligionId");

                    b.HasIndex("SpecialNeedsId");

                    b.ToTable("Candidate");
                });

            modelBuilder.Entity("AWork.Candidates.Domain.Models.Contract", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Benefits")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("InterviewId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<double>("Salary")
                        .HasColumnType("float");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("datetime2");

                    b.Property<TimeSpan>("WorkingHours")
                        .HasColumnType("time");

                    b.HasKey("Id");

                    b.HasIndex("InterviewId")
                        .IsUnique();

                    b.ToTable("Contracts");
                });

            modelBuilder.Entity("AWork.Candidates.Domain.Models.Country", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("varchar(100)");

                    b.Property<string>("Nationality")
                        .IsRequired()
                        .HasColumnType("varchar(100)");

                    b.HasKey("Id");

                    b.ToTable("Country");
                });

            modelBuilder.Entity("AWork.Candidates.Domain.Models.Course", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("CourseLevelId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("CourseName")
                        .IsRequired()
                        .HasColumnType("varchar(200)");

                    b.HasKey("Id");

                    b.HasIndex("CourseLevelId");

                    b.ToTable("Courses");
                });

            modelBuilder.Entity("AWork.Candidates.Domain.Models.CourseLevel", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("CourseLevelName")
                        .IsRequired()
                        .HasColumnType("varchar(200)");

                    b.HasKey("Id");

                    b.ToTable("CourseLevels");
                });

            modelBuilder.Entity("AWork.Candidates.Domain.Models.Interview", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<byte[]>("Attachment")
                        .HasColumnType("varbinary(max)");

                    b.Property<Guid?>("CandidateId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("varchar(500)");

                    b.Property<string>("IndicationName")
                        .HasColumnType("varchar(100)");

                    b.Property<Guid>("InterviewStatusId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("InterviewsScheduleId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Rating")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CandidateId");

                    b.ToTable("Interviews");
                });

            modelBuilder.Entity("AWork.Candidates.Domain.Models.Job", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Benefits")
                        .IsRequired()
                        .HasColumnType("varchar(500)");

                    b.Property<Guid>("CreatedById")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime");

                    b.Property<bool>("Deleted")
                        .HasColumnType("bit");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("varchar(500)");

                    b.Property<int>("JobQuantity")
                        .HasColumnType("int");

                    b.Property<Guid>("JobRequestId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("Published")
                        .HasColumnType("bit");

                    b.Property<string>("Requirement")
                        .IsRequired()
                        .HasColumnType("varchar(500)");

                    b.Property<DateTime>("UpdatedDate")
                        .HasColumnType("datetime");

                    b.HasKey("Id");

                    b.HasIndex("CreatedById");

                    b.ToTable("Jobs");
                });

            modelBuilder.Entity("AWork.Candidates.Domain.Models.JobSubscribe", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("CandidateId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime");

                    b.Property<Guid>("JobId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("CandidateId");

                    b.HasIndex("JobId");

                    b.ToTable("JobSubscribes");
                });

            modelBuilder.Entity("AWork.Candidates.Domain.Models.JobTitle", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("Hidden")
                        .HasColumnType("bit");

                    b.Property<Guid?>("JobTitleId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("varchar(150)");

                    b.HasKey("Id");

                    b.HasIndex("JobTitleId");

                    b.ToTable("JobTitles");
                });

            modelBuilder.Entity("AWork.Candidates.Domain.Models.JobTitleInterested", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("CandidateId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("IsDefault")
                        .HasColumnType("bit");

                    b.Property<Guid>("JobTitleId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("CandidateId");

                    b.HasIndex("JobTitleId");

                    b.ToTable("JobTitleInteresteds");
                });

            modelBuilder.Entity("AWork.Candidates.Domain.Models.JobTitleLevel", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Level")
                        .IsRequired()
                        .HasColumnType("varchar(60)");

                    b.HasKey("Id");

                    b.ToTable("JobTitleLevels");
                });

            modelBuilder.Entity("AWork.Candidates.Domain.Models.Language", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("varchar(100)");

                    b.HasKey("Id");

                    b.ToTable("Languages");
                });

            modelBuilder.Entity("AWork.Candidates.Domain.Models.LanguageCandidate", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("CandidateId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("FluencyLevel")
                        .HasColumnType("int");

                    b.Property<Guid>("LanguageId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("CandidateId");

                    b.HasIndex("LanguageId");

                    b.ToTable("LanguegePerson");
                });

            modelBuilder.Entity("AWork.Candidates.Domain.Models.MaritalStatus", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("varchar(50)");

                    b.HasKey("Id");

                    b.ToTable("MaritalStatus");
                });

            modelBuilder.Entity("AWork.Candidates.Domain.Models.NotificationForCandidate", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("CandidateId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("datetime");

                    b.Property<Guid>("CreatedById")
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("Deleted")
                        .HasColumnType("bit");

                    b.Property<string>("Message")
                        .IsRequired()
                        .HasColumnType("varchar(500)");

                    b.Property<bool>("Read")
                        .HasColumnType("bit");

                    b.Property<DateTime>("ReadDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("varchar(60)");

                    b.HasKey("Id");

                    b.HasIndex("CandidateId");

                    b.ToTable("Notifications");
                });

            modelBuilder.Entity("AWork.Candidates.Domain.Models.Phone", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("CandidateId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("Default")
                        .HasColumnType("bit");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("varchar(11)");

                    b.Property<int>("PhoneType")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CandidateId");

                    b.ToTable("Phones");
                });

            modelBuilder.Entity("AWork.Candidates.Domain.Models.ProfessionalBackground", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("CandidateId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Company")
                        .IsRequired()
                        .HasColumnType("varchar(100)");

                    b.Property<bool>("CurrentJob")
                        .HasColumnType("bit");

                    b.Property<string>("DescriptionJob")
                        .IsRequired()
                        .HasColumnType("varchar(500)");

                    b.Property<DateTime?>("EndDate")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("JobTitleLevelId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("JobTitleName")
                        .IsRequired()
                        .HasColumnType("varchar(60)");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("WorkingAreaId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("CandidateId");

                    b.HasIndex("JobTitleLevelId");

                    b.HasIndex("WorkingAreaId");

                    b.ToTable("ProfessionalBackgrounds");
                });

            modelBuilder.Entity("AWork.Candidates.Domain.Models.Religion", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("varchar(200)");

                    b.HasKey("Id");

                    b.ToTable("Religions");
                });

            modelBuilder.Entity("AWork.Candidates.Domain.Models.SpecialNeeds", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("varchar(50)");

                    b.HasKey("Id");

                    b.ToTable("SpecialNeeds");
                });

            modelBuilder.Entity("AWork.Candidates.Domain.Models.WorkingArea", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("varchar(60)");

                    b.HasKey("Id");

                    b.ToTable("WorkingAreas");
                });

            modelBuilder.Entity("AWork.Candidates.Domain.Models.AcademicEducation", b =>
                {
                    b.HasOne("AWork.Candidates.Domain.Models.Candidate", "Candidate")
                        .WithMany("AcademicEducations")
                        .HasForeignKey("CandidateId")
                        .IsRequired();

                    b.HasOne("AWork.Candidates.Domain.Models.Course", "Course")
                        .WithMany("AcademicEducations")
                        .HasForeignKey("CourseId")
                        .IsRequired();

                    b.Navigation("Candidate");

                    b.Navigation("Course");
                });

            modelBuilder.Entity("AWork.Candidates.Domain.Models.Address", b =>
                {
                    b.HasOne("AWork.Candidates.Domain.Models.Country", "Country")
                        .WithMany("Address")
                        .HasForeignKey("CountryId")
                        .IsRequired();

                    b.Navigation("Country");
                });

            modelBuilder.Entity("AWork.Candidates.Domain.Models.Candidate", b =>
                {
                    b.HasOne("AWork.Candidates.Domain.Models.Address", "Address")
                        .WithMany()
                        .HasForeignKey("AddressId");

                    b.HasOne("AWork.Candidates.Domain.Models.MaritalStatus", "MaritalStatus")
                        .WithMany("Candidates")
                        .HasForeignKey("MaritalStatusId");

                    b.HasOne("AWork.Candidates.Domain.Models.Country", "Nationality")
                        .WithMany()
                        .HasForeignKey("NationalityId");

                    b.HasOne("AWork.Candidates.Domain.Models.Religion", "Religion")
                        .WithMany("Candidates")
                        .HasForeignKey("ReligionId");

                    b.HasOne("AWork.Candidates.Domain.Models.SpecialNeeds", "SpecialNeeds")
                        .WithMany("Candidates")
                        .HasForeignKey("SpecialNeedsId");

                    b.Navigation("Address");

                    b.Navigation("MaritalStatus");

                    b.Navigation("Nationality");

                    b.Navigation("Religion");

                    b.Navigation("SpecialNeeds");
                });

            modelBuilder.Entity("AWork.Candidates.Domain.Models.Contract", b =>
                {
                    b.HasOne("AWork.Candidates.Domain.Models.Interview", "Interview")
                        .WithOne("Contract")
                        .HasForeignKey("AWork.Candidates.Domain.Models.Contract", "InterviewId")
                        .IsRequired();

                    b.Navigation("Interview");
                });

            modelBuilder.Entity("AWork.Candidates.Domain.Models.Course", b =>
                {
                    b.HasOne("AWork.Candidates.Domain.Models.CourseLevel", "CourseLevel")
                        .WithMany("Course")
                        .HasForeignKey("CourseLevelId")
                        .IsRequired();

                    b.Navigation("CourseLevel");
                });

            modelBuilder.Entity("AWork.Candidates.Domain.Models.Interview", b =>
                {
                    b.HasOne("AWork.Candidates.Domain.Models.Candidate", null)
                        .WithMany("Interviews")
                        .HasForeignKey("CandidateId");
                });

            modelBuilder.Entity("AWork.Candidates.Domain.Models.Job", b =>
                {
                    b.HasOne("AWork.Candidates.Domain.Models.Candidate", "CreatedBy")
                        .WithMany("Jobs")
                        .HasForeignKey("CreatedById")
                        .IsRequired();

                    b.Navigation("CreatedBy");
                });

            modelBuilder.Entity("AWork.Candidates.Domain.Models.JobSubscribe", b =>
                {
                    b.HasOne("AWork.Candidates.Domain.Models.Candidate", "Candidate")
                        .WithMany("JobSubscribes")
                        .HasForeignKey("CandidateId")
                        .IsRequired();

                    b.HasOne("AWork.Candidates.Domain.Models.Job", "Job")
                        .WithMany("JobSubscribe")
                        .HasForeignKey("JobId")
                        .IsRequired();

                    b.Navigation("Candidate");

                    b.Navigation("Job");
                });

            modelBuilder.Entity("AWork.Candidates.Domain.Models.JobTitle", b =>
                {
                    b.HasOne("AWork.Candidates.Domain.Models.JobTitle", "JobTitleParent")
                        .WithMany("JobTitleChild")
                        .HasForeignKey("JobTitleId");

                    b.Navigation("JobTitleParent");
                });

            modelBuilder.Entity("AWork.Candidates.Domain.Models.JobTitleInterested", b =>
                {
                    b.HasOne("AWork.Candidates.Domain.Models.Candidate", "Candidate")
                        .WithMany("JobTitleInteresteds")
                        .HasForeignKey("CandidateId")
                        .IsRequired();

                    b.HasOne("AWork.Candidates.Domain.Models.JobTitle", "JobTitle")
                        .WithMany("JobTitleInteresteds")
                        .HasForeignKey("JobTitleId")
                        .IsRequired();

                    b.Navigation("Candidate");

                    b.Navigation("JobTitle");
                });

            modelBuilder.Entity("AWork.Candidates.Domain.Models.LanguageCandidate", b =>
                {
                    b.HasOne("AWork.Candidates.Domain.Models.Candidate", "Candidate")
                        .WithMany("Languages")
                        .HasForeignKey("CandidateId")
                        .IsRequired();

                    b.HasOne("AWork.Candidates.Domain.Models.Language", "Language")
                        .WithMany("Languages")
                        .HasForeignKey("LanguageId")
                        .IsRequired();

                    b.Navigation("Candidate");

                    b.Navigation("Language");
                });

            modelBuilder.Entity("AWork.Candidates.Domain.Models.NotificationForCandidate", b =>
                {
                    b.HasOne("AWork.Candidates.Domain.Models.Candidate", "Candidate")
                        .WithMany("Notifications")
                        .HasForeignKey("CandidateId")
                        .IsRequired();

                    b.Navigation("Candidate");
                });

            modelBuilder.Entity("AWork.Candidates.Domain.Models.Phone", b =>
                {
                    b.HasOne("AWork.Candidates.Domain.Models.Candidate", "Candidate")
                        .WithMany("Phones")
                        .HasForeignKey("CandidateId")
                        .IsRequired();

                    b.Navigation("Candidate");
                });

            modelBuilder.Entity("AWork.Candidates.Domain.Models.ProfessionalBackground", b =>
                {
                    b.HasOne("AWork.Candidates.Domain.Models.Candidate", "Candidate")
                        .WithMany("ProfessionalBackgrounds")
                        .HasForeignKey("CandidateId")
                        .IsRequired();

                    b.HasOne("AWork.Candidates.Domain.Models.JobTitleLevel", "JobTitleLevel")
                        .WithMany("ProfessionalBackgrounds")
                        .HasForeignKey("JobTitleLevelId")
                        .IsRequired();

                    b.HasOne("AWork.Candidates.Domain.Models.WorkingArea", "WorkingArea")
                        .WithMany("ProfessionalBackgrounds")
                        .HasForeignKey("WorkingAreaId")
                        .IsRequired();

                    b.Navigation("Candidate");

                    b.Navigation("JobTitleLevel");

                    b.Navigation("WorkingArea");
                });

            modelBuilder.Entity("AWork.Candidates.Domain.Models.Candidate", b =>
                {
                    b.Navigation("AcademicEducations");

                    b.Navigation("Interviews");

                    b.Navigation("Jobs");

                    b.Navigation("JobSubscribes");

                    b.Navigation("JobTitleInteresteds");

                    b.Navigation("Languages");

                    b.Navigation("Notifications");

                    b.Navigation("Phones");

                    b.Navigation("ProfessionalBackgrounds");
                });

            modelBuilder.Entity("AWork.Candidates.Domain.Models.Country", b =>
                {
                    b.Navigation("Address");
                });

            modelBuilder.Entity("AWork.Candidates.Domain.Models.Course", b =>
                {
                    b.Navigation("AcademicEducations");
                });

            modelBuilder.Entity("AWork.Candidates.Domain.Models.CourseLevel", b =>
                {
                    b.Navigation("Course");
                });

            modelBuilder.Entity("AWork.Candidates.Domain.Models.Interview", b =>
                {
                    b.Navigation("Contract");
                });

            modelBuilder.Entity("AWork.Candidates.Domain.Models.Job", b =>
                {
                    b.Navigation("JobSubscribe");
                });

            modelBuilder.Entity("AWork.Candidates.Domain.Models.JobTitle", b =>
                {
                    b.Navigation("JobTitleChild");

                    b.Navigation("JobTitleInteresteds");
                });

            modelBuilder.Entity("AWork.Candidates.Domain.Models.JobTitleLevel", b =>
                {
                    b.Navigation("ProfessionalBackgrounds");
                });

            modelBuilder.Entity("AWork.Candidates.Domain.Models.Language", b =>
                {
                    b.Navigation("Languages");
                });

            modelBuilder.Entity("AWork.Candidates.Domain.Models.MaritalStatus", b =>
                {
                    b.Navigation("Candidates");
                });

            modelBuilder.Entity("AWork.Candidates.Domain.Models.Religion", b =>
                {
                    b.Navigation("Candidates");
                });

            modelBuilder.Entity("AWork.Candidates.Domain.Models.SpecialNeeds", b =>
                {
                    b.Navigation("Candidates");
                });

            modelBuilder.Entity("AWork.Candidates.Domain.Models.WorkingArea", b =>
                {
                    b.Navigation("ProfessionalBackgrounds");
                });
#pragma warning restore 612, 618
        }
    }
}
