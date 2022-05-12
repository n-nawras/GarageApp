using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GarageApp.Migrations
{
    public partial class AddedFilenameToCars : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ImageFileName",
                table: "Cars",
                type: "TEXT",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImageFileName",
                table: "Cars");
        }
    }
}
