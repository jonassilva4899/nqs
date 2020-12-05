using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Leega.Entity.Migrations
{
    public partial class KudoCards_Time : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "DataEnvio",
                table: "BoxKudoCard",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<Guid>(
                name: "IdTime",
                table: "BoxKudoCard",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_BoxKudoCard_IdTime",
                table: "BoxKudoCard",
                column: "IdTime");

            migrationBuilder.AddForeignKey(
                name: "FK_BoxKudoCard_Times_IdTime",
                table: "BoxKudoCard",
                column: "IdTime",
                principalTable: "Times",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BoxKudoCard_Times_IdTime",
                table: "BoxKudoCard");

            migrationBuilder.DropIndex(
                name: "IX_BoxKudoCard_IdTime",
                table: "BoxKudoCard");

            migrationBuilder.DropColumn(
                name: "DataEnvio",
                table: "BoxKudoCard");

            migrationBuilder.DropColumn(
                name: "IdTime",
                table: "BoxKudoCard");
        }
    }
}
