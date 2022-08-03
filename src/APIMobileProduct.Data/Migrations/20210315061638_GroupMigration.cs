using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class GroupMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "GRUPO",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "RAW(16)", nullable: false),
                    Nome = table.Column<string>(type: "NVARCHAR2(255)", maxLength: 255, nullable: false),
                    ProfileId = table.Column<Guid>(type: "RAW(16)", nullable: false),
                    CompanyId = table.Column<Guid>(type: "RAW(16)", nullable: false),
                    CreateAt = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: true),
                    UpdateAt = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GRUPO", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GRUPO");
        }
    }
}
