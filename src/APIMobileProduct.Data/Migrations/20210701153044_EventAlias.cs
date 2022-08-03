using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class EventAlias : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<float>(
                name: "Longitude",
                table: "MAPA_OFFLINE",
                type: "BINARY_FLOAT",
                nullable: true,
                oldClrType: typeof(float),
                oldType: "BINARY_FLOAT");

            migrationBuilder.AlterColumn<float>(
                name: "Latitude",
                table: "MAPA_OFFLINE",
                type: "BINARY_FLOAT",
                nullable: true,
                oldClrType: typeof(float),
                oldType: "BINARY_FLOAT");

            migrationBuilder.CreateTable(
                name: "ALIAS_OCORRENCIA",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "RAW(16)", nullable: false),
                    Field = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    Label = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    Type = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    CompanyId = table.Column<Guid>(type: "RAW(16)", nullable: false),
                    CreateAt = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: true),
                    UpdateAt = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ALIAS_OCORRENCIA", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ALIAS_OCORRENCIA");

            migrationBuilder.AlterColumn<float>(
                name: "Longitude",
                table: "MAPA_OFFLINE",
                type: "BINARY_FLOAT",
                nullable: false,
                defaultValue: 0f,
                oldClrType: typeof(float),
                oldType: "BINARY_FLOAT",
                oldNullable: true);

            migrationBuilder.AlterColumn<float>(
                name: "Latitude",
                table: "MAPA_OFFLINE",
                type: "BINARY_FLOAT",
                nullable: false,
                defaultValue: 0f,
                oldClrType: typeof(float),
                oldType: "BINARY_FLOAT",
                oldNullable: true);
        }
    }
}
