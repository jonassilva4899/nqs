using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Leega.Entity.Migrations
{
    public partial class tabelasCapacity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CapacityConfiguracoes",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    IdTime = table.Column<Guid>(nullable: false),
                    Tipo = table.Column<int>(nullable: false),
                    CaminhoExcel = table.Column<string>(nullable: true),
                    ValorManual = table.Column<string>(type: "VARCHAR(100)", nullable: true),
                    DataCriacao = table.Column<DateTime>(nullable: false),
                    ResponsavelCriacao = table.Column<Guid>(nullable: false),
                    DataEdicao = table.Column<DateTime>(nullable: true),
                    ResponsavelEdicao = table.Column<Guid>(nullable: true),
                    IdOrganizacao = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CapacityConfiguracoes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CapacityConfiguracoes_Times_IdTime",
                        column: x => x.IdTime,
                        principalTable: "Times",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CapacityQuadros",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    IdCapacityConfiguracao = table.Column<Guid>(nullable: false),
                    IdQuadro = table.Column<Guid>(nullable: false),
                    DataCriacao = table.Column<DateTime>(nullable: false),
                    ResponsavelCriacao = table.Column<Guid>(nullable: false),
                    IdOrganizacao = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CapacityQuadros", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CapacityQuadros_CapacityConfiguracoes_IdCapacityConfiguracao",
                        column: x => x.IdCapacityConfiguracao,
                        principalTable: "CapacityConfiguracoes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CapacityQuadros_Quadros_IdQuadro",
                        column: x => x.IdQuadro,
                        principalTable: "Quadros",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CapacityConfiguracoes_IdTime",
                table: "CapacityConfiguracoes",
                column: "IdTime",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_CapacityQuadros_IdCapacityConfiguracao",
                table: "CapacityQuadros",
                column: "IdCapacityConfiguracao");

            migrationBuilder.CreateIndex(
                name: "IX_CapacityQuadros_IdQuadro",
                table: "CapacityQuadros",
                column: "IdQuadro",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CapacityQuadros");

            migrationBuilder.DropTable(
                name: "CapacityConfiguracoes");
        }
    }
}
