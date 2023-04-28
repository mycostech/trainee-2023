using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CandidateAPIApplication.Migrations
{
    /// <inheritdoc />
    public partial class InitDatabase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CandidatesProfile_StatusCandidate_StatusCodeID",
                table: "CandidatesProfile");

            migrationBuilder.DropPrimaryKey(
                name: "PK_StatusCandidate",
                table: "StatusCandidate");

            migrationBuilder.RenameTable(
                name: "StatusCandidate",
                newName: "StatusCandidateProfile");

            migrationBuilder.AddPrimaryKey(
                name: "PK_StatusCandidateProfile",
                table: "StatusCandidateProfile",
                column: "StatusCodeID");

            migrationBuilder.AddForeignKey(
                name: "FK_CandidatesProfile_StatusCandidateProfile_StatusCodeID",
                table: "CandidatesProfile",
                column: "StatusCodeID",
                principalTable: "StatusCandidateProfile",
                principalColumn: "StatusCodeID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CandidatesProfile_StatusCandidateProfile_StatusCodeID",
                table: "CandidatesProfile");

            migrationBuilder.DropPrimaryKey(
                name: "PK_StatusCandidateProfile",
                table: "StatusCandidateProfile");

            migrationBuilder.RenameTable(
                name: "StatusCandidateProfile",
                newName: "StatusCandidate");

            migrationBuilder.AddPrimaryKey(
                name: "PK_StatusCandidate",
                table: "StatusCandidate",
                column: "StatusCodeID");

            migrationBuilder.AddForeignKey(
                name: "FK_CandidatesProfile_StatusCandidate_StatusCodeID",
                table: "CandidatesProfile",
                column: "StatusCodeID",
                principalTable: "StatusCandidate",
                principalColumn: "StatusCodeID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
