using Microsoft.EntityFrameworkCore.Migrations;

namespace Leega.Entity.Migrations
{
    public partial class ajusteCardinalidadeIteracao_ColunaCard : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_ColunaCards_IdIteracao",
                table: "ColunaCards");

            migrationBuilder.CreateIndex(
                name: "IX_ColunaCards_IdIteracao",
                table: "ColunaCards",
                column: "IdIteracao");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_ColunaCards_IdIteracao",
                table: "ColunaCards");

            migrationBuilder.CreateIndex(
                name: "IX_ColunaCards_IdIteracao",
                table: "ColunaCards",
                column: "IdIteracao",
                unique: true);
        }
    }
}
