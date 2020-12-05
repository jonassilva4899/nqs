using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Leega.Entity.Migrations
{
    public partial class tabelaCardComentario : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CardComentarios",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    IdColunaCard = table.Column<Guid>(nullable: false),
                    IdPessoa = table.Column<Guid>(nullable: false),
                    Comentario = table.Column<string>(type: "VARCHAR(1000)", nullable: true),
                    DataCriacao = table.Column<DateTime>(nullable: false),
                    ResponsavelCriacao = table.Column<Guid>(nullable: false),
                    DataEdicao = table.Column<DateTime>(nullable: true),
                    ResponsavelEdicao = table.Column<Guid>(nullable: true),
                    IdOrganizacao = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CardComentarios", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CardComentarios_ColunaCards_IdColunaCard",
                        column: x => x.IdColunaCard,
                        principalTable: "ColunaCards",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CardComentarios_Pessoas_IdPessoa",
                        column: x => x.IdPessoa,
                        principalTable: "Pessoas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CardComentarios_IdColunaCard",
                table: "CardComentarios",
                column: "IdColunaCard");

            migrationBuilder.CreateIndex(
                name: "IX_CardComentarios_IdPessoa",
                table: "CardComentarios",
                column: "IdPessoa");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CardComentarios");
        }
    }
}
