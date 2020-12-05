using Microsoft.EntityFrameworkCore.Migrations;

namespace Leega.Entity.Migrations
{
    public partial class AjusteRealacaoTabelasDelegationBoard_Dominio : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_DelegationBoards_IdDominio",
                table: "DelegationBoards");

            migrationBuilder.CreateIndex(
                name: "IX_DelegationBoards_IdDominio",
                table: "DelegationBoards",
                column: "IdDominio");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_DelegationBoards_IdDominio",
                table: "DelegationBoards");

            migrationBuilder.CreateIndex(
                name: "IX_DelegationBoards_IdDominio",
                table: "DelegationBoards",
                column: "IdDominio",
                unique: true);
        }
    }
}
