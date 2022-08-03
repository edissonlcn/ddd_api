using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class BasemapMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MAPA_BASE",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "RAW(16)", nullable: false),
                    Nome = table.Column<string>(type: "NVARCHAR2(255)", maxLength: 255, nullable: false),
                    Url = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    CompanyId = table.Column<Guid>(type: "RAW(16)", nullable: false),
                    CreateAt = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: true),
                    UpdateAt = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MAPA_BASE", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MAPA_BASE_EMPRESA_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "EMPRESA",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_GRUPO_ProfileId",
                table: "GRUPO",
                column: "ProfileId");

            migrationBuilder.CreateIndex(
                name: "IX_MAPA_BASE_CompanyId",
                table: "MAPA_BASE",
                column: "CompanyId");

            migrationBuilder.AddForeignKey(
                name: "FK_GRUPO_PERFIL_ProfileId",
                table: "GRUPO",
                column: "ProfileId",
                principalTable: "PERFIL",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GRUPO_PERFIL_ProfileId",
                table: "GRUPO");

            migrationBuilder.DropTable(
                name: "MAPA_BASE");

            migrationBuilder.DropIndex(
                name: "IX_GRUPO_ProfileId",
                table: "GRUPO");
        }
    }
}
