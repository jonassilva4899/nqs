using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Leega.Entity.Migrations
{
    public partial class AdicionadoCampoColunaDe_TabelaCardLog : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CardLogs_QuadroColunas_IdQuadroColuna",
                table: "CardLogs");

            migrationBuilder.DropIndex(
                name: "IX_CardLogs_IdQuadroColuna",
                table: "CardLogs");

            migrationBuilder.DropColumn(
                name: "IdQuadroColuna",
                table: "CardLogs");

            migrationBuilder.AddColumn<Guid>(
                name: "IdQuadroColunaDe",
                table: "CardLogs",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "IdQuadroColunaPara",
                table: "CardLogs",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_CardLogs_IdQuadroColunaDe",
                table: "CardLogs",
                column: "IdQuadroColunaDe");

            migrationBuilder.CreateIndex(
                name: "IX_CardLogs_IdQuadroColunaPara",
                table: "CardLogs",
                column: "IdQuadroColunaPara");

            migrationBuilder.AddForeignKey(
                name: "FK_CardLogs_QuadroColunas_IdQuadroColunaDe",
                table: "CardLogs",
                column: "IdQuadroColunaDe",
                principalTable: "QuadroColunas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_CardLogs_QuadroColunas_IdQuadroColunaPara",
                table: "CardLogs",
                column: "IdQuadroColunaPara",
                principalTable: "QuadroColunas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CardLogs_QuadroColunas_IdQuadroColunaDe",
                table: "CardLogs");

            migrationBuilder.DropForeignKey(
                name: "FK_CardLogs_QuadroColunas_IdQuadroColunaPara",
                table: "CardLogs");

            migrationBuilder.DropIndex(
                name: "IX_CardLogs_IdQuadroColunaDe",
                table: "CardLogs");

            migrationBuilder.DropIndex(
                name: "IX_CardLogs_IdQuadroColunaPara",
                table: "CardLogs");

            migrationBuilder.DropColumn(
                name: "IdQuadroColunaDe",
                table: "CardLogs");

            migrationBuilder.DropColumn(
                name: "IdQuadroColunaPara",
                table: "CardLogs");

            migrationBuilder.AddColumn<Guid>(
                name: "IdQuadroColuna",
                table: "CardLogs",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_CardLogs_IdQuadroColuna",
                table: "CardLogs",
                column: "IdQuadroColuna");

            migrationBuilder.AddForeignKey(
                name: "FK_CardLogs_QuadroColunas_IdQuadroColuna",
                table: "CardLogs",
                column: "IdQuadroColuna",
                principalTable: "QuadroColunas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
