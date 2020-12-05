using Microsoft.EntityFrameworkCore.Migrations;

namespace Leega.Entity.Migrations
{
    public partial class TipoQuadroColuna : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Projetos_IdResponsavelComercial",
                table: "Projetos");

            migrationBuilder.AddColumn<int>(
                name: "TipoColuna",
                table: "QuadroColunas",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_QuadroColunas_TipoColuna",
                table: "QuadroColunas",
                column: "TipoColuna",
                unique: true,
                filter: "[TipoColuna] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Projetos_IdResponsavelComercial",
                table: "Projetos",
                column: "IdResponsavelComercial");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_QuadroColunas_TipoColuna",
                table: "QuadroColunas");

            migrationBuilder.DropIndex(
                name: "IX_Projetos_IdResponsavelComercial",
                table: "Projetos");

            migrationBuilder.DropColumn(
                name: "TipoColuna",
                table: "QuadroColunas");

            migrationBuilder.CreateIndex(
                name: "IX_Projetos_IdResponsavelComercial",
                table: "Projetos",
                column: "IdResponsavelComercial",
                unique: true);
        }
    }
}
