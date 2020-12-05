using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Leega.Entity.Migrations
{
    public partial class Throughput : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Throughputs",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    IdTime = table.Column<Guid>(nullable: false),
                    Tipo = table.Column<int>(nullable: false),
                    NomeArquivoPlainlha = table.Column<string>(nullable: true),
                    DataCriacao = table.Column<DateTime>(nullable: false),
                    ResponsavelCriacao = table.Column<Guid>(nullable: false),
                    DataEdicao = table.Column<DateTime>(nullable: true),
                    ResponsavelEdicao = table.Column<Guid>(nullable: true),
                    IdOrganizacao = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Throughputs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Throughputs_Times_IdTime",
                        column: x => x.IdTime,
                        principalTable: "Times",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ThroughputManuais",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    IdThroughput = table.Column<Guid>(nullable: false),
                    Valor = table.Column<int>(nullable: false),
                    DataMes = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ThroughputManuais", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ThroughputManuais_Throughputs_IdThroughput",
                        column: x => x.IdThroughput,
                        principalTable: "Throughputs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ThroughputQuadros",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    IdThroughput = table.Column<Guid>(nullable: false),
                    IdQuadro = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ThroughputQuadros", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ThroughputQuadros_Quadros_IdQuadro",
                        column: x => x.IdQuadro,
                        principalTable: "Quadros",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ThroughputQuadros_Throughputs_IdThroughput",
                        column: x => x.IdThroughput,
                        principalTable: "Throughputs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ThroughputManuais_IdThroughput",
                table: "ThroughputManuais",
                column: "IdThroughput");

            migrationBuilder.CreateIndex(
                name: "IX_ThroughputQuadros_IdQuadro",
                table: "ThroughputQuadros",
                column: "IdQuadro");

            migrationBuilder.CreateIndex(
                name: "IX_ThroughputQuadros_IdThroughput",
                table: "ThroughputQuadros",
                column: "IdThroughput");

            migrationBuilder.CreateIndex(
                name: "IX_Throughputs_IdTime",
                table: "Throughputs",
                column: "IdTime");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ThroughputManuais");

            migrationBuilder.DropTable(
                name: "ThroughputQuadros");

            migrationBuilder.DropTable(
                name: "Throughputs");
        }
    }
}
