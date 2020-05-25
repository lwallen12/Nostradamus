using Microsoft.EntityFrameworkCore.Migrations;

namespace Nostradamus.Migrations
{
    public partial class AlterNosterRelation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "NosterRelation");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "NosterRelation",
                columns: table => new
                {
                    NosterId = table.Column<string>(nullable: false),
                    RelatedNosterId = table.Column<string>(nullable: false),
                    RelationType = table.Column<string>(nullable: false),
                    RelatedUserName = table.Column<string>(nullable: true),
                    UserName = table.Column<string>(nullable: true)
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
    }
}
