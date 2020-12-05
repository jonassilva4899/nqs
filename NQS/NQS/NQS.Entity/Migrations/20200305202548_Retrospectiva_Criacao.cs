using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Leega.Entity.Migrations
{
    public partial class Retrospectiva_Criacao : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Retrospectiva",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    IdTime = table.Column<Guid>(nullable: false),
                    IdResponsavelRegistro = table.Column<Guid>(nullable: false),
                    DataHoraRegistro = table.Column<DateTime>(nullable: false),
                    TecnicaUtilizada = table.Column<string>(type: "VARCHAR(30)", nullable: true),
                    Observacao = table.Column<string>(type: "VARCHAR(1000)", nullable: true),
                    DataCriacao = table.Column<DateTime>(nullable: false),
                    ResponsavelCriacao = table.Column<Guid>(nullable: false),
                    DataEdicao = table.Column<DateTime>(nullable: true),
                    ResponsavelEdicao = table.Column<Guid>(nullable: false),
                    IdOrganizacao = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Retrospectiva", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Retrospectiva_Pessoas_IdResponsavelRegistro",
                        column: x => x.IdResponsavelRegistro,
                        principalTable: "Pessoas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Retrospectiva_Times_IdTime",
                        column: x => x.IdTime,
                        principalTable: "Times",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RetrospectivaConfiguracao",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    IdTime = table.Column<Guid>(nullable: false),
                    Periodicidade = table.Column<string>(type: "VARCHAR(30)", nullable: true),
                    DataPrecursora = table.Column<DateTime>(nullable: false),
                    HorarioRetrospectiva = table.Column<string>(type: "VARCHAR(5)", nullable: true),
                    DataCriacao = table.Column<DateTime>(nullable: false),
                    ResponsavelCriacao = table.Column<Guid>(nullable: false),
                    DataEdicao = table.Column<DateTime>(nullable: true),
                    ResponsavelEdicao = table.Column<Guid>(nullable: false),
                    IdOrganizacao = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RetrospectivaConfiguracao", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RetrospectivaConfiguracao_Times_IdTime",
                        column: x => x.IdTime,
                        principalTable: "Times",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Retrospectiva_IdResponsavelRegistro",
                table: "Retrospectiva",
                column: "IdResponsavelRegistro");

            migrationBuilder.CreateIndex(
                name: "IX_Retrospectiva_IdTime",
                table: "Retrospectiva",
                column: "IdTime");

            migrationBuilder.CreateIndex(
                name: "IX_RetrospectivaConfiguracao_IdTime",
                table: "RetrospectivaConfiguracao",
                column: "IdTime",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Retrospectiva");

            migrationBuilder.DropTable(
                name: "RetrospectivaConfiguracao");
        }
    }
}
