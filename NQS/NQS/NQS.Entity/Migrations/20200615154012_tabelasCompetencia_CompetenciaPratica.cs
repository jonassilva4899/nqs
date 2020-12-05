using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Leega.Entity.Migrations
{
    public partial class tabelasCompetencia_CompetenciaPratica : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Competencias",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Nome = table.Column<string>(type: "VARCHAR(100)", nullable: true),
                    Descricao = table.Column<string>(type: "VARCHAR(3000)", nullable: true),
                    DataCriacao = table.Column<DateTime>(nullable: false),
                    ResponsavelCriacao = table.Column<Guid>(nullable: false),
                    DataEdicao = table.Column<DateTime>(nullable: true),
                    ResponsavelEdicao = table.Column<Guid>(nullable: true),
                    IdOrganizacao = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Competencias", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CompetenciaPraticas",
                columns: table => new
                {
                    IdCompetencia = table.Column<Guid>(nullable: false),
                    IdPraticaAgil = table.Column<Guid>(nullable: false),
                    DataCriacao = table.Column<DateTime>(nullable: false),
                    ResponsavelCriacao = table.Column<Guid>(nullable: false),
                    IdOrganizacao = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CompetenciaPraticas", x => new { x.IdCompetencia, x.IdPraticaAgil });
                    table.ForeignKey(
                        name: "FK_CompetenciaPraticas_Competencias_IdCompetencia",
                        column: x => x.IdCompetencia,
                        principalTable: "Competencias",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CompetenciaPraticas_PraticasAgeis_IdPraticaAgil",
                        column: x => x.IdPraticaAgil,
                        principalTable: "PraticasAgeis",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CompetenciaPraticas_IdPraticaAgil",
                table: "CompetenciaPraticas",
                column: "IdPraticaAgil");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CompetenciaPraticas");

            migrationBuilder.DropTable(
                name: "Competencias");
        }
    }
}
