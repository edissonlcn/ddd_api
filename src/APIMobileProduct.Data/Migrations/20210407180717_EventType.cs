using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class EventType : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TipoGeometria",
                table: "TIPO_OCORRENCIA",
                type: "NUMBER(10)",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TipoGeometria",
                table: "TIPO_OCORRENCIA");
        }
    }
}
