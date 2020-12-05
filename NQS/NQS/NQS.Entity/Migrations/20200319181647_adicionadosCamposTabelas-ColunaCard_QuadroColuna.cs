using Microsoft.EntityFrameworkCore.Migrations;

namespace Leega.Entity.Migrations
{
    public partial class adicionadosCamposTabelasColunaCard_QuadroColuna : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "WipLimit",
                table: "QuadroColunas",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "Bloqueado",
                table: "ColunaCards",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "MotivoBloqueio",
                table: "ColunaCards",
                type: "VARCHAR(1000)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "WipLimit",
                table: "QuadroColunas");

            migrationBuilder.DropColumn(
                name: "Bloqueado",
                table: "ColunaCards");

            migrationBuilder.DropColumn(
                name: "MotivoBloqueio",
                table: "ColunaCards");
        }
    }
}
