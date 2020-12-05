using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Leega.Entity.Migrations
{
    public partial class KudoCards : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "KudoCards",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Tipo = table.Column<int>(nullable: false),
                    Mensagem = table.Column<string>(type: "VARCHAR(50)", nullable: true),
                    ResponsavelCriacao = table.Column<Guid>(nullable: false),
                    DataCriacao = table.Column<DateTime>(nullable: false),
                    ResponsavelEdicao = table.Column<Guid>(nullable: true),
                    DataEdicao = table.Column<DateTime>(nullable: true),
                    IdOrganizacao = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KudoCards", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BoxKudoCard",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    IdKudoCard = table.Column<Guid>(nullable: false),
                    De = table.Column<Guid>(nullable: false),
                    Para = table.Column<Guid>(nullable: false),
                    Mensagem = table.Column<string>(type: "VARCHAR(1000)", nullable: true),
                    Tipo = table.Column<int>(nullable: false),
                    ResponsavelCriacao = table.Column<Guid>(nullable: false),
                    DataCriacao = table.Column<DateTime>(nullable: false),
                    IdOrganizacao = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BoxKudoCard", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BoxKudoCard_Pessoas_De",
                        column: x => x.De,
                        principalTable: "Pessoas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BoxKudoCard_KudoCards_IdKudoCard",
                        column: x => x.IdKudoCard,
                        principalTable: "KudoCards",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BoxKudoCard_Pessoas_Para",
                        column: x => x.Para,
                        principalTable: "Pessoas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BoxKudoCard_De",
                table: "BoxKudoCard",
                column: "De");

            migrationBuilder.CreateIndex(
                name: "IX_BoxKudoCard_IdKudoCard",
                table: "BoxKudoCard",
                column: "IdKudoCard");

            migrationBuilder.CreateIndex(
                name: "IX_BoxKudoCard_Para",
                table: "BoxKudoCard",
                column: "Para");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BoxKudoCard");

            migrationBuilder.DropTable(
                name: "KudoCards");
        }
    }
}
