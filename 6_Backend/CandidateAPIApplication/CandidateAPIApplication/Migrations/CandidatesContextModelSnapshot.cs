﻿// <auto-generated />
using CandidateAPIApplication.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace CandidateAPIApplication.Migrations
{
    [DbContext(typeof(CandidatesContext))]
    partial class CandidatesContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("CandidateAPIApplication.Models.CandidatesAndCommentsModel", b =>
                {
                    b.Property<int>("CandidateId")
                        .HasColumnType("int");

                    b.Property<int>("CommentScoreId")
                        .HasColumnType("int");

                    b.Property<int>("CandidatesAndCommentsId")
                        .HasColumnType("int");

                    b.HasKey("CandidateId", "CommentScoreId");

                    b.HasIndex("CommentScoreId");

                    b.ToTable("CandidatesComments");
                });

            modelBuilder.Entity("CandidateAPIApplication.Models.CandidatesModel", b =>
                {
                    b.Property<int>("CandidateId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CandidateId"));

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PathImage")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PathResume")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("StatusCodeID")
                        .HasColumnType("int");

                    b.HasKey("CandidateId");

                    b.HasIndex("CandidateId")
                        .IsUnique();

                    b.HasIndex("StatusCodeID");

                    b.ToTable("CandidatesProfile");
                });

            modelBuilder.Entity("CandidateAPIApplication.Models.CommentsScoresModel", b =>
                {
                    b.Property<int>("CommentScoreId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CommentScoreId"));

                    b.Property<string>("Comments")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Scores")
                        .HasColumnType("int");

                    b.HasKey("CommentScoreId");

                    b.HasIndex("CommentScoreId")
                        .IsUnique();

                    b.ToTable("CommentsAndScoresProfile");
                });

            modelBuilder.Entity("CandidateAPIApplication.Models.DateAppointmentsModel", b =>
                {
                    b.Property<int>("AppointmentID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("AppointmentID"));

                    b.Property<string>("EndAppointment")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("StartAppointment")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("AppointmentID");

                    b.HasIndex("AppointmentID")
                        .IsUnique();

                    b.ToTable("DateAppointmentProfile");
                });

            modelBuilder.Entity("CandidateAPIApplication.Models.StatusModel", b =>
                {
                    b.Property<int>("StatusCodeID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("StatusCodeID"));

                    b.Property<string>("StatusDescription")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("StatusCodeID");

                    b.HasIndex("StatusCodeID")
                        .IsUnique();

                    b.ToTable("StatusCandidateProfile");
                });

            modelBuilder.Entity("CandidateAPIApplication.Models.CandidatesAndCommentsModel", b =>
                {
                    b.HasOne("CandidateAPIApplication.Models.CandidatesModel", "Candidates")
                        .WithMany("ListCandidateAndComment")
                        .HasForeignKey("CandidateId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CandidateAPIApplication.Models.CommentsScoresModel", "CommentsScores")
                        .WithMany("ListCandidateAndComment")
                        .HasForeignKey("CommentScoreId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Candidates");

                    b.Navigation("CommentsScores");
                });

            modelBuilder.Entity("CandidateAPIApplication.Models.CandidatesModel", b =>
                {
                    b.HasOne("CandidateAPIApplication.Models.StatusModel", "StatusCodes")
                        .WithMany("ListCandidates")
                        .HasForeignKey("StatusCodeID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("StatusCodes");
                });

            modelBuilder.Entity("CandidateAPIApplication.Models.CandidatesModel", b =>
                {
                    b.Navigation("ListCandidateAndComment");
                });

            modelBuilder.Entity("CandidateAPIApplication.Models.CommentsScoresModel", b =>
                {
                    b.Navigation("ListCandidateAndComment");
                });

            modelBuilder.Entity("CandidateAPIApplication.Models.StatusModel", b =>
                {
                    b.Navigation("ListCandidates");
                });
#pragma warning restore 612, 618
        }
    }
}
