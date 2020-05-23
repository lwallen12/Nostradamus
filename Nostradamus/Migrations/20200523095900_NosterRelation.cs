using Microsoft.EntityFrameworkCore.Migrations;

namespace Nostradamus.Migrations
{
    public partial class NosterRelation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "NosterRelation",
                columns: table => new
                {
                    NosterId = table.Column<string>(nullable: false),
                    UserName = table.Column<string>(nullable: true),
                    RelatedNosterId = table.Column<string>(nullable: false),
                    RelatedUserName = table.Column<string>(nullable: true),
                    RelationType = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NosterRelation", x => new { x.NosterId, x.RelatedNosterId, x.RelationType });
                    table.ForeignKey(
                        name: "FK_NosterRelation_Noster_NosterId",
                        column: x => x.NosterId,
                        principalTable: "Noster",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "NosterRelation");
        }
    }
}
