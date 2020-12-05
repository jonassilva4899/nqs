using Microsoft.EntityFrameworkCore.Migrations;

namespace Leega.Entity.Migrations
{
    public partial class ajusteTamanhoCampoAcordos : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Acordos",
                table: "Times",
                type: "VARCHAR(8000)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "VARCHAR(3000)",
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Acordos",
                table: "Times",
                type: "VARCHAR(3000)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "VARCHAR(8000)",
                oldNullable: true);
        }
    }
}
