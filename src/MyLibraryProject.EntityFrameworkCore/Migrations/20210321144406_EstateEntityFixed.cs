using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MyLibraryProject.Migrations
{
    public partial class EstateEntityFixed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreationTime",
                table: "Estates");

            migrationBuilder.DropColumn(
                name: "CreatorUserId",
                table: "Estates");

            migrationBuilder.DropColumn(
                name: "DeleterUserId",
                table: "Estates");

            migrationBuilder.DropColumn(
                name: "DeletionTime",
                table: "Estates");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Estates");

            migrationBuilder.DropColumn(
                name: "LastModificationTime",
                table: "Estates");

            migrationBuilder.DropColumn(
                name: "LastModifierUserId",
                table: "Estates");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "CreationTime",
                table: "Estates",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<long>(
                name: "CreatorUserId",
                table: "Estates",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "DeleterUserId",
                table: "Estates",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletionTime",
                table: "Estates",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Estates",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "LastModificationTime",
                table: "Estates",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "LastModifierUserId",
                table: "Estates",
                type: "bigint",
                nullable: true);
        }
    }
}
