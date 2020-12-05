using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Leega.Entity.Migrations
{
    public partial class TabelaHabilidade_PessoaHabilidade : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Habilidades",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Nome = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Habilidades", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PessoaHabilidades",
                columns: table => new
                {
                    IdPessoa = table.Column<Guid>(nullable: false),
                    IdHabilidade = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PessoaHabilidades", x => new { x.IdPessoa, x.IdHabilidade });
                    table.ForeignKey(
                        name: "FK_PessoaHabilidades_Habilidades_IdHabilidade",
                        column: x => x.IdHabilidade,
                        principalTable: "Habilidades",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PessoaHabilidades_Pessoas_IdPessoa",
                        column: x => x.IdPessoa,
                        principalTable: "Pessoas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PessoaHabilidades_IdHabilidade",
                table: "PessoaHabilidades",
                column: "IdHabilidade");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PessoaHabilidades");

            migrationBuilder.DropTable(
                name: "Habilidades");
        }
    }
}
