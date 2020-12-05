using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Leega.Entity.Migrations
{
    public partial class EpicoColunaCard : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "IdEpico",
                table: "ColunaCards",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ColunaCards_IdEpico",
                table: "ColunaCards",
                column: "IdEpico");

            migrationBuilder.AddForeignKey(
                name: "FK_ColunaCards_Epicos_IdEpico",
                table: "ColunaCards",
                column: "IdEpico",
                principalTable: "Epicos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ColunaCards_Epicos_IdEpico",
                table: "ColunaCards");

            migrationBuilder.DropIndex(
                name: "IX_ColunaCards_IdEpico",
                table: "ColunaCards");

            migrationBuilder.DropColumn(
                name: "IdEpico",
                table: "ColunaCards");
        }
    }
}
