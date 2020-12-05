using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Leega.Entity.Migrations
{
    public partial class adicionadoCamposLogEdicaoCardEtiqueta : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "DataEdicao",
                table: "CardEtiquetas",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "ResponsavelEdicao",
                table: "CardEtiquetas",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DataEdicao",
                table: "CardEtiquetas");

            migrationBuilder.DropColumn(
                name: "ResponsavelEdicao",
                table: "CardEtiquetas");
        }
    }
}
