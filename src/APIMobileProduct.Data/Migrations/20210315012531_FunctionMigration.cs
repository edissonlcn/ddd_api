using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class FunctionMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "EMPRESA",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "RAW(16)", nullable: false),
                    Nome = table.Column<string>(type: "NVARCHAR2(255)", maxLength: 255, nullable: false),
                    File = table.Column<byte[]>(type: "BLOB", nullable: false),
                    Filename = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    CreateAt = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: true),
                    UpdateAt = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EMPRESA", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FUNCAO",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "RAW(16)", nullable: false),
                    Nome = table.Column<string>(type: "NVARCHAR2(255)", maxLength: 255, nullable: false),
                    Codigo = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    CreateAt = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: true),
                    UpdateAt = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FUNCAO", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EMPRESA");

            migrationBuilder.DropTable(
                name: "FUNCAO");
        }
    }
}
