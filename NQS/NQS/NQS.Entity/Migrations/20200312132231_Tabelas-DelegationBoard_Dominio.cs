using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Leega.Entity.Migrations
{
    public partial class TabelasDelegationBoard_Dominio : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Dominios",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Nome = table.Column<string>(type: "VARCHAR(100)", nullable: true),
                    DataCriacao = table.Column<DateTime>(nullable: false),
                    ResponsavelCriacao = table.Column<Guid>(nullable: false),
                    IdOrganizacao = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dominios", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DelegationBoards",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    IdTime = table.Column<Guid>(nullable: false),
                    IdDominio = table.Column<Guid>(nullable: false),
                    IdSupervisor = table.Column<Guid>(nullable: false),
                    DelegationPoker = table.Column<int>(nullable: false),
                    IdResponsavelTime = table.Column<Guid>(nullable: false),
                    Observacao = table.Column<string>(type: "VARCHAR(1000)", nullable: true),
                    DataCriacao = table.Column<DateTime>(nullable: false),
                    ResponsavelCriacao = table.Column<Guid>(nullable: false),
                    DataEdicao = table.Column<DateTime>(nullable: true),
                    ResponsavelEdicao = table.Column<Guid>(nullable: true),
                    IdOrganizacao = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DelegationBoards", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DelegationBoards_Dominios_IdDominio",
                        column: x => x.IdDominio,
                        principalTable: "Dominios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DelegationBoards_Pessoas_IdResponsavelTime",
                        column: x => x.IdResponsavelTime,
                        principalTable: "Pessoas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DelegationBoards_Pessoas_IdSupervisor",
                        column: x => x.IdSupervisor,
                        principalTable: "Pessoas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DelegationBoards_Times_IdTime",
                        column: x => x.IdTime,
                        principalTable: "Times",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DelegationBoards_IdDominio",
                table: "DelegationBoards",
                column: "IdDominio",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_DelegationBoards_IdResponsavelTime",
                table: "DelegationBoards",
                column: "IdResponsavelTime");

            migrationBuilder.CreateIndex(
                name: "IX_DelegationBoards_IdSupervisor",
                table: "DelegationBoards",
                column: "IdSupervisor");

            migrationBuilder.CreateIndex(
                name: "IX_DelegationBoards_IdTime",
                table: "DelegationBoards",
                column: "IdTime");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DelegationBoards");

            migrationBuilder.DropTable(
                name: "Dominios");
        }
    }
}
