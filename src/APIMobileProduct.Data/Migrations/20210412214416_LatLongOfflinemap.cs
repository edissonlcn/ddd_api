using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class LatLongOfflinemap : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<float>(
                name: "Latitude",
                table: "MAPA_OFFLINE",
                type: "BINARY_FLOAT",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<float>(
                name: "Longitude",
                table: "MAPA_OFFLINE",
                type: "BINARY_FLOAT",
                nullable: false,
                defaultValue: 0f);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Latitude",
                table: "MAPA_OFFLINE");

            migrationBuilder.DropColumn(
                name: "Longitude",
                table: "MAPA_OFFLINE");
        }
    }
}
