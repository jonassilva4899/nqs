using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Leega.Entity.Migrations
{
    public partial class tabelasReview_ReviewConfiguracao : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ReviewConfiguracoes",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    IdTime = table.Column<Guid>(nullable: false),
                    Periodicidade = table.Column<int>(nullable: false),
                    DataPrecursora = table.Column<DateTime>(nullable: false),
                    HorarioReview = table.Column<string>(type: "VARCHAR(5)", nullable: true),
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
                    table.PrimaryKey("PK_ReviewConfiguracoes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ReviewConfiguracoes_Times_IdTime",
                        column: x => x.IdTime,
                        principalTable: "Times",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Reviews",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    IdTime = table.Column<Guid>(nullable: false),
                    IdResponsavelRegistro = table.Column<Guid>(nullable: false),
                    DataHoraRegistro = table.Column<DateTime>(nullable: false),
                    IdPlanning = table.Column<Guid>(nullable: false),
                    PorcentagemEntrega = table.Column<int>(nullable: false),
                    Observacao = table.Column<string>(type: "VARCHAR(2000)", nullable: true),
                    DataCriacao = table.Column<DateTime>(nullable: false),
                    ResponsavelCriacao = table.Column<Guid>(nullable: false),
                    DataEdicao = table.Column<DateTime>(nullable: true),
                    ResponsavelEdicao = table.Column<Guid>(nullable: true),
                    IdOrganizacao = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reviews", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Reviews_Plannings_IdPlanning",
                        column: x => x.IdPlanning,
                        principalTable: "Plannings",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Reviews_Pessoas_IdResponsavelRegistro",
                        column: x => x.IdResponsavelRegistro,
                        principalTable: "Pessoas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Reviews_Times_IdTime",
                        column: x => x.IdTime,
                        principalTable: "Times",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ReviewConfiguracoes_IdTime",
                table: "ReviewConfiguracoes",
                column: "IdTime",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Reviews_IdPlanning",
                table: "Reviews",
                column: "IdPlanning",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Reviews_IdResponsavelRegistro",
                table: "Reviews",
                column: "IdResponsavelRegistro");

            migrationBuilder.CreateIndex(
                name: "IX_Reviews_IdTime",
                table: "Reviews",
                column: "IdTime");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ReviewConfiguracoes");

            migrationBuilder.DropTable(
                name: "Reviews");
        }
    }
}
