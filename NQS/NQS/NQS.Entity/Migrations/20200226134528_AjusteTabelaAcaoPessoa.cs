using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Leega.Entity.Migrations
{
    public partial class AjusteTabelaAcaoPessoa : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pessoas_Acao_AcaoId",
                table: "Pessoas");

            migrationBuilder.DropForeignKey(
                name: "FK_Pessoas_Acao_AcaoId1",
                table: "Pessoas");

            migrationBuilder.DropIndex(
                name: "IX_Pessoas_AcaoId",
                table: "Pessoas");

            migrationBuilder.DropIndex(
                name: "IX_Pessoas_AcaoId1",
                table: "Pessoas");

            migrationBuilder.DropColumn(
                name: "AcaoId",
                table: "Pessoas");

            migrationBuilder.DropColumn(
                name: "AcaoId1",
                table: "Pessoas");

            migrationBuilder.CreateIndex(
                name: "IX_Acao_IdPessoaCriacao",
                table: "Acao",
                column: "IdPessoaCriacao");

            migrationBuilder.CreateIndex(
                name: "IX_Acao_IdResponsavel",
                table: "Acao",
                column: "IdResponsavel");

            migrationBuilder.AddForeignKey(
                name: "FK_Acao_Pessoas_IdPessoaCriacao",
                table: "Acao",
                column: "IdPessoaCriacao",
                principalTable: "Pessoas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Acao_Pessoas_IdResponsavel",
                table: "Acao",
                column: "IdResponsavel",
                principalTable: "Pessoas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Acao_Pessoas_IdPessoaCriacao",
                table: "Acao");

            migrationBuilder.DropForeignKey(
                name: "FK_Acao_Pessoas_IdResponsavel",
                table: "Acao");

            migrationBuilder.DropIndex(
                name: "IX_Acao_IdPessoaCriacao",
                table: "Acao");

            migrationBuilder.DropIndex(
                name: "IX_Acao_IdResponsavel",
                table: "Acao");

            migrationBuilder.AddColumn<Guid>(
                name: "AcaoId",
                table: "Pessoas",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "AcaoId1",
                table: "Pessoas",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Pessoas_AcaoId",
                table: "Pessoas",
                column: "AcaoId");

            migrationBuilder.CreateIndex(
                name: "IX_Pessoas_AcaoId1",
                table: "Pessoas",
                column: "AcaoId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Pessoas_Acao_AcaoId",
                table: "Pessoas",
                column: "AcaoId",
                principalTable: "Acao",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Pessoas_Acao_AcaoId1",
                table: "Pessoas",
                column: "AcaoId1",
                principalTable: "Acao",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
