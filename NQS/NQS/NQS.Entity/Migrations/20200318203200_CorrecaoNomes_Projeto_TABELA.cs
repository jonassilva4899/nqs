using Microsoft.EntityFrameworkCore.Migrations;

namespace Leega.Entity.Migrations
{
    public partial class CorrecaoNomes_Projeto_TABELA : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Esforço",
                table: "Projetos");

            migrationBuilder.RenameColumn(
                name: "Descrição",
                table: "Projetos",
                newName: "Descricao");

            migrationBuilder.AddColumn<int>(
                name: "Esforco",
                table: "Projetos",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Esforco",
                table: "Projetos");

            migrationBuilder.RenameColumn(
                name: "Descricao",
                table: "Projetos",
                newName: "Descrição");

            migrationBuilder.AddColumn<int>(
                name: "Esforço",
                table: "Projetos",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
