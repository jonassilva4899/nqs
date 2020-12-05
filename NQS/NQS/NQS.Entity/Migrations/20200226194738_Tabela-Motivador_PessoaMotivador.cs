using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Leega.Entity.Migrations
{
    public partial class TabelaMotivador_PessoaMotivador : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Motivadores",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Nome = table.Column<string>(type: "VARCHAR(30)", nullable: true),
                    Foto = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Motivadores", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PessoaMotivadores",
                columns: table => new
                {
                    IdPessoa = table.Column<Guid>(nullable: false),
                    IdMotivador = table.Column<Guid>(nullable: false),
                    Indice = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PessoaMotivadores", x => new { x.IdPessoa, x.IdMotivador });
                    table.ForeignKey(
                        name: "FK_PessoaMotivadores_Motivadores_IdMotivador",
                        column: x => x.IdMotivador,
                        principalTable: "Motivadores",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PessoaMotivadores_Pessoas_IdPessoa",
                        column: x => x.IdPessoa,
                        principalTable: "Pessoas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PessoaMotivadores_IdMotivador",
                table: "PessoaMotivadores",
                column: "IdMotivador");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PessoaMotivadores");

            migrationBuilder.DropTable(
                name: "Motivadores");
        }
    }
}
