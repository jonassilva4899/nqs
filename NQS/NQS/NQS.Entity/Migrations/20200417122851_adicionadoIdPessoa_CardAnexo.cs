using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Leega.Entity.Migrations
{
    public partial class adicionadoIdPessoa_CardAnexo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "IdPessoa",
                table: "CardAnexos",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_CardAnexos_IdPessoa",
                table: "CardAnexos",
                column: "IdPessoa");

            migrationBuilder.AddForeignKey(
                name: "FK_CardAnexos_Pessoas_IdPessoa",
                table: "CardAnexos",
                column: "IdPessoa",
                principalTable: "Pessoas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CardAnexos_Pessoas_IdPessoa",
                table: "CardAnexos");

            migrationBuilder.DropIndex(
                name: "IX_CardAnexos_IdPessoa",
                table: "CardAnexos");

            migrationBuilder.DropColumn(
                name: "IdPessoa",
                table: "CardAnexos");
        }
    }
}
