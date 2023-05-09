using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CandidateAPIApplication.Migrations
{
    /// <inheritdoc />
    public partial class Delete_table_CommentAndCandidate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CandidatesProfiles_DateAppointmentProfiles_DateAppointmentId",
                table: "CandidatesProfiles");

            migrationBuilder.DropTable(
                name: "CandidatesComments");

            migrationBuilder.DropIndex(
                name: "IX_CandidatesProfiles_DateAppointmentId",
                table: "CandidatesProfiles");

            migrationBuilder.DropColumn(
                name: "DateAppointmentId",
                table: "CandidatesProfiles");

            migrationBuilder.AddColumn<int>(
                name: "CandidateId",
                table: "DateAppointmentProfiles",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "CandidateId",
                table: "CommentsAndScoresProfiles",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CandidateId",
                table: "DateAppointmentProfiles");

            migrationBuilder.DropColumn(
                name: "CandidateId",
                table: "CommentsAndScoresProfiles");

            migrationBuilder.AddColumn<int>(
                name: "DateAppointmentId",
                table: "CandidatesProfiles",
                type: "int",
                nullable: true);

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
                name: "IX_CandidatesProfiles_DateAppointmentId",
                table: "CandidatesProfiles",
                column: "DateAppointmentId");

            migrationBuilder.CreateIndex(
                name: "IX_CandidatesComments_CommentScoreId",
                table: "CandidatesComments",
                column: "CommentScoreId");

            migrationBuilder.AddForeignKey(
                name: "FK_CandidatesProfiles_DateAppointmentProfiles_DateAppointmentId",
                table: "CandidatesProfiles",
                column: "DateAppointmentId",
                principalTable: "DateAppointmentProfiles",
                principalColumn: "AppointmentID");
        }
    }
}
