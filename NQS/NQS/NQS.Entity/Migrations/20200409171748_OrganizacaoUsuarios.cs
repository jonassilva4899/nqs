using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Leega.Entity.Migrations
{
    public partial class OrganizacaoUsuarios : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OrganizacaoPessoas");

            migrationBuilder.CreateTable(
                name: "OrganizacaoUsuarios",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    IdPessoa = table.Column<Guid>(nullable: false),
                    IdOrganizacao = table.Column<Guid>(nullable: false),
                    IdUsuario = table.Column<Guid>(nullable: true),
                    UsuarioPlataforma = table.Column<bool>(nullable: false),
                    Ativo = table.Column<bool>(nullable: false),
                    DataCriacao = table.Column<DateTime>(nullable: false),
                    ResponsavelCriacao = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrganizacaoUsuarios", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrganizacaoUsuarios_Organizacoes_IdOrganizacao",
                        column: x => x.IdOrganizacao,
                        principalTable: "Organizacoes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrganizacaoUsuarios_Pessoas_IdPessoa",
                        column: x => x.IdPessoa,
                        principalTable: "Pessoas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrganizacaoUsuarios_Usuarios_IdUsuario",
                        column: x => x.IdUsuario,
                        principalTable: "Usuarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_OrganizacaoUsuarios_IdOrganizacao",
                table: "OrganizacaoUsuarios",
                column: "IdOrganizacao");

            migrationBuilder.CreateIndex(
                name: "IX_OrganizacaoUsuarios_IdPessoa",
                table: "OrganizacaoUsuarios",
                column: "IdPessoa");

            migrationBuilder.CreateIndex(
                name: "IX_OrganizacaoUsuarios_IdUsuario",
                table: "OrganizacaoUsuarios",
                column: "IdUsuario");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OrganizacaoUsuarios");

            migrationBuilder.CreateTable(
                name: "OrganizacaoPessoas",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DataCriacao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IdOrganizacao = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IdPessoa = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ResponsavelCriacao = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrganizacaoPessoas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrganizacaoPessoas_Organizacoes_IdOrganizacao",
                        column: x => x.IdOrganizacao,
                        principalTable: "Organizacoes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrganizacaoPessoas_Pessoas_IdPessoa",
                        column: x => x.IdPessoa,
                        principalTable: "Pessoas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_OrganizacaoPessoas_IdOrganizacao",
                table: "OrganizacaoPessoas",
                column: "IdOrganizacao");

            migrationBuilder.CreateIndex(
                name: "IX_OrganizacaoPessoas_IdPessoa",
                table: "OrganizacaoPessoas",
                column: "IdPessoa");
        }
    }
}
