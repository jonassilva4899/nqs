using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Leega.Entity.Migrations
{
    public partial class Cor_Etiqeuta_CardEtiqueta : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Cor",
                table: "CardEtiquetas");

            migrationBuilder.AddColumn<string>(
                name: "Cor",
                table: "Etiquetas",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "DataCriacao",
                table: "CardEtiquetas",
                type: "VARCHAR(30)",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Cor",
                table: "Etiquetas");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DataCriacao",
                table: "CardEtiquetas",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "VARCHAR(30)");

            migrationBuilder.AddColumn<string>(
                name: "Cor",
                table: "CardEtiquetas",
                type: "VARCHAR(30)",
                nullable: true);
        }
    }
}
