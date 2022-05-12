using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GarageApp.Migrations
{
    public partial class AddedCars : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cars",
                columns: table => new
                {
                    LicensePlate = table.Column<string>(type: "TEXT", nullable: false),
                    Brand = table.Column<string>(type: "TEXT", nullable: false),
                    Odometer = table.Column<decimal>(type: "TEXT", nullable: false),
                    SalesPrice = table.Column<decimal>(type: "TEXT", nullable: false),

                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cars", x => x.LicensePlate);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Cars");
        }
    }
}
