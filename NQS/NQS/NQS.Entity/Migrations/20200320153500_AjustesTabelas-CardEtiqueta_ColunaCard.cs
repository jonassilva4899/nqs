using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Leega.Entity.Migrations
{
    public partial class AjustesTabelasCardEtiqueta_ColunaCard : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ColunaCards_Iteracoes_IdIteracao",
                table: "ColunaCards");

            migrationBuilder.AlterColumn<int>(
                name: "Pontuacao",
                table: "ColunaCards",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<Guid>(
                name: "IdIteracao",
                table: "ColunaCards",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AddColumn<string>(
                name: "Cor",
                table: "CardEtiquetas",
                type: "VARCHAR(30)",
                nullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_ColunaCards_Iteracoes_IdIteracao",
                table: "ColunaCards",
                column: "IdIteracao",
                principalTable: "Iteracoes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ColunaCards_Iteracoes_IdIteracao",
                table: "ColunaCards");

            migrationBuilder.DropColumn(
                name: "Cor",
                table: "CardEtiquetas");

            migrationBuilder.AlterColumn<int>(
                name: "Pontuacao",
                table: "ColunaCards",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "IdIteracao",
                table: "ColunaCards",
                type: "uniqueidentifier",
                nullable: false,
                oldClrType: typeof(Guid),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_ColunaCards_Iteracoes_IdIteracao",
                table: "ColunaCards",
                column: "IdIteracao",
                principalTable: "Iteracoes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
