using Microsoft.EntityFrameworkCore.Migrations;

namespace Leega.Entity.Migrations
{
    public partial class AlteracaoNomeCampoTabelaDelegationBoard : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DelegationPoker",
                table: "DelegationBoards");

            migrationBuilder.AddColumn<int>(
                name: "NivelAutoridade",
                table: "DelegationBoards",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NivelAutoridade",
                table: "DelegationBoards");

            migrationBuilder.AddColumn<int>(
                name: "DelegationPoker",
                table: "DelegationBoards",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
