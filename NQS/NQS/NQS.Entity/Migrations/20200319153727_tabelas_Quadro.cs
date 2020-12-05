using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Leega.Entity.Migrations
{
    public partial class tabelas_Quadro : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Etiquetas",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Nome = table.Column<string>(type: "VARCHAR(50)", nullable: true),
                    DataCriacao = table.Column<DateTime>(nullable: false),
                    ResponsavelCriacao = table.Column<Guid>(nullable: false),
                    IdOrganizacao = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Etiquetas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Iteracoes",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Nome = table.Column<string>(type: "VARCHAR(50)", nullable: true),
                    DataCriacao = table.Column<DateTime>(nullable: false),
                    ResponsavelCriacao = table.Column<Guid>(nullable: false),
                    IdOrganizacao = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Iteracoes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Quadros",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    IdTime = table.Column<Guid>(nullable: false),
                    TimeId = table.Column<Guid>(nullable: true),
                    Nome = table.Column<string>(type: "VARCHAR(50)", nullable: true),
                    DataCriacao = table.Column<DateTime>(nullable: false),
                    ResponsavelCriacao = table.Column<Guid>(nullable: false),
                    DataEdicao = table.Column<DateTime>(nullable: true),
                    ResponsavelEdicao = table.Column<Guid>(nullable: true),
                    IdOrganizacao = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Quadros", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Quadros_Times_TimeId",
                        column: x => x.TimeId,
                        principalTable: "Times",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "QuadroColunas",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    IdQuadro = table.Column<Guid>(nullable: false),
                    Nome = table.Column<string>(type: "VARCHAR(50)", nullable: true),
                    Indice = table.Column<int>(nullable: false),
                    DataCriacao = table.Column<DateTime>(nullable: false),
                    ResponsavelCriacao = table.Column<Guid>(nullable: false),
                    DataEdicao = table.Column<DateTime>(nullable: true),
                    ResponsavelEdicao = table.Column<Guid>(nullable: true),
                    IdOrganizacao = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QuadroColunas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_QuadroColunas_Quadros_IdQuadro",
                        column: x => x.IdQuadro,
                        principalTable: "Quadros",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ColunaCards",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    IdQuadroColuna = table.Column<Guid>(nullable: false),
                    Nome = table.Column<string>(type: "VARCHAR(50)", nullable: true),
                    Descricao = table.Column<string>(type: "VARCHAR(2000)", nullable: true),
                    Indice = table.Column<int>(nullable: false),
                    IdProjeto = table.Column<Guid>(nullable: true),
                    IdIteracao = table.Column<Guid>(nullable: false),
                    Pontuacao = table.Column<int>(nullable: false),
                    DataCriacao = table.Column<DateTime>(nullable: false),
                    ResponsavelCriacao = table.Column<Guid>(nullable: false),
                    DataEdicao = table.Column<DateTime>(nullable: true),
                    ResponsavelEdicao = table.Column<Guid>(nullable: true),
                    IdOrganizacao = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ColunaCards", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ColunaCards_Iteracoes_IdIteracao",
                        column: x => x.IdIteracao,
                        principalTable: "Iteracoes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ColunaCards_Projetos_IdProjeto",
                        column: x => x.IdProjeto,
                        principalTable: "Projetos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ColunaCards_QuadroColunas_IdQuadroColuna",
                        column: x => x.IdQuadroColuna,
                        principalTable: "QuadroColunas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CardEtiquetas",
                columns: table => new
                {
                    IdColunaCard = table.Column<Guid>(nullable: false),
                    IdEtiqueta = table.Column<Guid>(nullable: false),
                    DataCriacao = table.Column<DateTime>(nullable: false),
                    ResponsavelCriacao = table.Column<Guid>(nullable: false),
                    IdOrganizacao = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CardEtiquetas", x => new { x.IdColunaCard, x.IdEtiqueta });
                    table.ForeignKey(
                        name: "FK_CardEtiquetas_ColunaCards_IdColunaCard",
                        column: x => x.IdColunaCard,
                        principalTable: "ColunaCards",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CardEtiquetas_Etiquetas_IdEtiqueta",
                        column: x => x.IdEtiqueta,
                        principalTable: "Etiquetas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CardLogs",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    IdColunaCard = table.Column<Guid>(nullable: false),
                    IdPessoaMoveu = table.Column<Guid>(nullable: false),
                    IdQuadroColuna = table.Column<Guid>(nullable: false),
                    DataMovimentacao = table.Column<DateTime>(nullable: false),
                    DataCriacao = table.Column<DateTime>(nullable: false),
                    ResponsavelCriacao = table.Column<Guid>(nullable: false),
                    IdOrganizacao = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CardLogs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CardLogs_ColunaCards_IdColunaCard",
                        column: x => x.IdColunaCard,
                        principalTable: "ColunaCards",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CardLogs_Pessoas_IdPessoaMoveu",
                        column: x => x.IdPessoaMoveu,
                        principalTable: "Pessoas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CardLogs_QuadroColunas_IdQuadroColuna",
                        column: x => x.IdQuadroColuna,
                        principalTable: "QuadroColunas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ResponsavelCards",
                columns: table => new
                {
                    IdPessoa = table.Column<Guid>(nullable: false),
                    IdColunaCard = table.Column<Guid>(nullable: false),
                    Ativo = table.Column<bool>(nullable: false),
                    DataCriacao = table.Column<DateTime>(nullable: false),
                    ResponsavelCriacao = table.Column<Guid>(nullable: false),
                    DataEdicao = table.Column<DateTime>(nullable: true),
                    ResponsavelEdicao = table.Column<Guid>(nullable: true),
                    IdOrganizacao = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ResponsavelCards", x => new { x.IdPessoa, x.IdColunaCard });
                    table.ForeignKey(
                        name: "FK_ResponsavelCards_ColunaCards_IdColunaCard",
                        column: x => x.IdColunaCard,
                        principalTable: "ColunaCards",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ResponsavelCards_Pessoas_IdPessoa",
                        column: x => x.IdPessoa,
                        principalTable: "Pessoas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CardEtiquetas_IdEtiqueta",
                table: "CardEtiquetas",
                column: "IdEtiqueta");

            migrationBuilder.CreateIndex(
                name: "IX_CardLogs_IdColunaCard",
                table: "CardLogs",
                column: "IdColunaCard");

            migrationBuilder.CreateIndex(
                name: "IX_CardLogs_IdPessoaMoveu",
                table: "CardLogs",
                column: "IdPessoaMoveu");

            migrationBuilder.CreateIndex(
                name: "IX_CardLogs_IdQuadroColuna",
                table: "CardLogs",
                column: "IdQuadroColuna");

            migrationBuilder.CreateIndex(
                name: "IX_ColunaCards_IdIteracao",
                table: "ColunaCards",
                column: "IdIteracao",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ColunaCards_IdProjeto",
                table: "ColunaCards",
                column: "IdProjeto",
                unique: true,
                filter: "[IdProjeto] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_ColunaCards_IdQuadroColuna",
                table: "ColunaCards",
                column: "IdQuadroColuna");

            migrationBuilder.CreateIndex(
                name: "IX_QuadroColunas_IdQuadro",
                table: "QuadroColunas",
                column: "IdQuadro");

            migrationBuilder.CreateIndex(
                name: "IX_Quadros_TimeId",
                table: "Quadros",
                column: "TimeId");

            migrationBuilder.CreateIndex(
                name: "IX_ResponsavelCards_IdColunaCard",
                table: "ResponsavelCards",
                column: "IdColunaCard");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CardEtiquetas");

            migrationBuilder.DropTable(
                name: "CardLogs");

            migrationBuilder.DropTable(
                name: "ResponsavelCards");

            migrationBuilder.DropTable(
                name: "Etiquetas");

            migrationBuilder.DropTable(
                name: "ColunaCards");

            migrationBuilder.DropTable(
                name: "Iteracoes");

            migrationBuilder.DropTable(
                name: "QuadroColunas");

            migrationBuilder.DropTable(
                name: "Quadros");
        }
    }
}
