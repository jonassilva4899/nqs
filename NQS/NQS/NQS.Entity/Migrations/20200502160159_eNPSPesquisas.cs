using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Leega.Entity.Migrations
{
    public partial class eNPSPesquisas : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "EnpsPerguntas",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    IdOrganizacao = table.Column<Guid>(nullable: false),
                    Texto = table.Column<string>(nullable: true),
                    DataCriacao = table.Column<DateTime>(nullable: false),
                    ResponsavelCriacao = table.Column<Guid>(nullable: false),
                    DataEdicao = table.Column<DateTime>(nullable: true),
                    ResponsavelEdicao = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EnpsPerguntas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EnpsPerguntas_Organizacoes_IdOrganizacao",
                        column: x => x.IdOrganizacao,
                        principalTable: "Organizacoes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EnpsPesquisas",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    IdOrganizacao = table.Column<Guid>(nullable: false),
                    Descricao = table.Column<string>(nullable: true),
                    DataCriacao = table.Column<DateTime>(nullable: false),
                    ResponsavelCriacao = table.Column<Guid>(nullable: false),
                    DataEdicao = table.Column<DateTime>(nullable: true),
                    ResponsavelEdicao = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EnpsPesquisas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EnpsPesquisas_Organizacoes_IdOrganizacao",
                        column: x => x.IdOrganizacao,
                        principalTable: "Organizacoes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EnpsPesquisaPergunta",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    IdPesquisa = table.Column<Guid>(nullable: false),
                    IdPergunta = table.Column<Guid>(nullable: false),
                    Ordem = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EnpsPesquisaPergunta", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EnpsPesquisaPergunta_EnpsPerguntas_IdPergunta",
                        column: x => x.IdPergunta,
                        principalTable: "EnpsPerguntas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_EnpsPesquisaPergunta_EnpsPesquisas_IdPesquisa",
                        column: x => x.IdPesquisa,
                        principalTable: "EnpsPesquisas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "EnpsResposta",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    IdPesquisaPergunta = table.Column<Guid>(nullable: false),
                    IdPessoa = table.Column<Guid>(nullable: false),
                    IdOrganizacao = table.Column<Guid>(nullable: false),
                    Resposta = table.Column<int>(nullable: false),
                    DataCriacao = table.Column<DateTime>(nullable: false),
                    ResponsavelCriacao = table.Column<Guid>(nullable: false),
                    DataEdicao = table.Column<DateTime>(nullable: true),
                    ResponsavelEdicao = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EnpsResposta", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EnpsResposta_Organizacoes_IdOrganizacao",
                        column: x => x.IdOrganizacao,
                        principalTable: "Organizacoes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EnpsResposta_EnpsPesquisaPergunta_IdPesquisaPergunta",
                        column: x => x.IdPesquisaPergunta,
                        principalTable: "EnpsPesquisaPergunta",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EnpsResposta_Pessoas_IdPessoa",
                        column: x => x.IdPessoa,
                        principalTable: "Pessoas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_EnpsPerguntas_IdOrganizacao",
                table: "EnpsPerguntas",
                column: "IdOrganizacao");

            migrationBuilder.CreateIndex(
                name: "IX_EnpsPesquisaPergunta_IdPergunta",
                table: "EnpsPesquisaPergunta",
                column: "IdPergunta");

            migrationBuilder.CreateIndex(
                name: "IX_EnpsPesquisaPergunta_IdPesquisa",
                table: "EnpsPesquisaPergunta",
                column: "IdPesquisa");

            migrationBuilder.CreateIndex(
                name: "IX_EnpsPesquisas_IdOrganizacao",
                table: "EnpsPesquisas",
                column: "IdOrganizacao");

            migrationBuilder.CreateIndex(
                name: "IX_EnpsResposta_IdOrganizacao",
                table: "EnpsResposta",
                column: "IdOrganizacao");

            migrationBuilder.CreateIndex(
                name: "IX_EnpsResposta_IdPesquisaPergunta",
                table: "EnpsResposta",
                column: "IdPesquisaPergunta");

            migrationBuilder.CreateIndex(
                name: "IX_EnpsResposta_IdPessoa",
                table: "EnpsResposta",
                column: "IdPessoa");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EnpsResposta");

            migrationBuilder.DropTable(
                name: "EnpsPesquisaPergunta");

            migrationBuilder.DropTable(
                name: "EnpsPerguntas");

            migrationBuilder.DropTable(
                name: "EnpsPesquisas");
        }
    }
}
