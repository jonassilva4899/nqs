using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Leega.Entity.Migrations
{
    public partial class Retrospectiva_ProximaData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "ProximaData",
                table: "RetrospectivaConfiguracao",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "UltimaData",
                table: "RetrospectivaConfiguracao",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ProximaData",
                table: "RetrospectivaConfiguracao");

            migrationBuilder.DropColumn(
                name: "UltimaData",
                table: "RetrospectivaConfiguracao");
        }
    }
}
