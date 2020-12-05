using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Leega.Entity.Migrations
{
    public partial class Tabela_SentimentosPessoas : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SentimentosPessoas",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    IdPessoa = table.Column<Guid>(nullable: false),
                    Sentimento = table.Column<int>(nullable: false),
                    DataRealizacao = table.Column<DateTime>(nullable: false),
                    DataCriacao = table.Column<DateTime>(nullable: false),
                    ResponsavelCriacao = table.Column<Guid>(nullable: false),
                    DataEdicao = table.Column<DateTime>(nullable: true),
                    ResponsavelEdicao = table.Column<Guid>(nullable: true),
                    IdOrganizacao = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SentimentosPessoas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SentimentosPessoas_Pessoas_IdPessoa",
                        column: x => x.IdPessoa,
                        principalTable: "Pessoas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SentimentosPessoas_IdPessoa",
                table: "SentimentosPessoas",
                column: "IdPessoa");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SentimentosPessoas");
        }
    }
}
