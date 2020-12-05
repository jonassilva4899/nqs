using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Leega.Entity.Migrations
{
    public partial class Tabelas_PraticaAgilPraticaAgilTime : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PraticasAgeis",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Nome = table.Column<string>(type: "VARCHAR(100)", nullable: true),
                    DataCriacao = table.Column<DateTime>(nullable: false),
                    Ativo = table.Column<bool>(nullable: false),
                    Chave = table.Column<string>(type: "VARCHAR(50)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PraticasAgeis", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PraticasAgeisTimes",
                columns: table => new
                {
                    IdPraticaAgil = table.Column<Guid>(nullable: false),
                    IdTime = table.Column<Guid>(nullable: false),
                    Status = table.Column<bool>(nullable: false),
                    DataInicio = table.Column<DateTime>(nullable: false),
                    Engajamento = table.Column<int>(nullable: false),
                    DataCriacao = table.Column<DateTime>(nullable: false),
                    ResponsavelCriacao = table.Column<Guid>(nullable: false),
                    DataEdicao = table.Column<DateTime>(nullable: false),
                    ResponsavelEdicao = table.Column<Guid>(nullable: false),
                    IdOrganizacao = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PraticasAgeisTimes", x => new { x.IdPraticaAgil, x.IdTime });
                    table.ForeignKey(
                        name: "FK_PraticasAgeisTimes_PraticasAgeis_IdPraticaAgil",
                        column: x => x.IdPraticaAgil,
                        principalTable: "PraticasAgeis",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PraticasAgeisTimes_Times_IdTime",
                        column: x => x.IdTime,
                        principalTable: "Times",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PraticasAgeisTimes_IdTime",
                table: "PraticasAgeisTimes",
                column: "IdTime");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PraticasAgeisTimes");

            migrationBuilder.DropTable(
                name: "PraticasAgeis");
        }
    }
}
