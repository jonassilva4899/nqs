using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Leega.Entity.Migrations
{
    public partial class TabelaPortfolioAcao : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PortfolioAcoes",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    IdPortfolioMeta = table.Column<Guid>(nullable: false),
                    Nome = table.Column<string>(type: "VARCHAR(250)", nullable: true),
                    Descricao = table.Column<string>(type: "VARCHAR(5000)", nullable: true),
                    IdPessoaResponsavel = table.Column<Guid>(nullable: false),
                    Status = table.Column<int>(nullable: false),
                    DataCriacao = table.Column<DateTime>(nullable: false),
                    ResponsavelCriacao = table.Column<Guid>(nullable: false),
                    DataEdicao = table.Column<DateTime>(nullable: true),
                    ResponsavelEdicao = table.Column<Guid>(nullable: true),
                    IdOrganizacao = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PortfolioAcoes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PortfolioAcoes_Pessoas_IdPessoaResponsavel",
                        column: x => x.IdPessoaResponsavel,
                        principalTable: "Pessoas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PortfolioAcoes_PortfolioMetas_IdPortfolioMeta",
                        column: x => x.IdPortfolioMeta,
                        principalTable: "PortfolioMetas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PortfolioAcoes_IdPessoaResponsavel",
                table: "PortfolioAcoes",
                column: "IdPessoaResponsavel");

            migrationBuilder.CreateIndex(
                name: "IX_PortfolioAcoes_IdPortfolioMeta",
                table: "PortfolioAcoes",
                column: "IdPortfolioMeta");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PortfolioAcoes");
        }
    }
}
