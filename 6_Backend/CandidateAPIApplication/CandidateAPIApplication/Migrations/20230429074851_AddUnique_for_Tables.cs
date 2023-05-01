using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CandidateAPIApplication.Migrations
{
    /// <inheritdoc />
    public partial class AddUnique_for_Tables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_StatusCandidateProfile_StatusCodeID",
                table: "StatusCandidateProfile",
                column: "StatusCodeID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_CandidatesProfile_CandidateId",
                table: "CandidatesProfile",
                column: "CandidateId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_StatusCandidateProfile_StatusCodeID",
                table: "StatusCandidateProfile");

            migrationBuilder.DropIndex(
                name: "IX_CandidatesProfile_CandidateId",
                table: "CandidatesProfile");
        }
    }
}
