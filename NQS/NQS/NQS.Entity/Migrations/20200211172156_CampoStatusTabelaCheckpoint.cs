using Microsoft.EntityFrameworkCore.Migrations;

namespace Leega.Entity.Migrations
{
    public partial class CampoStatusTabelaCheckpoint : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Status",
                table: "Checkpoints",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Status",
                table: "Checkpoints");
        }
    }
}
