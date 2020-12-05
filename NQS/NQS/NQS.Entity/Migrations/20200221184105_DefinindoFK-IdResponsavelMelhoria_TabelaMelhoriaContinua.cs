using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Leega.Entity.Migrations
{
    public partial class DefinindoFKIdResponsavelMelhoria_TabelaMelhoriaContinua : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MelhoriasContinuas_Pessoas_ResponsavelMelhoriaId",
                table: "MelhoriasContinuas");

            migrationBuilder.DropIndex(
                name: "IX_MelhoriasContinuas_ResponsavelMelhoriaId",
                table: "MelhoriasContinuas");

            migrationBuilder.DropColumn(
                name: "IdResponsavelMelhoria",
                table: "MelhoriasContinuas");

            migrationBuilder.DropColumn(
                name: "ResponsavelMelhoriaId",
                table: "MelhoriasContinuas");

            migrationBuilder.AddColumn<Guid>(
                name: "IdResponsavelMelhoriaContinua",
                table: "MelhoriasContinuas",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_MelhoriasContinuas_IdResponsavelMelhoriaContinua",
                table: "MelhoriasContinuas",
                column: "IdResponsavelMelhoriaContinua");

            migrationBuilder.AddForeignKey(
                name: "FK_MelhoriasContinuas_Pessoas_IdResponsavelMelhoriaContinua",
                table: "MelhoriasContinuas",
                column: "IdResponsavelMelhoriaContinua",
                principalTable: "Pessoas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MelhoriasContinuas_Pessoas_IdResponsavelMelhoriaContinua",
                table: "MelhoriasContinuas");

            migrationBuilder.DropIndex(
                name: "IX_MelhoriasContinuas_IdResponsavelMelhoriaContinua",
                table: "MelhoriasContinuas");

            migrationBuilder.DropColumn(
                name: "IdResponsavelMelhoriaContinua",
                table: "MelhoriasContinuas");

            migrationBuilder.AddColumn<Guid>(
                name: "IdResponsavelMelhoria",
                table: "MelhoriasContinuas",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "ResponsavelMelhoriaId",
                table: "MelhoriasContinuas",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_MelhoriasContinuas_ResponsavelMelhoriaId",
                table: "MelhoriasContinuas",
                column: "ResponsavelMelhoriaId");

            migrationBuilder.AddForeignKey(
                name: "FK_MelhoriasContinuas_Pessoas_ResponsavelMelhoriaId",
                table: "MelhoriasContinuas",
                column: "ResponsavelMelhoriaId",
                principalTable: "Pessoas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
