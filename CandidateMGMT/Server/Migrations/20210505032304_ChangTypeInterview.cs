using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CandidateMGMT.Server.Migrations
{
    public partial class ChangTypeInterview : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Interview_IsContacted",
                table: "Candidate");

            migrationBuilder.DropColumn(
                name: "Interview_Location",
                table: "Candidate");

            migrationBuilder.DropColumn(
                name: "Interview_Note",
                table: "Candidate");

            migrationBuilder.DropColumn(
                name: "Interview_Time",
                table: "Candidate");

            migrationBuilder.DropColumn(
                name: "MailInfo_Body",
                table: "Candidate");

            migrationBuilder.DropColumn(
                name: "MailInfo_Title",
                table: "Candidate");

            migrationBuilder.CreateTable(
                name: "Interview",
                columns: table => new
                {
                    InterviewId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IsContacted = table.Column<bool>(type: "bit", nullable: true),
                    Time = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Location = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Note = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CandidateId = table.Column<int>(type: "int", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Body = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Interview", x => x.InterviewId);
                    table.ForeignKey(
                        name: "FK_Interview_Candidate_CandidateId",
                        column: x => x.CandidateId,
                        principalTable: "Candidate",
                        principalColumn: "CandidateId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Interview_CandidateId",
                table: "Interview",
                column: "CandidateId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Interview");

            migrationBuilder.AddColumn<bool>(
                name: "Interview_IsContacted",
                table: "Candidate",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Interview_Location",
                table: "Candidate",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Interview_Note",
                table: "Candidate",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "Interview_Time",
                table: "Candidate",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MailInfo_Body",
                table: "Candidate",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MailInfo_Title",
                table: "Candidate",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
