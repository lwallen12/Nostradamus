using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Nostradamus.Migrations
{
    public partial class RefreshToken : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "RefreshExpiration",
                table: "Noster",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "RefreshToken",
                table: "Noster",
                nullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "Valid",
                table: "GenericEvent",
                nullable: true,
                oldClrType: typeof(bool));

            migrationBuilder.AlterColumn<bool>(
                name: "Occurred",
                table: "GenericEvent",
                nullable: true,
                oldClrType: typeof(bool));

            migrationBuilder.AlterColumn<bool>(
                name: "Active",
                table: "GenericEvent",
                nullable: true,
                oldClrType: typeof(bool));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RefreshExpiration",
                table: "Noster");

            migrationBuilder.DropColumn(
                name: "RefreshToken",
                table: "Noster");

            migrationBuilder.AlterColumn<bool>(
                name: "Valid",
                table: "GenericEvent",
                nullable: false,
                oldClrType: typeof(bool),
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "Occurred",
                table: "GenericEvent",
                nullable: false,
                oldClrType: typeof(bool),
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "Active",
                table: "GenericEvent",
                nullable: false,
                oldClrType: typeof(bool),
                oldNullable: true);
        }
    }
}
