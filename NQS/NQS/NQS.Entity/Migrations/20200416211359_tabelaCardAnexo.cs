using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Leega.Entity.Migrations
{
    public partial class tabelaCardAnexo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CardAnexos",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    IdColunaCard = table.Column<Guid>(nullable: false),
                    CaminhoArquivo = table.Column<string>(nullable: true),
                    DataCriacao = table.Column<DateTime>(nullable: false),
                    ResponsavelCriacao = table.Column<Guid>(nullable: false),
                    IdOrganizacao = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CardAnexos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CardAnexos_ColunaCards_IdColunaCard",
                        column: x => x.IdColunaCard,
                        principalTable: "ColunaCards",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CardAnexos_IdColunaCard",
                table: "CardAnexos",
                column: "IdColunaCard");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CardAnexos");
        }
    }
}
