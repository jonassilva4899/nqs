using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Leega.Entity.Migrations
{
    public partial class Tabelas_DicasAgileCoach : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categorias",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Nome = table.Column<string>(type: "VARCHAR(100)", nullable: true),
                    DataCriacao = table.Column<DateTime>(nullable: false),
                    ResponsavelCriacao = table.Column<Guid>(nullable: false),
                    IdOrganizacao = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categorias", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DicasAgileCoach",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Tema = table.Column<string>(type: "VARCHAR(100)", nullable: true),
                    Descricao = table.Column<string>(type: "VARCHAR(1000)", nullable: true),
                    DataCriacao = table.Column<DateTime>(nullable: false),
                    ResponsavelCriacao = table.Column<Guid>(nullable: false),
                    DataEdicao = table.Column<DateTime>(nullable: true),
                    ResponsavelEdicao = table.Column<Guid>(nullable: true),
                    IdOrganizacao = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DicasAgileCoach", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DicaAgileCoachCategorias",
                columns: table => new
                {
                    IdDicaAgileCoach = table.Column<Guid>(nullable: false),
                    IdCategoria = table.Column<Guid>(nullable: false),
                    DataCriacao = table.Column<DateTime>(nullable: false),
                    ResponsavelCriacao = table.Column<Guid>(nullable: false),
                    IdOrganizacao = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DicaAgileCoachCategorias", x => new { x.IdDicaAgileCoach, x.IdCategoria });
                    table.ForeignKey(
                        name: "FK_DicaAgileCoachCategorias_Categorias_IdCategoria",
                        column: x => x.IdCategoria,
                        principalTable: "Categorias",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DicaAgileCoachCategorias_DicasAgileCoach_IdDicaAgileCoach",
                        column: x => x.IdDicaAgileCoach,
                        principalTable: "DicasAgileCoach",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TimeDicasAgileCoach",
                columns: table => new
                {
                    IdTime = table.Column<Guid>(nullable: false),
                    IdDicaAgileCoach = table.Column<Guid>(nullable: false),
                    StatusDica = table.Column<int>(nullable: false),
                    DataCriacao = table.Column<DateTime>(nullable: false),
                    ResponsavelCriacao = table.Column<Guid>(nullable: false),
                    DataEdicao = table.Column<DateTime>(nullable: true),
                    ResponsavelEdicao = table.Column<Guid>(nullable: true),
                    IdOrganizacao = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TimeDicasAgileCoach", x => new { x.IdTime, x.IdDicaAgileCoach });
                    table.ForeignKey(
                        name: "FK_TimeDicasAgileCoach_DicasAgileCoach_IdDicaAgileCoach",
                        column: x => x.IdDicaAgileCoach,
                        principalTable: "DicasAgileCoach",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TimeDicasAgileCoach_Times_IdTime",
                        column: x => x.IdTime,
                        principalTable: "Times",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DicaAgileCoachCategorias_IdCategoria",
                table: "DicaAgileCoachCategorias",
                column: "IdCategoria");

            migrationBuilder.CreateIndex(
                name: "IX_TimeDicasAgileCoach_IdDicaAgileCoach",
                table: "TimeDicasAgileCoach",
                column: "IdDicaAgileCoach");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DicaAgileCoachCategorias");

            migrationBuilder.DropTable(
                name: "TimeDicasAgileCoach");

            migrationBuilder.DropTable(
                name: "Categorias");

            migrationBuilder.DropTable(
                name: "DicasAgileCoach");
        }
    }
}
