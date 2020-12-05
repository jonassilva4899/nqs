using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Leega.Entity.Migrations
{
    public partial class Leadtime : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Leadtimes",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    IdTime = table.Column<Guid>(nullable: false),
                    Tipo = table.Column<int>(nullable: false),
                    UrlPlanilha = table.Column<string>(nullable: true),
                    DataCriacao = table.Column<DateTime>(nullable: false),
                    ResponsavelCriacao = table.Column<Guid>(nullable: false),
                    DataEdicao = table.Column<DateTime>(nullable: true),
                    ResponsavelEdicao = table.Column<Guid>(nullable: true),
                    IdOrganizacao = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Leadtimes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Leadtimes_Times_IdTime",
                        column: x => x.IdTime,
                        principalTable: "Times",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "LeadtimeManuais",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    IdLeadtime = table.Column<Guid>(nullable: false),
                    Valor = table.Column<int>(nullable: false),
                    DataMes = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LeadtimeManuais", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LeadtimeManuais_Leadtimes_IdLeadtime",
                        column: x => x.IdLeadtime,
                        principalTable: "Leadtimes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "LeadtimeQuadros",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    IdLeadtime = table.Column<Guid>(nullable: false),
                    IdQuadro = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LeadtimeQuadros", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LeadtimeQuadros_Leadtimes_IdLeadtime",
                        column: x => x.IdLeadtime,
                        principalTable: "Leadtimes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LeadtimeQuadros_Quadros_IdQuadro",
                        column: x => x.IdQuadro,
                        principalTable: "Quadros",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_LeadtimeManuais_IdLeadtime",
                table: "LeadtimeManuais",
                column: "IdLeadtime");

            migrationBuilder.CreateIndex(
                name: "IX_LeadtimeQuadros_IdLeadtime",
                table: "LeadtimeQuadros",
                column: "IdLeadtime");

            migrationBuilder.CreateIndex(
                name: "IX_LeadtimeQuadros_IdQuadro",
                table: "LeadtimeQuadros",
                column: "IdQuadro");

            migrationBuilder.CreateIndex(
                name: "IX_Leadtimes_IdTime",
                table: "Leadtimes",
                column: "IdTime");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LeadtimeManuais");

            migrationBuilder.DropTable(
                name: "LeadtimeQuadros");

            migrationBuilder.DropTable(
                name: "Leadtimes");
        }
    }
}
