using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CandidateAPIApplication.Migrations
{
    /// <inheritdoc />
    public partial class Delete_FKey_StatusCode_CandidateProfile : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CandidatesProfiles_StatusCandidatesProfiles_StatusCodeID",
                table: "CandidatesProfiles");

            migrationBuilder.DropIndex(
                name: "IX_CandidatesProfiles_StatusCodeID",
                table: "CandidatesProfiles");

            migrationBuilder.AddColumn<int>(
                name: "StatusModelStatusCodeID",
                table: "CandidatesProfiles",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_CandidatesProfiles_StatusModelStatusCodeID",
                table: "CandidatesProfiles",
                column: "StatusModelStatusCodeID");

            migrationBuilder.AddForeignKey(
                name: "FK_CandidatesProfiles_StatusCandidatesProfiles_StatusModelStatusCodeID",
                table: "CandidatesProfiles",
                column: "StatusModelStatusCodeID",
                principalTable: "StatusCandidatesProfiles",
                principalColumn: "StatusCodeID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CandidatesProfiles_StatusCandidatesProfiles_StatusModelStatusCodeID",
                table: "CandidatesProfiles");

            migrationBuilder.DropIndex(
                name: "IX_CandidatesProfiles_StatusModelStatusCodeID",
                table: "CandidatesProfiles");

            migrationBuilder.DropColumn(
                name: "StatusModelStatusCodeID",
                table: "CandidatesProfiles");

            migrationBuilder.CreateIndex(
                name: "IX_CandidatesProfiles_StatusCodeID",
                table: "CandidatesProfiles",
                column: "StatusCodeID");

            migrationBuilder.AddForeignKey(
                name: "FK_CandidatesProfiles_StatusCandidatesProfiles_StatusCodeID",
                table: "CandidatesProfiles",
                column: "StatusCodeID",
                principalTable: "StatusCandidatesProfiles",
                principalColumn: "StatusCodeID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
