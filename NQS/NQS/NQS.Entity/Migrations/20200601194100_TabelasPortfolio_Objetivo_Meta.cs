using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Leega.Entity.Migrations
{
    public partial class TabelasPortfolio_Objetivo_Meta : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PortfolioObjetivos",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Objetivo = table.Column<string>(type: "VARCHAR(500)", nullable: true),
                    Cor = table.Column<string>(type: "VARCHAR(100)", nullable: true),
                    DataCriacao = table.Column<DateTime>(nullable: false),
                    ResponsavelCriacao = table.Column<Guid>(nullable: false),
                    IdOrganizacao = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PortfolioObjetivos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PortfolioMetas",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    IdPortfolioObjetivo = table.Column<Guid>(nullable: false),
                    Meta = table.Column<string>(type: "VARCHAR(500)", nullable: true),
                    Realizado = table.Column<string>(type: "VARCHAR(100)", nullable: true),
                    Periodo = table.Column<string>(type: "VARCHAR(10)", nullable: true),
                    Ativo = table.Column<bool>(nullable: false),
                    DataCriacao = table.Column<DateTime>(nullable: false),
                    ResponsavelCriacao = table.Column<Guid>(nullable: false),
                    DataEdicao = table.Column<DateTime>(nullable: true),
                    ResponsavelEdicao = table.Column<Guid>(nullable: true),
                    IdOrganizacao = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PortfolioMetas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PortfolioMetas_PortfolioObjetivos_IdPortfolioObjetivo",
                        column: x => x.IdPortfolioObjetivo,
                        principalTable: "PortfolioObjetivos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProjetoPortfolioMetas",
                columns: table => new
                {
                    IdProjeto = table.Column<Guid>(nullable: false),
                    IdPortfolioMeta = table.Column<Guid>(nullable: false),
                    DataCriacao = table.Column<DateTime>(nullable: false),
                    ResponsavelCriacao = table.Column<Guid>(nullable: false),
                    IdOrganizacao = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProjetoPortfolioMetas", x => new { x.IdProjeto, x.IdPortfolioMeta });
                    table.ForeignKey(
                        name: "FK_ProjetoPortfolioMetas_PortfolioMetas_IdPortfolioMeta",
                        column: x => x.IdPortfolioMeta,
                        principalTable: "PortfolioMetas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProjetoPortfolioMetas_Projetos_IdProjeto",
                        column: x => x.IdProjeto,
                        principalTable: "Projetos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PortfolioMetas_IdPortfolioObjetivo",
                table: "PortfolioMetas",
                column: "IdPortfolioObjetivo");

            migrationBuilder.CreateIndex(
                name: "IX_ProjetoPortfolioMetas_IdPortfolioMeta",
                table: "ProjetoPortfolioMetas",
                column: "IdPortfolioMeta");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProjetoPortfolioMetas");

            migrationBuilder.DropTable(
                name: "PortfolioMetas");

            migrationBuilder.DropTable(
                name: "PortfolioObjetivos");
        }
    }
}
