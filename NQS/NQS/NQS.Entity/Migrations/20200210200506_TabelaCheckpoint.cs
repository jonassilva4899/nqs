using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Leega.Entity.Migrations
{
    public partial class TabelaCheckpoint : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Checkpoints",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    IdPessoa = table.Column<Guid>(nullable: false),
                    IdAnalista = table.Column<Guid>(nullable: false),
                    DataAgendamento = table.Column<DateTime>(nullable: false),
                    DataRealizacao = table.Column<DateTime>(nullable: false),
                    SentimentoColaborador = table.Column<int>(nullable: false),
                    SentimentoRhAgil = table.Column<int>(nullable: false),
                    Observacoes = table.Column<string>(type: "VARCHAR(1000)", nullable: true),
                    DataCriacao = table.Column<DateTime>(nullable: false),
                    ResponsavelCriacao = table.Column<Guid>(nullable: false),
                    DataEdicao = table.Column<DateTime>(nullable: false),
                    ResponsavelEdicao = table.Column<Guid>(nullable: false),
                    IdOrganizacao = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Checkpoints", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Checkpoints_Pessoas_IdAnalista",
                        column: x => x.IdAnalista,
                        principalTable: "Pessoas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Checkpoints_Pessoas_IdPessoa",
                        column: x => x.IdPessoa,
                        principalTable: "Pessoas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Checkpoints_IdAnalista",
                table: "Checkpoints",
                column: "IdAnalista");

            migrationBuilder.CreateIndex(
                name: "IX_Checkpoints_IdPessoa",
                table: "Checkpoints",
                column: "IdPessoa");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Checkpoints");
        }
    }
}
