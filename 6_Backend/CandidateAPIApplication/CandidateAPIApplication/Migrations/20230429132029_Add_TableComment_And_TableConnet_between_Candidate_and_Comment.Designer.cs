﻿// <auto-generated />
using CandidateAPIApplication.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace CandidateAPIApplication.Migrations
{
    [DbContext(typeof(CandidatesContext))]
    [Migration("20230429132029_Add_TableComment_And_TableConnet_between_Candidate_and_Comment")]
    partial class Add_TableComment_And_TableConnet_between_Candidate_and_Comment
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
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
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
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
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Scores")
                        .HasColumnType("int");

                    b.HasKey("CommentScoreId");

                    b.HasIndex("CommentScoreId")
                        .IsUnique();

                    b.ToTable("CommentsAndScoresProfile");
                });

            modelBuilder.Entity("CandidateAPIApplication.Models.StatusModel", b =>
                {
                    b.Property<int>("StatusCodeID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("StatusCodeID"));

                    b.Property<string>("StatusDescription")
                        .IsRequired()
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
                        .WithMany("Candidates")
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
                    b.Navigation("Candidates");
                });
#pragma warning restore 612, 618
        }
    }
}
