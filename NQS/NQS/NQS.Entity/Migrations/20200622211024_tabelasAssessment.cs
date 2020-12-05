using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Leega.Entity.Migrations
{
    public partial class tabelasAssessment : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AssessmentPesquisas",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    IdOrganizacao = table.Column<Guid>(nullable: false),
                    IdTime = table.Column<Guid>(nullable: true),
                    ApenasUsuarios = table.Column<bool>(nullable: false),
                    DataCriacao = table.Column<DateTime>(nullable: false),
                    ResponsavelCriacao = table.Column<Guid>(nullable: false),
                    DataEdicao = table.Column<DateTime>(nullable: true),
                    ResponsavelEdicao = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AssessmentPesquisas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AssessmentPesquisas_Organizacoes_IdOrganizacao",
                        column: x => x.IdOrganizacao,
                        principalTable: "Organizacoes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AssessmentPesquisas_Times_IdTime",
                        column: x => x.IdTime,
                        principalTable: "Times",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AssessmentPesquisaQuestoes",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    IdPesquisa = table.Column<Guid>(nullable: false),
                    IdQuestao = table.Column<Guid>(nullable: false),
                    Ordem = table.Column<int>(nullable: false),
                    DataCriacao = table.Column<DateTime>(nullable: false),
                    ResponsavelCriacao = table.Column<Guid>(nullable: false),
                    IdOrganizacao = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AssessmentPesquisaQuestoes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AssessmentPesquisaQuestoes_Organizacoes_IdOrganizacao",
                        column: x => x.IdOrganizacao,
                        principalTable: "Organizacoes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AssessmentPesquisaQuestoes_AssessmentPesquisas_IdPesquisa",
                        column: x => x.IdPesquisa,
                        principalTable: "AssessmentPesquisas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AssessmentPesquisaQuestoes_CompetenciaQuestoes_IdQuestao",
                        column: x => x.IdQuestao,
                        principalTable: "CompetenciaQuestoes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AssessmentPraticasHistorico",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    IdPraticaAgil = table.Column<Guid>(nullable: false),
                    IdPesquisa = table.Column<Guid>(nullable: false),
                    IdOrganizacao = table.Column<Guid>(nullable: false),
                    PontoTemperatura = table.Column<int>(nullable: false),
                    DataCriacao = table.Column<DateTime>(nullable: false),
                    ResponsavelCriacao = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AssessmentPraticasHistorico", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AssessmentPraticasHistorico_Organizacoes_IdOrganizacao",
                        column: x => x.IdOrganizacao,
                        principalTable: "Organizacoes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AssessmentPraticasHistorico_AssessmentPesquisas_IdPesquisa",
                        column: x => x.IdPesquisa,
                        principalTable: "AssessmentPesquisas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AssessmentPraticasHistorico_PraticasAgeis_IdPraticaAgil",
                        column: x => x.IdPraticaAgil,
                        principalTable: "PraticasAgeis",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AssessmentRespostas",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    IdPesquisaQuestao = table.Column<Guid>(nullable: false),
                    IdPessoa = table.Column<Guid>(nullable: false),
                    IdOrganizacao = table.Column<Guid>(nullable: false),
                    Resposta = table.Column<int>(nullable: true),
                    DataCriacao = table.Column<DateTime>(nullable: false),
                    ResponsavelCriacao = table.Column<Guid>(nullable: false),
                    DataEdicao = table.Column<DateTime>(nullable: true),
                    ResponsavelEdicao = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AssessmentRespostas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AssessmentRespostas_Organizacoes_IdOrganizacao",
                        column: x => x.IdOrganizacao,
                        principalTable: "Organizacoes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AssessmentRespostas_AssessmentPesquisaQuestoes_IdPesquisaQuestao",
                        column: x => x.IdPesquisaQuestao,
                        principalTable: "AssessmentPesquisaQuestoes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AssessmentRespostas_Pessoas_IdPessoa",
                        column: x => x.IdPessoa,
                        principalTable: "Pessoas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AssessmentPesquisaQuestoes_IdOrganizacao",
                table: "AssessmentPesquisaQuestoes",
                column: "IdOrganizacao");

            migrationBuilder.CreateIndex(
                name: "IX_AssessmentPesquisaQuestoes_IdPesquisa",
                table: "AssessmentPesquisaQuestoes",
                column: "IdPesquisa");

            migrationBuilder.CreateIndex(
                name: "IX_AssessmentPesquisaQuestoes_IdQuestao",
                table: "AssessmentPesquisaQuestoes",
                column: "IdQuestao");

            migrationBuilder.CreateIndex(
                name: "IX_AssessmentPesquisas_IdOrganizacao",
                table: "AssessmentPesquisas",
                column: "IdOrganizacao");

            migrationBuilder.CreateIndex(
                name: "IX_AssessmentPesquisas_IdTime",
                table: "AssessmentPesquisas",
                column: "IdTime");

            migrationBuilder.CreateIndex(
                name: "IX_AssessmentPraticasHistorico_IdOrganizacao",
                table: "AssessmentPraticasHistorico",
                column: "IdOrganizacao");

            migrationBuilder.CreateIndex(
                name: "IX_AssessmentPraticasHistorico_IdPesquisa",
                table: "AssessmentPraticasHistorico",
                column: "IdPesquisa");

            migrationBuilder.CreateIndex(
                name: "IX_AssessmentPraticasHistorico_IdPraticaAgil",
                table: "AssessmentPraticasHistorico",
                column: "IdPraticaAgil");

            migrationBuilder.CreateIndex(
                name: "IX_AssessmentRespostas_IdOrganizacao",
                table: "AssessmentRespostas",
                column: "IdOrganizacao");

            migrationBuilder.CreateIndex(
                name: "IX_AssessmentRespostas_IdPesquisaQuestao",
                table: "AssessmentRespostas",
                column: "IdPesquisaQuestao");

            migrationBuilder.CreateIndex(
                name: "IX_AssessmentRespostas_IdPessoa",
                table: "AssessmentRespostas",
                column: "IdPessoa");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AssessmentPraticasHistorico");

            migrationBuilder.DropTable(
                name: "AssessmentRespostas");

            migrationBuilder.DropTable(
                name: "AssessmentPesquisaQuestoes");

            migrationBuilder.DropTable(
                name: "AssessmentPesquisas");
        }
    }
}
