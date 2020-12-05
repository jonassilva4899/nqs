using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Leega.Entity.Migrations
{
    public partial class TabelaMelhoriaContinua : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MelhoriasContinuas",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    IdTime = table.Column<Guid>(nullable: false),
                    Acao = table.Column<string>(nullable: true),
                    Descricao = table.Column<string>(nullable: true),
                    Origem = table.Column<int>(nullable: false),
                    Competencia = table.Column<int>(nullable: false),
                    Status = table.Column<int>(nullable: false),
                    DataInclusao = table.Column<DateTime>(nullable: false),
                    IdResponsavelMelhoria = table.Column<Guid>(nullable: false),
                    ResponsavelMelhoriaId = table.Column<Guid>(nullable: true),
                    DataCriacao = table.Column<DateTime>(nullable: false),
                    ResponsavelCriacao = table.Column<Guid>(nullable: false),
                    DataEdicao = table.Column<DateTime>(nullable: false),
                    ResponsavelEdicao = table.Column<Guid>(nullable: false),
                    IdOrganizacao = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MelhoriasContinuas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MelhoriasContinuas_Times_IdTime",
                        column: x => x.IdTime,
                        principalTable: "Times",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MelhoriasContinuas_Pessoas_ResponsavelMelhoriaId",
                        column: x => x.ResponsavelMelhoriaId,
                        principalTable: "Pessoas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MelhoriasContinuas_IdTime",
                table: "MelhoriasContinuas",
                column: "IdTime");

            migrationBuilder.CreateIndex(
                name: "IX_MelhoriasContinuas_ResponsavelMelhoriaId",
                table: "MelhoriasContinuas",
                column: "ResponsavelMelhoriaId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MelhoriasContinuas");
        }
    }
}
