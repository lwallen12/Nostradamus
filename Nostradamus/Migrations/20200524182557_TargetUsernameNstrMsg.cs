using Microsoft.EntityFrameworkCore.Migrations;

namespace Nostradamus.Migrations
{
    public partial class TargetUsernameNstrMsg : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "NosterTargetUserName",
                table: "NosterMessage",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NosterTargetUserName",
                table: "NosterMessage");
        }
    }
}
