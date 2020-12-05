using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Leega.Entity.Migrations
{
    public partial class IdTimeEnpsPesquisa : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EnpsPesquisaPergunta_EnpsPerguntas_IdPergunta",
                table: "EnpsPesquisaPergunta");

            migrationBuilder.DropForeignKey(
                name: "FK_EnpsPesquisaPergunta_EnpsPesquisas_IdPesquisa",
                table: "EnpsPesquisaPergunta");

            migrationBuilder.DropForeignKey(
                name: "FK_EnpsResposta_Organizacoes_IdOrganizacao",
                table: "EnpsResposta");

            migrationBuilder.DropForeignKey(
                name: "FK_EnpsResposta_EnpsPesquisaPergunta_IdPesquisaPergunta",
                table: "EnpsResposta");

            migrationBuilder.DropForeignKey(
                name: "FK_EnpsResposta_Pessoas_IdPessoa",
                table: "EnpsResposta");

            migrationBuilder.DropPrimaryKey(
                name: "PK_EnpsResposta",
                table: "EnpsResposta");

            migrationBuilder.DropPrimaryKey(
                name: "PK_EnpsPesquisaPergunta",
                table: "EnpsPesquisaPergunta");

            migrationBuilder.RenameTable(
                name: "EnpsResposta",
                newName: "EnpsRespostas");

            migrationBuilder.RenameTable(
                name: "EnpsPesquisaPergunta",
                newName: "EnpsPesquisaPerguntas");

            migrationBuilder.RenameIndex(
                name: "IX_EnpsResposta_IdPessoa",
                table: "EnpsRespostas",
                newName: "IX_EnpsRespostas_IdPessoa");

            migrationBuilder.RenameIndex(
                name: "IX_EnpsResposta_IdPesquisaPergunta",
                table: "EnpsRespostas",
                newName: "IX_EnpsRespostas_IdPesquisaPergunta");

            migrationBuilder.RenameIndex(
                name: "IX_EnpsResposta_IdOrganizacao",
                table: "EnpsRespostas",
                newName: "IX_EnpsRespostas_IdOrganizacao");

            migrationBuilder.RenameIndex(
                name: "IX_EnpsPesquisaPergunta_IdPesquisa",
                table: "EnpsPesquisaPerguntas",
                newName: "IX_EnpsPesquisaPerguntas_IdPesquisa");

            migrationBuilder.RenameIndex(
                name: "IX_EnpsPesquisaPergunta_IdPergunta",
                table: "EnpsPesquisaPerguntas",
                newName: "IX_EnpsPesquisaPerguntas_IdPergunta");

            migrationBuilder.AddColumn<Guid>(
                name: "IdTime",
                table: "EnpsPesquisas",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_EnpsRespostas",
                table: "EnpsRespostas",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_EnpsPesquisaPerguntas",
                table: "EnpsPesquisaPerguntas",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_EnpsPesquisas_IdTime",
                table: "EnpsPesquisas",
                column: "IdTime");

            migrationBuilder.AddForeignKey(
                name: "FK_EnpsPesquisaPerguntas_EnpsPerguntas_IdPergunta",
                table: "EnpsPesquisaPerguntas",
                column: "IdPergunta",
                principalTable: "EnpsPerguntas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_EnpsPesquisaPerguntas_EnpsPesquisas_IdPesquisa",
                table: "EnpsPesquisaPerguntas",
                column: "IdPesquisa",
                principalTable: "EnpsPesquisas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_EnpsPesquisas_Times_IdTime",
                table: "EnpsPesquisas",
                column: "IdTime",
                principalTable: "Times",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_EnpsRespostas_Organizacoes_IdOrganizacao",
                table: "EnpsRespostas",
                column: "IdOrganizacao",
                principalTable: "Organizacoes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_EnpsRespostas_EnpsPesquisaPerguntas_IdPesquisaPergunta",
                table: "EnpsRespostas",
                column: "IdPesquisaPergunta",
                principalTable: "EnpsPesquisaPerguntas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_EnpsRespostas_Pessoas_IdPessoa",
                table: "EnpsRespostas",
                column: "IdPessoa",
                principalTable: "Pessoas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EnpsPesquisaPerguntas_EnpsPerguntas_IdPergunta",
                table: "EnpsPesquisaPerguntas");

            migrationBuilder.DropForeignKey(
                name: "FK_EnpsPesquisaPerguntas_EnpsPesquisas_IdPesquisa",
                table: "EnpsPesquisaPerguntas");

            migrationBuilder.DropForeignKey(
                name: "FK_EnpsPesquisas_Times_IdTime",
                table: "EnpsPesquisas");

            migrationBuilder.DropForeignKey(
                name: "FK_EnpsRespostas_Organizacoes_IdOrganizacao",
                table: "EnpsRespostas");

            migrationBuilder.DropForeignKey(
                name: "FK_EnpsRespostas_EnpsPesquisaPerguntas_IdPesquisaPergunta",
                table: "EnpsRespostas");

            migrationBuilder.DropForeignKey(
                name: "FK_EnpsRespostas_Pessoas_IdPessoa",
                table: "EnpsRespostas");

            migrationBuilder.DropIndex(
                name: "IX_EnpsPesquisas_IdTime",
                table: "EnpsPesquisas");

            migrationBuilder.DropPrimaryKey(
                name: "PK_EnpsRespostas",
                table: "EnpsRespostas");

            migrationBuilder.DropPrimaryKey(
                name: "PK_EnpsPesquisaPerguntas",
                table: "EnpsPesquisaPerguntas");

            migrationBuilder.DropColumn(
                name: "IdTime",
                table: "EnpsPesquisas");

            migrationBuilder.RenameTable(
                name: "EnpsRespostas",
                newName: "EnpsResposta");

            migrationBuilder.RenameTable(
                name: "EnpsPesquisaPerguntas",
                newName: "EnpsPesquisaPergunta");

            migrationBuilder.RenameIndex(
                name: "IX_EnpsRespostas_IdPessoa",
                table: "EnpsResposta",
                newName: "IX_EnpsResposta_IdPessoa");

            migrationBuilder.RenameIndex(
                name: "IX_EnpsRespostas_IdPesquisaPergunta",
                table: "EnpsResposta",
                newName: "IX_EnpsResposta_IdPesquisaPergunta");

            migrationBuilder.RenameIndex(
                name: "IX_EnpsRespostas_IdOrganizacao",
                table: "EnpsResposta",
                newName: "IX_EnpsResposta_IdOrganizacao");

            migrationBuilder.RenameIndex(
                name: "IX_EnpsPesquisaPerguntas_IdPesquisa",
                table: "EnpsPesquisaPergunta",
                newName: "IX_EnpsPesquisaPergunta_IdPesquisa");

            migrationBuilder.RenameIndex(
                name: "IX_EnpsPesquisaPerguntas_IdPergunta",
                table: "EnpsPesquisaPergunta",
                newName: "IX_EnpsPesquisaPergunta_IdPergunta");

            migrationBuilder.AddPrimaryKey(
                name: "PK_EnpsResposta",
                table: "EnpsResposta",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_EnpsPesquisaPergunta",
                table: "EnpsPesquisaPergunta",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_EnpsPesquisaPergunta_EnpsPerguntas_IdPergunta",
                table: "EnpsPesquisaPergunta",
                column: "IdPergunta",
                principalTable: "EnpsPerguntas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_EnpsPesquisaPergunta_EnpsPesquisas_IdPesquisa",
                table: "EnpsPesquisaPergunta",
                column: "IdPesquisa",
                principalTable: "EnpsPesquisas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_EnpsResposta_Organizacoes_IdOrganizacao",
                table: "EnpsResposta",
                column: "IdOrganizacao",
                principalTable: "Organizacoes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_EnpsResposta_EnpsPesquisaPergunta_IdPesquisaPergunta",
                table: "EnpsResposta",
                column: "IdPesquisaPergunta",
                principalTable: "EnpsPesquisaPergunta",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_EnpsResposta_Pessoas_IdPessoa",
                table: "EnpsResposta",
                column: "IdPessoa",
                principalTable: "Pessoas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
