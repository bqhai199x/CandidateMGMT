using Microsoft.EntityFrameworkCore.Migrations;

namespace CandidateMGMT.Server.Migrations
{
    public partial class AddMailInfo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MailInfo_Body",
                table: "Candidate");

            migrationBuilder.DropColumn(
                name: "MailInfo_Title",
                table: "Candidate");
        }
    }
}
