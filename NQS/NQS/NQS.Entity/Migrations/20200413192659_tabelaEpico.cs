using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Leega.Entity.Migrations
{
    public partial class tabelaEpico : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Epicos",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    IdProjeto = table.Column<Guid>(nullable: false),
                    Nome = table.Column<string>(type: "VARCHAR(100)", nullable: true),
                    Descrição = table.Column<string>(type: "VARCHAR(2000)", nullable: true),
                    Status = table.Column<int>(nullable: false),
                    Tamanho = table.Column<int>(nullable: false),
                    DataEntrega = table.Column<DateTime>(nullable: false),
                    IdOwner = table.Column<Guid>(nullable: false),
                    IdResponsavel = table.Column<Guid>(nullable: false),
                    DataCriacao = table.Column<DateTime>(nullable: false),
                    ResponsavelCriacao = table.Column<Guid>(nullable: false),
                    DataEdicao = table.Column<DateTime>(nullable: true),
                    ResponsavelEdicao = table.Column<Guid>(nullable: true),
                    IdOrganizacao = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Epicos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Epicos_Pessoas_IdOwner",
                        column: x => x.IdOwner,
                        principalTable: "Pessoas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Epicos_Projetos_IdProjeto",
                        column: x => x.IdProjeto,
                        principalTable: "Projetos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Epicos_Pessoas_IdResponsavel",
                        column: x => x.IdResponsavel,
                        principalTable: "Pessoas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Epicos_IdOwner",
                table: "Epicos",
                column: "IdOwner");

            migrationBuilder.CreateIndex(
                name: "IX_Epicos_IdProjeto",
                table: "Epicos",
                column: "IdProjeto");

            migrationBuilder.CreateIndex(
                name: "IX_Epicos_IdResponsavel",
                table: "Epicos",
                column: "IdResponsavel");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Epicos");
        }
    }
}
