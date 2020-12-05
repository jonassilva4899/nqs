using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Leega.Entity.Migrations
{
    public partial class tabelasPlanning : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PlanningConfiguracoes",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    IdTime = table.Column<Guid>(nullable: false),
                    Periodicidade = table.Column<int>(nullable: false),
                    DataPrecursora = table.Column<DateTime>(nullable: false),
                    HorarioPlanning = table.Column<string>(type: "VARCHAR(5)", nullable: true),
                    UltimaData = table.Column<DateTime>(nullable: true),
                    ProximaData = table.Column<DateTime>(nullable: true),
                    DataCriacao = table.Column<DateTime>(nullable: false),
                    ResponsavelCriacao = table.Column<Guid>(nullable: false),
                    DataEdicao = table.Column<DateTime>(nullable: true),
                    ResponsavelEdicao = table.Column<Guid>(nullable: true),
                    IdOrganizacao = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlanningConfiguracoes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PlanningConfiguracoes_Times_IdTime",
                        column: x => x.IdTime,
                        principalTable: "Times",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TecnicasPlannings",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Nome = table.Column<string>(nullable: true),
                    Ativo = table.Column<bool>(nullable: false),
                    DataCriacao = table.Column<DateTime>(nullable: false),
                    ResponsavelCriacao = table.Column<Guid>(nullable: false),
                    DataEdicao = table.Column<DateTime>(nullable: true),
                    ResponsavelEdicao = table.Column<Guid>(nullable: true),
                    IdOrganizacao = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TecnicasPlannings", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Plannings",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    IdTime = table.Column<Guid>(nullable: false),
                    IdResponsavelRegistro = table.Column<Guid>(nullable: false),
                    DataHoraRegistro = table.Column<DateTime>(nullable: true),
                    IdTecnicaUtilizada = table.Column<Guid>(nullable: false),
                    Observacao = table.Column<string>(type: "VARCHAR(2000)", nullable: true),
                    DataCriacao = table.Column<DateTime>(nullable: false),
                    ResponsavelCriacao = table.Column<Guid>(nullable: false),
                    DataEdicao = table.Column<DateTime>(nullable: true),
                    ResponsavelEdicao = table.Column<Guid>(nullable: true),
                    IdOrganizacao = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Plannings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Plannings_Pessoas_IdResponsavelRegistro",
                        column: x => x.IdResponsavelRegistro,
                        principalTable: "Pessoas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Plannings_TecnicasPlannings_IdTecnicaUtilizada",
                        column: x => x.IdTecnicaUtilizada,
                        principalTable: "TecnicasPlannings",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Plannings_Times_IdTime",
                        column: x => x.IdTime,
                        principalTable: "Times",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PlanningConfiguracoes_IdTime",
                table: "PlanningConfiguracoes",
                column: "IdTime",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Plannings_IdResponsavelRegistro",
                table: "Plannings",
                column: "IdResponsavelRegistro");

            migrationBuilder.CreateIndex(
                name: "IX_Plannings_IdTecnicaUtilizada",
                table: "Plannings",
                column: "IdTecnicaUtilizada");

            migrationBuilder.CreateIndex(
                name: "IX_Plannings_IdTime",
                table: "Plannings",
                column: "IdTime");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PlanningConfiguracoes");

            migrationBuilder.DropTable(
                name: "Plannings");

            migrationBuilder.DropTable(
                name: "TecnicasPlannings");
        }
    }
}
