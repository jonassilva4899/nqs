using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Leega.Entity.Migrations
{
    public partial class TabelaAcao : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "AcaoId",
                table: "Pessoas",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "AcaoId1",
                table: "Pessoas",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Acao",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    NomeAcao = table.Column<string>(type: "VARCHAR(100)", nullable: true),
                    DetalheAcao = table.Column<string>(type: "VARCHAR(MAX)", nullable: true),
                    Data = table.Column<DateTime>(nullable: false),
                    IdPessoaCriacao = table.Column<Guid>(nullable: false),
                    IdResponsavel = table.Column<Guid>(nullable: false),
                    Status = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Acao", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Pessoas_AcaoId",
                table: "Pessoas",
                column: "AcaoId");

            migrationBuilder.CreateIndex(
                name: "IX_Pessoas_AcaoId1",
                table: "Pessoas",
                column: "AcaoId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Pessoas_Acao_AcaoId",
                table: "Pessoas",
                column: "AcaoId",
                principalTable: "Acao",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Pessoas_Acao_AcaoId1",
                table: "Pessoas",
                column: "AcaoId1",
                principalTable: "Acao",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pessoas_Acao_AcaoId",
                table: "Pessoas");

            migrationBuilder.DropForeignKey(
                name: "FK_Pessoas_Acao_AcaoId1",
                table: "Pessoas");

            migrationBuilder.DropTable(
                name: "Acao");

            migrationBuilder.DropIndex(
                name: "IX_Pessoas_AcaoId",
                table: "Pessoas");

            migrationBuilder.DropIndex(
                name: "IX_Pessoas_AcaoId1",
                table: "Pessoas");

            migrationBuilder.DropColumn(
                name: "AcaoId",
                table: "Pessoas");

            migrationBuilder.DropColumn(
                name: "AcaoId1",
                table: "Pessoas");
        }
    }
}
