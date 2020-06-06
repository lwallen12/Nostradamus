using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Nostradamus.Migrations
{
    public partial class NosterDisplay : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MessageTitle",
                table: "NosterMessage");

            migrationBuilder.DropColumn(
                name: "RefreshExpiration",
                table: "Noster");

            migrationBuilder.RenameColumn(
                name: "RefreshToken",
                table: "Noster",
                newName: "Motto");

            migrationBuilder.AddColumn<bool>(
                name: "IsSeen",
                table: "NosterMessage",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "DisplayName",
                table: "Noster",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsSeen",
                table: "NosterMessage");

            migrationBuilder.DropColumn(
                name: "DisplayName",
                table: "Noster");

            migrationBuilder.RenameColumn(
                name: "Motto",
                table: "Noster",
                newName: "RefreshToken");

            migrationBuilder.AddColumn<string>(
                name: "MessageTitle",
                table: "NosterMessage",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "RefreshExpiration",
                table: "Noster",
                nullable: true);
        }
    }
}
