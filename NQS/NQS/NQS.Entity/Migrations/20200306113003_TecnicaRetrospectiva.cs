using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Leega.Entity.Migrations
{
    public partial class TecnicaRetrospectiva : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TecnicaUtilizada",
                table: "Retrospectiva");

            migrationBuilder.AddColumn<Guid>(
                name: "IdTecnicaUtilizada",
                table: "Retrospectiva",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateTable(
                name: "TecnicaRestrospectiva",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Nome = table.Column<string>(nullable: true),
                    Ativo = table.Column<bool>(nullable: false),
                    DataCriacao = table.Column<DateTime>(nullable: false),
                    ResponsavelCriacao = table.Column<Guid>(nullable: false),
                    DataEdicao = table.Column<DateTime>(nullable: false),
                    ResponsavelEdicao = table.Column<Guid>(nullable: false),
                    IdOrganizacao = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TecnicaRestrospectiva", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Retrospectiva_IdTecnicaUtilizada",
                table: "Retrospectiva",
                column: "IdTecnicaUtilizada");

            migrationBuilder.AddForeignKey(
                name: "FK_Retrospectiva_TecnicaRestrospectiva_IdTecnicaUtilizada",
                table: "Retrospectiva",
                column: "IdTecnicaUtilizada",
                principalTable: "TecnicaRestrospectiva",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Retrospectiva_TecnicaRestrospectiva_IdTecnicaUtilizada",
                table: "Retrospectiva");

            migrationBuilder.DropTable(
                name: "TecnicaRestrospectiva");

            migrationBuilder.DropIndex(
                name: "IX_Retrospectiva_IdTecnicaUtilizada",
                table: "Retrospectiva");

            migrationBuilder.DropColumn(
                name: "IdTecnicaUtilizada",
                table: "Retrospectiva");

            migrationBuilder.AddColumn<string>(
                name: "TecnicaUtilizada",
                table: "Retrospectiva",
                type: "VARCHAR(30)",
                nullable: true);
        }
    }
}
