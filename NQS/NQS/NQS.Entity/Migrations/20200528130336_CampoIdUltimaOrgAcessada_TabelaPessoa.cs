using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Leega.Entity.Migrations
{
    public partial class CampoIdUltimaOrgAcessada_TabelaPessoa : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "IdUltimaOrgAcessada",
                table: "Pessoas",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Pessoas_IdUltimaOrgAcessada",
                table: "Pessoas",
                column: "IdUltimaOrgAcessada");

            migrationBuilder.AddForeignKey(
                name: "FK_Pessoas_Organizacoes_IdUltimaOrgAcessada",
                table: "Pessoas",
                column: "IdUltimaOrgAcessada",
                principalTable: "Organizacoes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pessoas_Organizacoes_IdUltimaOrgAcessada",
                table: "Pessoas");

            migrationBuilder.DropIndex(
                name: "IX_Pessoas_IdUltimaOrgAcessada",
                table: "Pessoas");

            migrationBuilder.DropColumn(
                name: "IdUltimaOrgAcessada",
                table: "Pessoas");
        }
    }
}
