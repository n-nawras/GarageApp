using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GarageApp.Migrations
{
    public partial class AddedAdminRole : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "c58b96f4-29b7-408d-a9a1-125f4dc8beef", "23346da8-1899-4a85-8ee5-34a42015fbbb", "Administrator", "ADMINISTRATOR" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c58b96f4-29b7-408d-a9a1-125f4dc8beef");
        }
    }
}
