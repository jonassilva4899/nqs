using Microsoft.EntityFrameworkCore.Migrations;

namespace Leega.Entity.Migrations
{
    public partial class Cardinalidade_Projeto_RespComercial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Projetos_IdResponsavelComercial",
                table: "Projetos");

            migrationBuilder.CreateIndex(
                name: "IX_Projetos_IdResponsavelComercial",
                table: "Projetos",
                column: "IdResponsavelComercial");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Projetos_IdResponsavelComercial",
                table: "Projetos");

            migrationBuilder.CreateIndex(
                name: "IX_Projetos_IdResponsavelComercial",
                table: "Projetos",
                column: "IdResponsavelComercial",
                unique: true);
        }
    }
}
