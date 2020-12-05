using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Leega.Entity.Migrations
{
    public partial class ajusteRelacaoEntreQuadro_Time : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Quadros_Times_TimeId",
                table: "Quadros");

            migrationBuilder.DropIndex(
                name: "IX_Quadros_TimeId",
                table: "Quadros");

            migrationBuilder.DropColumn(
                name: "TimeId",
                table: "Quadros");

            migrationBuilder.CreateIndex(
                name: "IX_Quadros_IdTime",
                table: "Quadros",
                column: "IdTime");

            migrationBuilder.AddForeignKey(
                name: "FK_Quadros_Times_IdTime",
                table: "Quadros",
                column: "IdTime",
                principalTable: "Times",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Quadros_Times_IdTime",
                table: "Quadros");

            migrationBuilder.DropIndex(
                name: "IX_Quadros_IdTime",
                table: "Quadros");

            migrationBuilder.AddColumn<Guid>(
                name: "TimeId",
                table: "Quadros",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Quadros_TimeId",
                table: "Quadros",
                column: "TimeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Quadros_Times_TimeId",
                table: "Quadros",
                column: "TimeId",
                principalTable: "Times",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
