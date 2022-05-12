using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GarageApp.Migrations
{
    public partial class AddedExampleCars : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Cars",
                columns: new[] { "LicensePlate", "Brand", "Odometer", "SalesPrice" },
                values: new object[] { "15NXNS", "FIAT", 180000m, 1500m });

            migrationBuilder.InsertData(
                table: "Cars",
                columns: new[] { "LicensePlate", "Brand", "Odometer", "SalesPrice" },
                values: new object[] { "57NVF9", "BMW", 170000m, 7000m });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "LicensePlate",
                keyValue: "15NXNS");

            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "LicensePlate",
                keyValue: "57NVF9");
        }
    }
}
