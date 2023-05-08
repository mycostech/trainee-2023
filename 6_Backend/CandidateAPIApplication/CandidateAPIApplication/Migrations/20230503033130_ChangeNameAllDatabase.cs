using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CandidateAPIApplication.Migrations
{
    /// <inheritdoc />
    public partial class ChangeNameAllDatabase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CommentsAndScoresProfiles",
                columns: table => new
                {
                    CommentScoreId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Comments = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Scores = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CommentsAndScoresProfiles", x => x.CommentScoreId);
                });

            migrationBuilder.CreateTable(
                name: "DateAppointmentProfiles",
                columns: table => new
                {
                    AppointmentID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StartAppointment = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EndAppointment = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DateAppointmentProfiles", x => x.AppointmentID);
                });

            migrationBuilder.CreateTable(
                name: "StatusCandidatesProfiles",
                columns: table => new
                {
                    StatusCodeID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StatusDescription = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StatusCandidatesProfiles", x => x.StatusCodeID);
                });

            migrationBuilder.CreateTable(
                name: "CandidatesProfiles",
                columns: table => new
                {
                    CandidateId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PathImage = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PathResume = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateAppointmentId = table.Column<int>(type: "int", nullable: true),
                    StatusCodeID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CandidatesProfiles", x => x.CandidateId);
                    table.ForeignKey(
                        name: "FK_CandidatesProfiles_DateAppointmentProfiles_DateAppointmentId",
                        column: x => x.DateAppointmentId,
                        principalTable: "DateAppointmentProfiles",
                        principalColumn: "AppointmentID");
                    table.ForeignKey(
                        name: "FK_CandidatesProfiles_StatusCandidatesProfiles_StatusCodeID",
                        column: x => x.StatusCodeID,
                        principalTable: "StatusCandidatesProfiles",
                        principalColumn: "StatusCodeID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CandidatesComments",
                columns: table => new
                {
                    CandidateId = table.Column<int>(type: "int", nullable: false),
                    CommentScoreId = table.Column<int>(type: "int", nullable: false),
                    CandidatesAndCommentsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CandidatesComments", x => new { x.CandidateId, x.CommentScoreId });
                    table.ForeignKey(
                        name: "FK_CandidatesComments_CandidatesProfiles_CandidateId",
                        column: x => x.CandidateId,
                        principalTable: "CandidatesProfiles",
                        principalColumn: "CandidateId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CandidatesComments_CommentsAndScoresProfiles_CommentScoreId",
                        column: x => x.CommentScoreId,
                        principalTable: "CommentsAndScoresProfiles",
                        principalColumn: "CommentScoreId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CandidatesComments_CommentScoreId",
                table: "CandidatesComments",
                column: "CommentScoreId");

            migrationBuilder.CreateIndex(
                name: "IX_CandidatesProfiles_CandidateId",
                table: "CandidatesProfiles",
                column: "CandidateId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_CandidatesProfiles_DateAppointmentId",
                table: "CandidatesProfiles",
                column: "DateAppointmentId");

            migrationBuilder.CreateIndex(
                name: "IX_CandidatesProfiles_StatusCodeID",
                table: "CandidatesProfiles",
                column: "StatusCodeID");

            migrationBuilder.CreateIndex(
                name: "IX_CommentsAndScoresProfiles_CommentScoreId",
                table: "CommentsAndScoresProfiles",
                column: "CommentScoreId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_DateAppointmentProfiles_AppointmentID",
                table: "DateAppointmentProfiles",
                column: "AppointmentID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_StatusCandidatesProfiles_StatusCodeID",
                table: "StatusCandidatesProfiles",
                column: "StatusCodeID",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CandidatesComments");

            migrationBuilder.DropTable(
                name: "CandidatesProfiles");

            migrationBuilder.DropTable(
                name: "CommentsAndScoresProfiles");

            migrationBuilder.DropTable(
                name: "DateAppointmentProfiles");

            migrationBuilder.DropTable(
                name: "StatusCandidatesProfiles");
        }
    }
}
