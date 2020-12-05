using Microsoft.EntityFrameworkCore.Migrations;

namespace Leega.Entity.Migrations
{
    public partial class remocaoIsUniqueTipoColuna_TabelaQuadroColuna : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_QuadroColunas_TipoColuna",
                table: "QuadroColunas");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_QuadroColunas_TipoColuna",
                table: "QuadroColunas",
                column: "TipoColuna",
                unique: true,
                filter: "[TipoColuna] IS NOT NULL");
        }
    }
}
