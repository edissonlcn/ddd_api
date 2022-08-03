using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class ProfileMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {

            migrationBuilder.CreateTable(
                name: "PERFIL",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "RAW(16)", nullable: false),
                    Nome = table.Column<string>(type: "NVARCHAR2(255)", maxLength: 255, nullable: false),
                    CompanyId = table.Column<Guid>(type: "RAW(16)", nullable: false),
                    CreateAt = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: true),
                    UpdateAt = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PERFIL", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PERFIL_EMPRESA_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "EMPRESA",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PERMISSAO",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "RAW(16)", nullable: false),
                    Consultar = table.Column<bool>(type: "NUMBER(1)", nullable: false),
                    Cadastrar = table.Column<bool>(type: "NUMBER(1)", nullable: false),
                    Editar = table.Column<bool>(type: "NUMBER(1)", nullable: false),
                    Deletar = table.Column<bool>(type: "NUMBER(1)", nullable: false),
                    FunctionId = table.Column<Guid>(type: "RAW(16)", nullable: false),
                    ProfileId = table.Column<Guid>(type: "RAW(16)", nullable: false),
                    CreateAt = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: true),
                    UpdateAt = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PERMISSAO", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PERMISSAO_FUNCAO_FunctionId",
                        column: x => x.FunctionId,
                        principalTable: "FUNCAO",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PERMISSAO_PERFIL_ProfileId",
                        column: x => x.ProfileId,
                        principalTable: "PERFIL",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PERFIL_CompanyId",
                table: "PERFIL",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_PERMISSAO_FunctionId",
                table: "PERMISSAO",
                column: "FunctionId");

            migrationBuilder.CreateIndex(
                name: "IX_PERMISSAO_ProfileId",
                table: "PERMISSAO",
                column: "ProfileId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PERMISSAO");

            migrationBuilder.DropTable(
                name: "PERFIL");
        }
    }
}
