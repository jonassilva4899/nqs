using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Leega.Entity.Migrations
{
    public partial class tabelaPlanninObjetivo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PlanningObjetivos",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    IdPalnning = table.Column<Guid>(nullable: false),
                    Objetivo = table.Column<string>(type: "VARCHAR(500)", nullable: true),
                    StatusObjetivo = table.Column<int>(nullable: true),
                    DataCriacao = table.Column<DateTime>(nullable: false),
                    ResponsavelCriacao = table.Column<Guid>(nullable: false),
                    DataEdicao = table.Column<DateTime>(nullable: true),
                    ResponsavelEdicao = table.Column<Guid>(nullable: true),
                    IdOrganizacao = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlanningObjetivos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PlanningObjetivos_Plannings_IdPalnning",
                        column: x => x.IdPalnning,
                        principalTable: "Plannings",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PlanningObjetivos_IdPalnning",
                table: "PlanningObjetivos",
                column: "IdPalnning");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PlanningObjetivos");
        }
    }
}
