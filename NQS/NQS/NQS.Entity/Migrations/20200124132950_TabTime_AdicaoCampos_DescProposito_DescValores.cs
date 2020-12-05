using Microsoft.EntityFrameworkCore.Migrations;

namespace Leega.Entity.Migrations
{
    public partial class TabTime_AdicaoCampos_DescProposito_DescValores : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "DescricaoProposito",
                table: "Times",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DescricaoValores",
                table: "Times",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DescricaoProposito",
                table: "Times");

            migrationBuilder.DropColumn(
                name: "DescricaoValores",
                table: "Times");
        }
    }
}
