using Microsoft.EntityFrameworkCore.Migrations;

namespace Leega.Entity.Migrations
{
    public partial class SomenteMembrosPesquisa : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "SomenteMembros",
                table: "EnpsPesquisas",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SomenteMembros",
                table: "EnpsPesquisas");
        }
    }
}
