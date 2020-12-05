using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Leega.Entity.Migrations
{
    public partial class NotificacaoPraticaAgil : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "NotificacaoPraticasAgeis",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    IdPraticaAgil = table.Column<Guid>(nullable: false),
                    IdTime = table.Column<Guid>(nullable: false),
                    AntecedenciaMin = table.Column<string>(nullable: true),
                    PosterioridadeMin = table.Column<string>(nullable: true),
                    IdOrganizacao = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NotificacaoPraticasAgeis", x => x.Id);
                    table.ForeignKey(
                        name: "FK_NotificacaoPraticasAgeis_PraticasAgeis_IdPraticaAgil",
                        column: x => x.IdPraticaAgil,
                        principalTable: "PraticasAgeis",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_NotificacaoPraticasAgeis_Times_IdTime",
                        column: x => x.IdTime,
                        principalTable: "Times",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_NotificacaoPraticasAgeis_IdPraticaAgil",
                table: "NotificacaoPraticasAgeis",
                column: "IdPraticaAgil");

            migrationBuilder.CreateIndex(
                name: "IX_NotificacaoPraticasAgeis_IdTime",
                table: "NotificacaoPraticasAgeis",
                column: "IdTime");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "NotificacaoPraticasAgeis");
        }
    }
}
