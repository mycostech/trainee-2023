using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CandidateAPIApplication.Migrations
{
    /// <inheritdoc />
    public partial class Add_TableComment_And_TableConnet_between_Candidate_and_Comment : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CommentsAndScoresProfile",
                columns: table => new
                {
                    CommentScoreId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Comments = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Scores = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CommentsAndScoresProfile", x => x.CommentScoreId);
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
                        name: "FK_CandidatesComments_CandidatesProfile_CandidateId",
                        column: x => x.CandidateId,
                        principalTable: "CandidatesProfile",
                        principalColumn: "CandidateId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CandidatesComments_CommentsAndScoresProfile_CommentScoreId",
                        column: x => x.CommentScoreId,
                        principalTable: "CommentsAndScoresProfile",
                        principalColumn: "CommentScoreId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CandidatesComments_CommentScoreId",
                table: "CandidatesComments",
                column: "CommentScoreId");

            migrationBuilder.CreateIndex(
                name: "IX_CommentsAndScoresProfile_CommentScoreId",
                table: "CommentsAndScoresProfile",
                column: "CommentScoreId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CandidatesComments");

            migrationBuilder.DropTable(
                name: "CommentsAndScoresProfile");
        }
    }
}
