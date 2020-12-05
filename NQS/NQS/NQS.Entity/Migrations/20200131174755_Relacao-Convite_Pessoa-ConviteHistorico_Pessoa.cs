using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Leega.Entity.Migrations
{
    public partial class RelacaoConvite_PessoaConviteHistorico_Pessoa : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Convites_Pessoas_PessoaCriadaId",
                table: "Convites");

            migrationBuilder.DropForeignKey(
                name: "FK_ConvitesHistorico_Convites_IdConvite",
                table: "ConvitesHistorico");

            migrationBuilder.DropForeignKey(
                name: "FK_ConvitesHistorico_Pessoas_PessoaRequisitaId",
                table: "ConvitesHistorico");

            migrationBuilder.DropIndex(
                name: "IX_ConvitesHistorico_PessoaRequisitaId",
                table: "ConvitesHistorico");

            migrationBuilder.DropIndex(
                name: "IX_Convites_PessoaCriadaId",
                table: "Convites");

            migrationBuilder.DropColumn(
                name: "PessoaRequisitaId",
                table: "ConvitesHistorico");

            migrationBuilder.DropColumn(
                name: "PessoaCriadaId",
                table: "Convites");

            migrationBuilder.CreateIndex(
                name: "IX_ConvitesHistorico_IdPessoaRequisita",
                table: "ConvitesHistorico",
                column: "IdPessoaRequisita");

            migrationBuilder.CreateIndex(
                name: "IX_Convites_IdPessoaCriada",
                table: "Convites",
                column: "IdPessoaCriada");

            migrationBuilder.AddForeignKey(
                name: "FK_Convites_Pessoas_IdPessoaCriada",
                table: "Convites",
                column: "IdPessoaCriada",
                principalTable: "Pessoas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ConvitesHistorico_Convites_IdConvite",
                table: "ConvitesHistorico",
                column: "IdConvite",
                principalTable: "Convites",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ConvitesHistorico_Pessoas_IdPessoaRequisita",
                table: "ConvitesHistorico",
                column: "IdPessoaRequisita",
                principalTable: "Pessoas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Convites_Pessoas_IdPessoaCriada",
                table: "Convites");

            migrationBuilder.DropForeignKey(
                name: "FK_ConvitesHistorico_Convites_IdConvite",
                table: "ConvitesHistorico");

            migrationBuilder.DropForeignKey(
                name: "FK_ConvitesHistorico_Pessoas_IdPessoaRequisita",
                table: "ConvitesHistorico");

            migrationBuilder.DropIndex(
                name: "IX_ConvitesHistorico_IdPessoaRequisita",
                table: "ConvitesHistorico");

            migrationBuilder.DropIndex(
                name: "IX_Convites_IdPessoaCriada",
                table: "Convites");

            migrationBuilder.AddColumn<Guid>(
                name: "PessoaRequisitaId",
                table: "ConvitesHistorico",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "PessoaCriadaId",
                table: "Convites",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ConvitesHistorico_PessoaRequisitaId",
                table: "ConvitesHistorico",
                column: "PessoaRequisitaId");

            migrationBuilder.CreateIndex(
                name: "IX_Convites_PessoaCriadaId",
                table: "Convites",
                column: "PessoaCriadaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Convites_Pessoas_PessoaCriadaId",
                table: "Convites",
                column: "PessoaCriadaId",
                principalTable: "Pessoas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ConvitesHistorico_Convites_IdConvite",
                table: "ConvitesHistorico",
                column: "IdConvite",
                principalTable: "Convites",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ConvitesHistorico_Pessoas_PessoaRequisitaId",
                table: "ConvitesHistorico",
                column: "PessoaRequisitaId",
                principalTable: "Pessoas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
