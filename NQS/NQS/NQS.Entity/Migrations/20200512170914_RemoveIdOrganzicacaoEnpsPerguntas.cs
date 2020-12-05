using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Leega.Entity.Migrations
{
    public partial class RemoveIdOrganzicacaoEnpsPerguntas : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EnpsPerguntas_Organizacoes_IdOrganizacao",
                table: "EnpsPerguntas");

            migrationBuilder.DropIndex(
                name: "IX_EnpsPerguntas_IdOrganizacao",
                table: "EnpsPerguntas");

            migrationBuilder.DropColumn(
                name: "IdOrganizacao",
                table: "EnpsPerguntas");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "IdOrganizacao",
                table: "EnpsPerguntas",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_EnpsPerguntas_IdOrganizacao",
                table: "EnpsPerguntas",
                column: "IdOrganizacao");

            migrationBuilder.AddForeignKey(
                name: "FK_EnpsPerguntas_Organizacoes_IdOrganizacao",
                table: "EnpsPerguntas",
                column: "IdOrganizacao",
                principalTable: "Organizacoes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
