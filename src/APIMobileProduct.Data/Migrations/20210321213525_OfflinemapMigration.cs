using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class OfflinemapMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MAPA_OFFLINE",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "RAW(16)", nullable: false),
                    Nome = table.Column<string>(type: "NVARCHAR2(255)", maxLength: 255, nullable: false),
                    Url = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    CompanyId = table.Column<Guid>(type: "RAW(16)", nullable: false),
                    BasemapId = table.Column<Guid>(type: "RAW(16)", nullable: false),
                    CreateAt = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: true),
                    UpdateAt = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MAPA_OFFLINE", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MAPA_OFFLINE_EMPRESA_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "EMPRESA",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MAPA_OFFLINE_MAPA_BASE_BasemapId",
                        column: x => x.BasemapId,
                        principalTable: "MAPA_BASE",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "GroupEntityOfflinemapEntity",
                columns: table => new
                {
                    GroupsId = table.Column<Guid>(type: "RAW(16)", nullable: false),
                    OfflinemapsId = table.Column<Guid>(type: "RAW(16)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GroupEntityOfflinemapEntity", x => new { x.GroupsId, x.OfflinemapsId });
                    table.ForeignKey(
                        name: "FK_GroupEntityOfflinemapEntity_GRUPO_GroupsId",
                        column: x => x.GroupsId,
                        principalTable: "GRUPO",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GroupEntityOfflinemapEntity_MAPA_OFFLINE_OfflinemapsId",
                        column: x => x.OfflinemapsId,
                        principalTable: "MAPA_OFFLINE",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_GroupEntityOfflinemapEntity_OfflinemapsId",
                table: "GroupEntityOfflinemapEntity",
                column: "OfflinemapsId");

            migrationBuilder.CreateIndex(
                name: "IX_MAPA_OFFLINE_BasemapId",
                table: "MAPA_OFFLINE",
                column: "BasemapId");

            migrationBuilder.CreateIndex(
                name: "IX_MAPA_OFFLINE_CompanyId",
                table: "MAPA_OFFLINE",
                column: "CompanyId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GroupEntityOfflinemapEntity");

            migrationBuilder.DropTable(
                name: "MAPA_OFFLINE");
        }
    }
}
