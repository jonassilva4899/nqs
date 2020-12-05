using Microsoft.EntityFrameworkCore.Migrations;

namespace Leega.Entity.Migrations
{
    public partial class EnumRetrospectiva : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Periodicidade",
                table: "RetrospectivaConfiguracao",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "VARCHAR(30)",
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Periodicidade",
                table: "RetrospectivaConfiguracao",
                type: "VARCHAR(30)",
                nullable: true,
                oldClrType: typeof(int));
        }
    }
}
