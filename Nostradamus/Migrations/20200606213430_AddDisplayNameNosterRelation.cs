using Microsoft.EntityFrameworkCore.Migrations;

namespace Nostradamus.Migrations
{
    public partial class AddDisplayNameNosterRelation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "DisplayName",
                table: "NosterRelation",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "RelatedDisplayName",
                table: "NosterRelation",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DisplayName",
                table: "NosterRelation");

            migrationBuilder.DropColumn(
                name: "RelatedDisplayName",
                table: "NosterRelation");
        }
    }
}
