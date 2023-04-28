using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CandidateAPIApplication.Migrations
{
    /// <inheritdoc />
    public partial class UpdateCandidateTable_FK : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CandidatesProfile_StatusModel_StatusCodeID",
                table: "CandidatesProfile");

            migrationBuilder.DropPrimaryKey(
                name: "PK_StatusModel",
                table: "StatusModel");

            migrationBuilder.RenameTable(
                name: "StatusModel",
                newName: "StatusCandidate");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "CandidatesProfile",
                newName: "CandidateId");

            migrationBuilder.AlterColumn<string>(
                name: "PhoneNumber",
                table: "CandidatesProfile",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(10)",
                oldMaxLength: 10);

            migrationBuilder.AlterColumn<string>(
                name: "LastName",
                table: "CandidatesProfile",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(250)",
                oldMaxLength: 250);

            migrationBuilder.AlterColumn<string>(
                name: "FirstName",
                table: "CandidatesProfile",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(250)",
                oldMaxLength: 250);

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "CandidatesProfile",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(300)",
                oldMaxLength: 300);

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CandidatesProfile_StatusCandidate_StatusCodeID",
                table: "CandidatesProfile");

            migrationBuilder.DropPrimaryKey(
                name: "PK_StatusCandidate",
                table: "StatusCandidate");

            migrationBuilder.RenameTable(
                name: "StatusCandidate",
                newName: "StatusModel");

            migrationBuilder.RenameColumn(
                name: "CandidateId",
                table: "CandidatesProfile",
                newName: "Id");

            migrationBuilder.AlterColumn<string>(
                name: "PhoneNumber",
                table: "CandidatesProfile",
                type: "nvarchar(10)",
                maxLength: 10,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "LastName",
                table: "CandidatesProfile",
                type: "nvarchar(250)",
                maxLength: 250,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "FirstName",
                table: "CandidatesProfile",
                type: "nvarchar(250)",
                maxLength: 250,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "CandidatesProfile",
                type: "nvarchar(300)",
                maxLength: 300,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddPrimaryKey(
                name: "PK_StatusModel",
                table: "StatusModel",
                column: "StatusCodeID");

            migrationBuilder.AddForeignKey(
                name: "FK_CandidatesProfile_StatusModel_StatusCodeID",
                table: "CandidatesProfile",
                column: "StatusCodeID",
                principalTable: "StatusModel",
                principalColumn: "StatusCodeID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
