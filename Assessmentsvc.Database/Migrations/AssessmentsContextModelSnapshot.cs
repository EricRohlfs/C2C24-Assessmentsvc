﻿// <auto-generated />
using Assessmentsvc.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using System;

namespace Assessmentsvc.Database.Migrations
{
    [DbContext(typeof(AssessmentsContext))]
    partial class AssessmentsContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn)
                .HasAnnotation("ProductVersion", "2.0.1-rtm-125");

            modelBuilder.Entity("Assessmentsvc.Database.Entity.AssessmentComment", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("Created");

                    b.Property<string>("Equipment");

                    b.Property<string>("Facility");

                    b.Property<DateTime>("Modified");

                    b.Property<string>("Ordnance");

                    b.Property<string>("Overall");

                    b.Property<string>("Personnel");

                    b.Property<string>("Supply");

                    b.Property<string>("Training");

                    b.HasKey("Id");

                    b.ToTable("AssessmentComments");
                });

            modelBuilder.Entity("Assessmentsvc.Database.Entity.CapabilityAssessment", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Abbreviation");

                    b.Property<string>("Achieved");

                    b.Property<DateTime>("Assessed");

                    b.Property<Guid>("CapabilityAssessmentId");

                    b.Property<DateTime>("Created");

                    b.Property<string>("Current");

                    b.Property<string>("Description");

                    b.Property<int>("Equipment");

                    b.Property<DateTime>("Modified");

                    b.Property<string>("Name");

                    b.Property<string>("Next");

                    b.Property<int>("Ordnance");

                    b.Property<int>("Overall");

                    b.Property<int>("Personnel");

                    b.Property<string>("Status");

                    b.Property<int>("Supply");

                    b.Property<int>("Training");

                    b.HasKey("Id");

                    b.ToTable("CapabilityAssessments");
                });

            modelBuilder.Entity("Assessmentsvc.Database.Entity.Condition", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid?>("ConditionDescriptorId");

                    b.Property<DateTime>("Created");

                    b.Property<string>("Description");

                    b.Property<DateTime>("Modified");

                    b.Property<string>("Number");

                    b.Property<Guid?>("TaskId");

                    b.Property<string>("Title");

                    b.HasKey("Id");

                    b.HasIndex("ConditionDescriptorId");

                    b.HasIndex("TaskId");

                    b.ToTable("Conditions");
                });

            modelBuilder.Entity("Assessmentsvc.Database.Entity.ConditionDescriptor", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("Created");

                    b.Property<DateTime>("Modified");

                    b.Property<string>("Text");

                    b.HasKey("Id");

                    b.ToTable("ConditionDescriptors");
                });

            modelBuilder.Entity("Assessmentsvc.Database.Entity.Measure", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("Created");

                    b.Property<string>("Description");

                    b.Property<DateTime>("Modified");

                    b.Property<string>("Number");

                    b.Property<string>("Scale");

                    b.Property<Guid?>("TaskId");

                    b.HasKey("Id");

                    b.HasIndex("TaskId");

                    b.ToTable("Measures");
                });

            modelBuilder.Entity("Assessmentsvc.Database.Entity.METAssessment", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Abbreviation");

                    b.Property<string>("Achieved");

                    b.Property<DateTime>("Assessed");

                    b.Property<Guid?>("CapabilityAssessmentId");

                    b.Property<DateTime>("Created");

                    b.Property<string>("Current");

                    b.Property<string>("Description");

                    b.Property<int>("Equipment");

                    b.Property<Guid>("METAssessmentId");

                    b.Property<DateTime>("Modified");

                    b.Property<string>("Name");

                    b.Property<string>("Next");

                    b.Property<int>("Ordnance");

                    b.Property<int>("Overall");

                    b.Property<int>("Personnel");

                    b.Property<string>("Status");

                    b.Property<int>("Supply");

                    b.Property<int>("Training");

                    b.HasKey("Id");

                    b.HasIndex("CapabilityAssessmentId");

                    b.ToTable("METAssessments");
                });

            modelBuilder.Entity("Assessmentsvc.Database.Entity.Mission", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Abbreviation");

                    b.Property<DateTime>("Created");

                    b.Property<string>("Description");

                    b.Property<DateTime>("Modified");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("Missions");
                });

            modelBuilder.Entity("Assessmentsvc.Database.Entity.Personnel", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("Assigned");

                    b.Property<int>("Authorized");

                    b.Property<DateTime>("Created");

                    b.Property<DateTime>("Modified");

                    b.Property<int>("Possessed");

                    b.Property<int>("Structured");

                    b.Property<string>("Type");

                    b.HasKey("Id");

                    b.ToTable("PersonnelData");
                });

            modelBuilder.Entity("Assessmentsvc.Database.Entity.Sorts", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ADCON");

                    b.Property<string>("CBRCurrent");

                    b.Property<string>("CBRProjected");

                    b.Property<string>("CBRTraining");

                    b.Property<string>("Category");

                    b.Property<string>("Code");

                    b.Property<DateTime>("Created");

                    b.Property<int>("Effectivity");

                    b.Property<string>("Embarked");

                    b.Property<int>("Equipment");

                    b.Property<string>("Latitude");

                    b.Property<int>("Level");

                    b.Property<int>("Limitation");

                    b.Property<string>("Longitude");

                    b.Property<DateTime>("Modified");

                    b.Property<string>("OPCON");

                    b.Property<int>("Ordnance");

                    b.Property<string>("Organization");

                    b.Property<int>("Overall");

                    b.Property<int>("Personnel");

                    b.Property<string>("Status");

                    b.Property<int>("Supply");

                    b.Property<int>("Training");

                    b.HasKey("Id");

                    b.ToTable("SortsAssessments");
                });

            modelBuilder.Entity("Assessmentsvc.Database.Entity.Task", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("Created");

                    b.Property<string>("Description");

                    b.Property<Guid?>("MissionId");

                    b.Property<DateTime>("Modified");

                    b.Property<string>("Number");

                    b.Property<string>("Title");

                    b.HasKey("Id");

                    b.HasIndex("MissionId");

                    b.ToTable("Tasks");
                });

            modelBuilder.Entity("Assessmentsvc.Database.Entity.Unit", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("Created");

                    b.Property<DateTime>("Modified");

                    b.Property<string>("Name");

                    b.Property<string>("Uic");

                    b.HasKey("Id");

                    b.ToTable("Units");
                });

            modelBuilder.Entity("Assessmentsvc.Database.Entity.Condition", b =>
                {
                    b.HasOne("Assessmentsvc.Database.Entity.ConditionDescriptor", "ConditionDescriptor")
                        .WithMany()
                        .HasForeignKey("ConditionDescriptorId");

                    b.HasOne("Assessmentsvc.Database.Entity.Task")
                        .WithMany("Conditions")
                        .HasForeignKey("TaskId");
                });

            modelBuilder.Entity("Assessmentsvc.Database.Entity.Measure", b =>
                {
                    b.HasOne("Assessmentsvc.Database.Entity.Task")
                        .WithMany("Standards")
                        .HasForeignKey("TaskId");
                });

            modelBuilder.Entity("Assessmentsvc.Database.Entity.METAssessment", b =>
                {
                    b.HasOne("Assessmentsvc.Database.Entity.CapabilityAssessment")
                        .WithMany("METAssessments")
                        .HasForeignKey("CapabilityAssessmentId");
                });

            modelBuilder.Entity("Assessmentsvc.Database.Entity.Task", b =>
                {
                    b.HasOne("Assessmentsvc.Database.Entity.Mission")
                        .WithMany("Met")
                        .HasForeignKey("MissionId");
                });
#pragma warning restore 612, 618
        }
    }
}
