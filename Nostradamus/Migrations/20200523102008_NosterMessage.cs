using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Nostradamus.Migrations
{
    public partial class NosterMessage : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "NosterScore");

            migrationBuilder.CreateTable(
                name: "NosterMessage",
                columns: table => new
                {
                    NosterId = table.Column<string>(nullable: false),
                    MessageSource = table.Column<string>(nullable: false),
                    OriginTime = table.Column<DateTime>(nullable: false),
                    MessageBody = table.Column<string>(nullable: true),
                    MessageTitle = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NosterMessage", x => new { x.NosterId, x.MessageSource, x.OriginTime });
                    table.UniqueConstraint("AK_NosterMessage_MessageSource_NosterId_OriginTime", x => new { x.MessageSource, x.NosterId, x.OriginTime });
                    table.ForeignKey(
                        name: "FK_NosterMessage_Noster_NosterId",
                        column: x => x.NosterId,
                        principalTable: "Noster",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "NosterMessage");

            migrationBuilder.CreateTable(
                name: "NosterScore",
                columns: table => new
                {
                    NosterId = table.Column<string>(nullable: false),
                    GenericPredictionTotal = table.Column<int>(nullable: true),
                    RunningTotal = table.Column<int>(nullable: true),
                    UserName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NosterScore", x => x.NosterId);
                    table.ForeignKey(
                        name: "FK_NosterScore_Noster_NosterId",
                        column: x => x.NosterId,
                        principalTable: "Noster",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });
        }
    }
}
