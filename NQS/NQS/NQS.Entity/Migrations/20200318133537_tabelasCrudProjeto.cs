using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Leega.Entity.Migrations
{
    public partial class tabelasCrudProjeto : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Projetos",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Nome = table.Column<string>(type: "VARCHAR(50)", nullable: true),
                    Logo = table.Column<string>(nullable: true),
                    Descrição = table.Column<string>(type: "VARCHAR(1000)", nullable: true),
                    IdCliente = table.Column<Guid>(nullable: false),
                    IdResponsavelComercial = table.Column<Guid>(nullable: false),
                    StatusProjeto = table.Column<int>(nullable: false),
                    CategoriaProjeto = table.Column<int>(nullable: false),
                    DeliveryProjeto = table.Column<int>(nullable: false),
                    DataInicio = table.Column<DateTime>(nullable: false),
                    DataFim = table.Column<DateTime>(nullable: false),
                    Custo = table.Column<double>(nullable: false),
                    Receita = table.Column<double>(nullable: false),
                    Esforço = table.Column<int>(nullable: false),
                    DataCriacao = table.Column<DateTime>(nullable: false),
                    ResponsavelCriacao = table.Column<Guid>(nullable: false),
                    DataEdicao = table.Column<DateTime>(nullable: true),
                    ResponsavelEdicao = table.Column<Guid>(nullable: true),
                    IdOrganizacao = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Projetos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Projetos_Clientes_IdCliente",
                        column: x => x.IdCliente,
                        principalTable: "Clientes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Projetos_Pessoas_IdResponsavelComercial",
                        column: x => x.IdResponsavelComercial,
                        principalTable: "Pessoas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ResponsavelProjetos",
                columns: table => new
                {
                    IdPessoa = table.Column<Guid>(nullable: false),
                    IdProjeto = table.Column<Guid>(nullable: false),
                    Ativo = table.Column<bool>(nullable: false),
                    DataCriacao = table.Column<DateTime>(nullable: false),
                    ResponsavelCriacao = table.Column<Guid>(nullable: false),
                    DataEdicao = table.Column<DateTime>(nullable: true),
                    ResponsavelEdicao = table.Column<Guid>(nullable: true),
                    IdOrganizacao = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ResponsavelProjetos", x => new { x.IdPessoa, x.IdProjeto });
                    table.ForeignKey(
                        name: "FK_ResponsavelProjetos_Pessoas_IdPessoa",
                        column: x => x.IdPessoa,
                        principalTable: "Pessoas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ResponsavelProjetos_Projetos_IdProjeto",
                        column: x => x.IdProjeto,
                        principalTable: "Projetos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TimeProjetos",
                columns: table => new
                {
                    IdTime = table.Column<Guid>(nullable: false),
                    IdProjeto = table.Column<Guid>(nullable: false),
                    Ativo = table.Column<bool>(nullable: false),
                    DataCriacao = table.Column<DateTime>(nullable: false),
                    ResponsavelCriacao = table.Column<Guid>(nullable: false),
                    DataEdicao = table.Column<DateTime>(nullable: true),
                    ResponsavelEdicao = table.Column<Guid>(nullable: true),
                    IdOrganizacao = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TimeProjetos", x => new { x.IdTime, x.IdProjeto });
                    table.ForeignKey(
                        name: "FK_TimeProjetos_Projetos_IdProjeto",
                        column: x => x.IdProjeto,
                        principalTable: "Projetos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TimeProjetos_Times_IdTime",
                        column: x => x.IdTime,
                        principalTable: "Times",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Projetos_IdCliente",
                table: "Projetos",
                column: "IdCliente");

            migrationBuilder.CreateIndex(
                name: "IX_Projetos_IdResponsavelComercial",
                table: "Projetos",
                column: "IdResponsavelComercial",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ResponsavelProjetos_IdProjeto",
                table: "ResponsavelProjetos",
                column: "IdProjeto");

            migrationBuilder.CreateIndex(
                name: "IX_TimeProjetos_IdProjeto",
                table: "TimeProjetos",
                column: "IdProjeto");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ResponsavelProjetos");

            migrationBuilder.DropTable(
                name: "TimeProjetos");

            migrationBuilder.DropTable(
                name: "Projetos");
        }
    }
}
