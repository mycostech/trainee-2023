﻿// <auto-generated />
using System;
using Candidate.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Candidate.Migrations
{
    [DbContext(typeof(TodoItemsContext))]
    partial class TodoItemsContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Candidate.Data.Appointment", b =>
                {
                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Meet")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId");

                    b.ToTable("Appointments");
                });

            modelBuilder.Entity("Candidate.Data.Picture", b =>
                {
                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Image")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId");

                    b.ToTable("Pictures");
                });

            modelBuilder.Entity("Candidate.Data.Score", b =>
                {
                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Attitude")
                        .HasColumnType("int");

                    b.Property<string>("Comment")
                        .HasColumnType("nvarchar(max)");

                    b.Property<float>("Evaluation")
                        .HasColumnType("real");

                    b.Property<int>("Experience")
                        .HasColumnType("int");

                    b.Property<int>("Personality")
                        .HasColumnType("int");

                    b.Property<int>("Skill")
                        .HasColumnType("int");

                    b.Property<int>("TeamPlayer")
                        .HasColumnType("int");

                    b.HasKey("UserId");

                    b.ToTable("Scores");
                });

            modelBuilder.Entity("Candidate.Data.UrlFile", b =>
                {
                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("File")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId");

                    b.ToTable("UrlFiles");
                });

            modelBuilder.Entity("Candidate.Data.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Firstname")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Lastname")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Position")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("Status")
                        .IsRequired()
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("Candidate.Data.Appointment", b =>
                {
                    b.HasOne("Candidate.Data.User", "UserAppointment")
                        .WithOne("OwnedAppointment")
                        .HasForeignKey("Candidate.Data.Appointment", "UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("UserAppointment");
                });

            modelBuilder.Entity("Candidate.Data.Picture", b =>
                {
                    b.HasOne("Candidate.Data.User", "UserPicture")
                        .WithOne("OwnedPicture")
                        .HasForeignKey("Candidate.Data.Picture", "UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("UserPicture");
                });

            modelBuilder.Entity("Candidate.Data.Score", b =>
                {
                    b.HasOne("Candidate.Data.User", "UserScore")
                        .WithOne("OwnedScore")
                        .HasForeignKey("Candidate.Data.Score", "UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("UserScore");
                });

            modelBuilder.Entity("Candidate.Data.UrlFile", b =>
                {
                    b.HasOne("Candidate.Data.User", "UserFile")
                        .WithOne("OwnedFile")
                        .HasForeignKey("Candidate.Data.UrlFile", "UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("UserFile");
                });

            modelBuilder.Entity("Candidate.Data.User", b =>
                {
                    b.Navigation("OwnedAppointment");

                    b.Navigation("OwnedFile");

                    b.Navigation("OwnedPicture");

                    b.Navigation("OwnedScore");
                });
#pragma warning restore 612, 618
        }
    }
}
