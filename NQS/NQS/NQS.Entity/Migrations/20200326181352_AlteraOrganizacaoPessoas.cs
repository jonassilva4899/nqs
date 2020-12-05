using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Leega.Entity.Migrations
{
    public partial class AlteraOrganizacaoPessoas : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UsuarioOrganizacoes");

            migrationBuilder.DropColumn(
                name: "IdPessoa",
                table: "Organizacoes");

            migrationBuilder.CreateTable(
                name: "OrganizacaoPessoas",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    IdPessoa = table.Column<Guid>(nullable: false),
                    IdOrganizacao = table.Column<Guid>(nullable: false),
                    DataCriacao = table.Column<DateTime>(nullable: false),
                    ResponsavelCriacao = table.Column<Guid>(nullable: false)
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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OrganizacaoPessoas");

            migrationBuilder.AddColumn<Guid>(
                name: "IdPessoa",
                table: "Organizacoes",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateTable(
                name: "UsuarioOrganizacoes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DataCriacao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IdOrganizacao = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IdUsuario = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ResponsavelCriacao = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UsuarioOrganizacoes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UsuarioOrganizacoes_Organizacoes_IdOrganizacao",
                        column: x => x.IdOrganizacao,
                        principalTable: "Organizacoes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UsuarioOrganizacoes_Usuarios_IdUsuario",
                        column: x => x.IdUsuario,
                        principalTable: "Usuarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_UsuarioOrganizacoes_IdOrganizacao",
                table: "UsuarioOrganizacoes",
                column: "IdOrganizacao");

            migrationBuilder.CreateIndex(
                name: "IX_UsuarioOrganizacoes_IdUsuario",
                table: "UsuarioOrganizacoes",
                column: "IdUsuario");
        }
    }
}
