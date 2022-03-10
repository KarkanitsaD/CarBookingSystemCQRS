using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DAL.Migrations
{
    public partial class ImageWithBase64Content : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Content",
                table: "UserImages");

            migrationBuilder.DropColumn(
                name: "Content",
                table: "CarImages");

            migrationBuilder.RenameColumn(
                name: "Extension",
                table: "UserImages",
                newName: "Base64Content");

            migrationBuilder.RenameColumn(
                name: "Extension",
                table: "CarImages",
                newName: "Base64Content");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Base64Content",
                table: "UserImages",
                newName: "Extension");

            migrationBuilder.RenameColumn(
                name: "Base64Content",
                table: "CarImages",
                newName: "Extension");

            migrationBuilder.AddColumn<byte[]>(
                name: "Content",
                table: "UserImages",
                type: "bytea",
                nullable: false,
                defaultValue: new byte[0]);

            migrationBuilder.AddColumn<byte[]>(
                name: "Content",
                table: "CarImages",
                type: "bytea",
                nullable: false,
                defaultValue: new byte[0]);
        }
    }
}
