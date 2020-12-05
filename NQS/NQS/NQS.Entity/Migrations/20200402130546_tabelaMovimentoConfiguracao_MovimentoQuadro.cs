using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Leega.Entity.Migrations
{
    public partial class tabelaMovimentoConfiguracao_MovimentoQuadro : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MovimentoConfiguracoes",
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
                    table.PrimaryKey("PK_MovimentoConfiguracoes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MovimentoConfiguracoes_Times_IdTime",
                        column: x => x.IdTime,
                        principalTable: "Times",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MovimentoQuadros",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    IdMovimentoConfiguracao = table.Column<Guid>(nullable: false),
                    IdQuadro = table.Column<Guid>(nullable: false),
                    DataCriacao = table.Column<DateTime>(nullable: false),
                    ResponsavelCriacao = table.Column<Guid>(nullable: false),
                    IdOrganizacao = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MovimentoQuadros", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MovimentoQuadros_MovimentoConfiguracoes_IdMovimentoConfiguracao",
                        column: x => x.IdMovimentoConfiguracao,
                        principalTable: "MovimentoConfiguracoes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MovimentoQuadros_Quadros_IdQuadro",
                        column: x => x.IdQuadro,
                        principalTable: "Quadros",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MovimentoConfiguracoes_IdTime",
                table: "MovimentoConfiguracoes",
                column: "IdTime",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_MovimentoQuadros_IdMovimentoConfiguracao",
                table: "MovimentoQuadros",
                column: "IdMovimentoConfiguracao");

            migrationBuilder.CreateIndex(
                name: "IX_MovimentoQuadros_IdQuadro",
                table: "MovimentoQuadros",
                column: "IdQuadro",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MovimentoQuadros");

            migrationBuilder.DropTable(
                name: "MovimentoConfiguracoes");
        }
    }
}
