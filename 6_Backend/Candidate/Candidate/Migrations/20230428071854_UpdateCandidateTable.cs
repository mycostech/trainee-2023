using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Candidate.Migrations
{
    /// <inheritdoc />
    public partial class UpdateCandidateTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Appointments_Users_UserId",
                table: "Appointments");

            migrationBuilder.DropForeignKey(
                name: "FK_Notifications_Users_UserId",
                table: "Notifications");

            migrationBuilder.DropForeignKey(
                name: "FK_Pictures_Users_UserId",
                table: "Pictures");

            migrationBuilder.DropForeignKey(
                name: "FK_Scores_Users_UserId",
                table: "Scores");

            migrationBuilder.AddColumn<Guid>(
                name: "User_ScoreId",
                table: "Scores",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "User_PictureId",
                table: "Pictures",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "User_NotificationId",
                table: "Notifications",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "User_AppointmentId",
                table: "Appointments",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_Scores_User_ScoreId",
                table: "Scores",
                column: "User_ScoreId");

            migrationBuilder.CreateIndex(
                name: "IX_Pictures_User_PictureId",
                table: "Pictures",
                column: "User_PictureId");

            migrationBuilder.CreateIndex(
                name: "IX_Notifications_User_NotificationId",
                table: "Notifications",
                column: "User_NotificationId");

            migrationBuilder.CreateIndex(
                name: "IX_Appointments_User_AppointmentId",
                table: "Appointments",
                column: "User_AppointmentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Appointments_Users_User_AppointmentId",
                table: "Appointments",
                column: "User_AppointmentId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Notifications_Users_User_NotificationId",
                table: "Notifications",
                column: "User_NotificationId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Pictures_Users_User_PictureId",
                table: "Pictures",
                column: "User_PictureId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Scores_Users_User_ScoreId",
                table: "Scores",
                column: "User_ScoreId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Appointments_Users_User_AppointmentId",
                table: "Appointments");

            migrationBuilder.DropForeignKey(
                name: "FK_Notifications_Users_User_NotificationId",
                table: "Notifications");

            migrationBuilder.DropForeignKey(
                name: "FK_Pictures_Users_User_PictureId",
                table: "Pictures");

            migrationBuilder.DropForeignKey(
                name: "FK_Scores_Users_User_ScoreId",
                table: "Scores");

            migrationBuilder.DropIndex(
                name: "IX_Scores_User_ScoreId",
                table: "Scores");

            migrationBuilder.DropIndex(
                name: "IX_Pictures_User_PictureId",
                table: "Pictures");

            migrationBuilder.DropIndex(
                name: "IX_Notifications_User_NotificationId",
                table: "Notifications");

            migrationBuilder.DropIndex(
                name: "IX_Appointments_User_AppointmentId",
                table: "Appointments");

            migrationBuilder.DropColumn(
                name: "User_ScoreId",
                table: "Scores");

            migrationBuilder.DropColumn(
                name: "User_PictureId",
                table: "Pictures");

            migrationBuilder.DropColumn(
                name: "User_NotificationId",
                table: "Notifications");

            migrationBuilder.DropColumn(
                name: "User_AppointmentId",
                table: "Appointments");

            migrationBuilder.AddForeignKey(
                name: "FK_Appointments_Users_UserId",
                table: "Appointments",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Notifications_Users_UserId",
                table: "Notifications",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Pictures_Users_UserId",
                table: "Pictures",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Scores_Users_UserId",
                table: "Scores",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
