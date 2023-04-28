using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CandidateAPIApplication.Migrations
{
    /// <inheritdoc />
    public partial class UpdateCandidateTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "StatusModel",
                columns: table => new
                {
                    StatusCodeID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StatusDescription = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StatusModel", x => x.StatusCodeID);
                });

            migrationBuilder.CreateTable(
                name: "CandidatesProfile",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false),
                    StatusCodeID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CandidatesProfile", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CandidatesProfile_StatusModel_StatusCodeID",
                        column: x => x.StatusCodeID,
                        principalTable: "StatusModel",
                        principalColumn: "StatusCodeID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CandidatesProfile_StatusCodeID",
                table: "CandidatesProfile",
                column: "StatusCodeID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CandidatesProfile");

            migrationBuilder.DropTable(
                name: "StatusModel");
        }
    }
}
