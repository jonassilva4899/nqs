using Microsoft.EntityFrameworkCore.Migrations;

namespace Leega.Entity.Migrations
{
    public partial class ThroughtputCaminhoExcel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NomeArquivoPlainlha",
                table: "Throughputs");

            migrationBuilder.AddColumn<string>(
                name: "CaminhoExcel",
                table: "Throughputs",
                type: "VARCHAR(250)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CaminhoExcel",
                table: "Throughputs");

            migrationBuilder.AddColumn<string>(
                name: "NomeArquivoPlainlha",
                table: "Throughputs",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
