using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Leega.Entity.Migrations
{
    public partial class addTabelas_AssessmentPesquisaCompetencias_AssessmentRespostasCompetencias : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AssessmentPesquisaQuestoes_AssessmentPesquisas_IdPesquisa",
                table: "AssessmentPesquisaQuestoes");

            migrationBuilder.DropTable(
                name: "AssessmentRespostas");

            migrationBuilder.DropIndex(
                name: "IX_AssessmentPesquisaQuestoes_IdPesquisa",
                table: "AssessmentPesquisaQuestoes");

            migrationBuilder.DropColumn(
                name: "IdPesquisa",
                table: "AssessmentPesquisaQuestoes");

            migrationBuilder.AddColumn<Guid>(
                name: "IdPesquisaCompetencia",
                table: "AssessmentPesquisaQuestoes",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateTable(
                name: "AssessmentPesquisaCompetencias",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    IdPesquisa = table.Column<Guid>(nullable: false),
                    IdCompetencia = table.Column<Guid>(nullable: false),
                    DataCriacao = table.Column<DateTime>(nullable: false),
                    ResponsavelCriacao = table.Column<Guid>(nullable: false),
                    IdOrganizacao = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AssessmentPesquisaCompetencias", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AssessmentPesquisaCompetencias_Competencias_IdCompetencia",
                        column: x => x.IdCompetencia,
                        principalTable: "Competencias",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AssessmentPesquisaCompetencias_Organizacoes_IdOrganizacao",
                        column: x => x.IdOrganizacao,
                        principalTable: "Organizacoes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AssessmentPesquisaCompetencias_AssessmentPesquisas_IdPesquisa",
                        column: x => x.IdPesquisa,
                        principalTable: "AssessmentPesquisas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AssessmentRespostasQuestoes",
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
                    table.PrimaryKey("PK_AssessmentRespostasQuestoes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AssessmentRespostasQuestoes_Organizacoes_IdOrganizacao",
                        column: x => x.IdOrganizacao,
                        principalTable: "Organizacoes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AssessmentRespostasQuestoes_AssessmentPesquisaQuestoes_IdPesquisaQuestao",
                        column: x => x.IdPesquisaQuestao,
                        principalTable: "AssessmentPesquisaQuestoes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AssessmentRespostasQuestoes_Pessoas_IdPessoa",
                        column: x => x.IdPessoa,
                        principalTable: "Pessoas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AssessmentRespostasCompetencias",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    IdPesquisaCompetencia = table.Column<Guid>(nullable: false),
                    IdPessoa = table.Column<Guid>(nullable: false),
                    IdOrganizacao = table.Column<Guid>(nullable: false),
                    Observacao = table.Column<string>(type: "VARCHAR(2000)", nullable: true),
                    DataCriacao = table.Column<DateTime>(nullable: false),
                    ResponsavelCriacao = table.Column<Guid>(nullable: false),
                    DataEdicao = table.Column<DateTime>(nullable: true),
                    ResponsavelEdicao = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AssessmentRespostasCompetencias", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AssessmentRespostasCompetencias_Organizacoes_IdOrganizacao",
                        column: x => x.IdOrganizacao,
                        principalTable: "Organizacoes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AssessmentRespostasCompetencias_AssessmentPesquisaCompetencias_IdPesquisaCompetencia",
                        column: x => x.IdPesquisaCompetencia,
                        principalTable: "AssessmentPesquisaCompetencias",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AssessmentRespostasCompetencias_Pessoas_IdPessoa",
                        column: x => x.IdPessoa,
                        principalTable: "Pessoas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AssessmentPesquisaQuestoes_IdPesquisaCompetencia",
                table: "AssessmentPesquisaQuestoes",
                column: "IdPesquisaCompetencia");

            migrationBuilder.CreateIndex(
                name: "IX_AssessmentPesquisaCompetencias_IdCompetencia",
                table: "AssessmentPesquisaCompetencias",
                column: "IdCompetencia");

            migrationBuilder.CreateIndex(
                name: "IX_AssessmentPesquisaCompetencias_IdOrganizacao",
                table: "AssessmentPesquisaCompetencias",
                column: "IdOrganizacao");

            migrationBuilder.CreateIndex(
                name: "IX_AssessmentPesquisaCompetencias_IdPesquisa",
                table: "AssessmentPesquisaCompetencias",
                column: "IdPesquisa");

            migrationBuilder.CreateIndex(
                name: "IX_AssessmentRespostasCompetencias_IdOrganizacao",
                table: "AssessmentRespostasCompetencias",
                column: "IdOrganizacao");

            migrationBuilder.CreateIndex(
                name: "IX_AssessmentRespostasCompetencias_IdPesquisaCompetencia",
                table: "AssessmentRespostasCompetencias",
                column: "IdPesquisaCompetencia");

            migrationBuilder.CreateIndex(
                name: "IX_AssessmentRespostasCompetencias_IdPessoa",
                table: "AssessmentRespostasCompetencias",
                column: "IdPessoa");

            migrationBuilder.CreateIndex(
                name: "IX_AssessmentRespostasQuestoes_IdOrganizacao",
                table: "AssessmentRespostasQuestoes",
                column: "IdOrganizacao");

            migrationBuilder.CreateIndex(
                name: "IX_AssessmentRespostasQuestoes_IdPesquisaQuestao",
                table: "AssessmentRespostasQuestoes",
                column: "IdPesquisaQuestao");

            migrationBuilder.CreateIndex(
                name: "IX_AssessmentRespostasQuestoes_IdPessoa",
                table: "AssessmentRespostasQuestoes",
                column: "IdPessoa");

            migrationBuilder.AddForeignKey(
                name: "FK_AssessmentPesquisaQuestoes_AssessmentPesquisaCompetencias_IdPesquisaCompetencia",
                table: "AssessmentPesquisaQuestoes",
                column: "IdPesquisaCompetencia",
                principalTable: "AssessmentPesquisaCompetencias",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AssessmentPesquisaQuestoes_AssessmentPesquisaCompetencias_IdPesquisaCompetencia",
                table: "AssessmentPesquisaQuestoes");

            migrationBuilder.DropTable(
                name: "AssessmentRespostasCompetencias");

            migrationBuilder.DropTable(
                name: "AssessmentRespostasQuestoes");

            migrationBuilder.DropTable(
                name: "AssessmentPesquisaCompetencias");

            migrationBuilder.DropIndex(
                name: "IX_AssessmentPesquisaQuestoes_IdPesquisaCompetencia",
                table: "AssessmentPesquisaQuestoes");

            migrationBuilder.DropColumn(
                name: "IdPesquisaCompetencia",
                table: "AssessmentPesquisaQuestoes");

            migrationBuilder.AddColumn<Guid>(
                name: "IdPesquisa",
                table: "AssessmentPesquisaQuestoes",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateTable(
                name: "AssessmentRespostas",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DataCriacao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DataEdicao = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IdOrganizacao = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IdPesquisaQuestao = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IdPessoa = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ResponsavelCriacao = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ResponsavelEdicao = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Resposta = table.Column<int>(type: "int", nullable: true)
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
                name: "IX_AssessmentPesquisaQuestoes_IdPesquisa",
                table: "AssessmentPesquisaQuestoes",
                column: "IdPesquisa");

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

            migrationBuilder.AddForeignKey(
                name: "FK_AssessmentPesquisaQuestoes_AssessmentPesquisas_IdPesquisa",
                table: "AssessmentPesquisaQuestoes",
                column: "IdPesquisa",
                principalTable: "AssessmentPesquisas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
