using Microsoft.EntityFrameworkCore.Migrations;

namespace Leega.Entity.Migrations
{
    public partial class ajusteCardinalidadeColunaCard_Projeto : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_ColunaCards_IdProjeto",
                table: "ColunaCards");

            migrationBuilder.CreateIndex(
                name: "IX_ColunaCards_IdProjeto",
                table: "ColunaCards",
                column: "IdProjeto");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_ColunaCards_IdProjeto",
                table: "ColunaCards");

            migrationBuilder.CreateIndex(
                name: "IX_ColunaCards_IdProjeto",
                table: "ColunaCards",
                column: "IdProjeto",
                unique: true,
                filter: "[IdProjeto] IS NOT NULL");
        }
    }
}
