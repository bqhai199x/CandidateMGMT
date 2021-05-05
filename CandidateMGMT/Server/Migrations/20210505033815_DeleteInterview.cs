using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CandidateMGMT.Server.Migrations
{
    public partial class DeleteInterview : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Interview");

            migrationBuilder.AddColumn<bool>(
                name: "InterContacted",
                table: "Candidate",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "InterLocation",
                table: "Candidate",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "InterNote",
                table: "Candidate",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "InterTime",
                table: "Candidate",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MailBody",
                table: "Candidate",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MailTitle",
                table: "Candidate",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "InterContacted",
                table: "Candidate");

            migrationBuilder.DropColumn(
                name: "InterLocation",
                table: "Candidate");

            migrationBuilder.DropColumn(
                name: "InterNote",
                table: "Candidate");

            migrationBuilder.DropColumn(
                name: "InterTime",
                table: "Candidate");

            migrationBuilder.DropColumn(
                name: "MailBody",
                table: "Candidate");

            migrationBuilder.DropColumn(
                name: "MailTitle",
                table: "Candidate");

            migrationBuilder.CreateTable(
                name: "Interview",
                columns: table => new
                {
                    InterviewId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Body = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CandidateId = table.Column<int>(type: "int", nullable: false),
                    IsContacted = table.Column<bool>(type: "bit", nullable: true),
                    Location = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Note = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Time = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true)
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
    }
}
