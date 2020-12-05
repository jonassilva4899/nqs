using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Leega.Entity.Migrations
{
    public partial class tabelasCompetenciaQuestao_CompetenciaQuestaoOpcao : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CompetenciaQuestoes",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    IdCompetencia = table.Column<Guid>(nullable: false),
                    TituloQuestao = table.Column<string>(type: "VARCHAR(1000)", nullable: true),
                    DataCriacao = table.Column<DateTime>(nullable: false),
                    ResponsavelCriacao = table.Column<Guid>(nullable: false),
                    DataEdicao = table.Column<DateTime>(nullable: true),
                    ResponsavelEdicao = table.Column<Guid>(nullable: true),
                    IdOrganizacao = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CompetenciaQuestoes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CompetenciaQuestoes_Competencias_IdCompetencia",
                        column: x => x.IdCompetencia,
                        principalTable: "Competencias",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CompetenciaQuestaoOpcoes",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    IdCompetenciaQuestao = table.Column<Guid>(nullable: false),
                    Descricao = table.Column<string>(type: "VARCHAR(1000)", nullable: true),
                    TemperaturaTermometro = table.Column<int>(nullable: false),
                    DataCriacao = table.Column<DateTime>(nullable: false),
                    ResponsavelCriacao = table.Column<Guid>(nullable: false),
                    DataEdicao = table.Column<DateTime>(nullable: true),
                    ResponsavelEdicao = table.Column<Guid>(nullable: true),
                    IdOrganizacao = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CompetenciaQuestaoOpcoes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CompetenciaQuestaoOpcoes_CompetenciaQuestoes_IdCompetenciaQuestao",
                        column: x => x.IdCompetenciaQuestao,
                        principalTable: "CompetenciaQuestoes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CompetenciaQuestaoOpcoes_IdCompetenciaQuestao",
                table: "CompetenciaQuestaoOpcoes",
                column: "IdCompetenciaQuestao");

            migrationBuilder.CreateIndex(
                name: "IX_CompetenciaQuestoes_IdCompetencia",
                table: "CompetenciaQuestoes",
                column: "IdCompetencia");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CompetenciaQuestaoOpcoes");

            migrationBuilder.DropTable(
                name: "CompetenciaQuestoes");
        }
    }
}
