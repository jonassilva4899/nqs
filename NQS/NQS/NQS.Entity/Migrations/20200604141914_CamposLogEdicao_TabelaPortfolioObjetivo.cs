using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Leega.Entity.Migrations
{
    public partial class CamposLogEdicao_TabelaPortfolioObjetivo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "DataEdicao",
                table: "PortfolioObjetivos",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "ResponsavelEdicao",
                table: "PortfolioObjetivos",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DataEdicao",
                table: "PortfolioObjetivos");

            migrationBuilder.DropColumn(
                name: "ResponsavelEdicao",
                table: "PortfolioObjetivos");
        }
    }
}
