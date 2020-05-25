using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Nostradamus.Migrations
{
    public partial class AddBackNosterRelation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "NosterRelation",
                columns: table => new
                {
                    NosterId = table.Column<string>(nullable: false),
                    RelatedNosterId = table.Column<string>(nullable: false),
                    CreationDate = table.Column<DateTime>(nullable: false),
                    UserName = table.Column<string>(nullable: true),
                    RelatedUserName = table.Column<string>(nullable: true),
                    RelationStatus = table.Column<string>(nullable: true),
                    RelationType = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NosterRelation", x => new { x.NosterId, x.RelatedNosterId, x.CreationDate });
                    table.UniqueConstraint("AK_NosterRelation_CreationDate_NosterId_RelatedNosterId", x => new { x.CreationDate, x.NosterId, x.RelatedNosterId });
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
