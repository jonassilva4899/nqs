using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Leega.Entity.Migrations
{
    public partial class tabelaIndicador : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Indicadores",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    IdTime = table.Column<Guid>(nullable: false),
                    Titulo = table.Column<string>(type: "VARCHAR(100)", nullable: true),
                    ValorPrincipal = table.Column<string>(type: "VARCHAR(100)", nullable: true),
                    ValorOpcionalUm = table.Column<string>(type: "VARCHAR(100)", nullable: true),
                    ValorOpcionalDois = table.Column<string>(type: "VARCHAR(100)", nullable: true),
                    ExibeDashPratica = table.Column<bool>(nullable: false),
                    Tipo = table.Column<int>(nullable: true),
                    TipoCalculo = table.Column<int>(nullable: true),
                    DataCriacao = table.Column<DateTime>(nullable: false),
                    ResponsavelCriacao = table.Column<Guid>(nullable: false),
                    DataEdicao = table.Column<DateTime>(nullable: true),
                    ResponsavelEdicao = table.Column<Guid>(nullable: true),
                    IdOrganizacao = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Indicadores", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Indicadores_Times_IdTime",
                        column: x => x.IdTime,
                        principalTable: "Times",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Indicadores_IdTime",
                table: "Indicadores",
                column: "IdTime");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Indicadores");
        }
    }
}
