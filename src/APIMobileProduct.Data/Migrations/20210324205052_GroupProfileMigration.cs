using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class GroupProfileMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GRUPO_PERFIL_ProfileId",
                table: "GRUPO");

            migrationBuilder.DropIndex(
                name: "IX_GRUPO_ProfileId",
                table: "GRUPO");

            migrationBuilder.CreateTable(
                name: "GroupEntityProfileEntity",
                columns: table => new
                {
                    GroupsId = table.Column<Guid>(type: "RAW(16)", nullable: false),
                    ProfilesId = table.Column<Guid>(type: "RAW(16)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GroupEntityProfileEntity", x => new { x.GroupsId, x.ProfilesId });
                    table.ForeignKey(
                        name: "FK_GroupEntityProfileEntity_GRUPO_GroupsId",
                        column: x => x.GroupsId,
                        principalTable: "GRUPO",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GroupEntityProfileEntity_PERFIL_ProfilesId",
                        column: x => x.ProfilesId,
                        principalTable: "PERFIL",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_GroupEntityProfileEntity_ProfilesId",
                table: "GroupEntityProfileEntity",
                column: "ProfilesId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GroupEntityProfileEntity");

            migrationBuilder.CreateIndex(
                name: "IX_GRUPO_ProfileId",
                table: "GRUPO",
                column: "ProfileId");

            migrationBuilder.AddForeignKey(
                name: "FK_GRUPO_PERFIL_ProfileId",
                table: "GRUPO",
                column: "ProfileId",
                principalTable: "PERFIL",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
