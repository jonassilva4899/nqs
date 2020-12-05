using Microsoft.EntityFrameworkCore.Migrations;

namespace Leega.Entity.Migrations
{
    public partial class IntValorManualCapacityConfiguracao : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "ValorManual",
                table: "CapacityConfiguracoes",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "VARCHAR(100)",
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "ValorManual",
                table: "CapacityConfiguracoes",
                type: "VARCHAR(100)",
                nullable: true,
                oldClrType: typeof(int),
                oldNullable: true);
        }
    }
}
