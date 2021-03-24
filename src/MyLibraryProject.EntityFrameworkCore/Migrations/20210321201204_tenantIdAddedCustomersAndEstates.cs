using Microsoft.EntityFrameworkCore.Migrations;

namespace MyLibraryProject.Migrations
{
    public partial class tenantIdAddedCustomersAndEstates : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TenantId",
                table: "Estates",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "TenantId",
                table: "Customers",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TenantId",
                table: "Estates");

            migrationBuilder.DropColumn(
                name: "TenantId",
                table: "Customers");
        }
    }
}
