using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Leega.Entity.Migrations
{
    public partial class UsuarioOrganizacoes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IdOrganizacao",
                table: "Usuarios");

            migrationBuilder.CreateTable(
                name: "Organizacoes",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Nome = table.Column<string>(type: "VARCHAR(100)", nullable: true),
                    Foto = table.Column<string>(nullable: true),
                    Descricao = table.Column<string>(type: "VARCHAR(1000)", nullable: true),
                    Localizacao = table.Column<string>(type: "VARCHAR(100)", nullable: true),
                    IdPessoa = table.Column<Guid>(nullable: false),
                    DataCriacao = table.Column<DateTime>(nullable: false),
                    ResponsavelCriacao = table.Column<Guid>(nullable: false),
                    DataEdicao = table.Column<DateTime>(nullable: false),
                    ResponsavelEdicao = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Organizacoes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UsuarioOrganizacao",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    IdUsuario = table.Column<Guid>(nullable: false),
                    IdOrganizacao = table.Column<Guid>(nullable: false),
                    DataCriacao = table.Column<DateTime>(nullable: false),
                    ResponsavelCriacao = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UsuarioOrganizacao", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UsuarioOrganizacao_Usuarios_IdOrganizacao",
                        column: x => x.IdOrganizacao,
                        principalTable: "Usuarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UsuarioOrganizacao_Organizacoes_IdUsuario",
                        column: x => x.IdUsuario,
                        principalTable: "Organizacoes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_UsuarioOrganizacao_IdOrganizacao",
                table: "UsuarioOrganizacao",
                column: "IdOrganizacao");

            migrationBuilder.CreateIndex(
                name: "IX_UsuarioOrganizacao_IdUsuario",
                table: "UsuarioOrganizacao",
                column: "IdUsuario");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UsuarioOrganizacao");

            migrationBuilder.DropTable(
                name: "Organizacoes");

            migrationBuilder.AddColumn<Guid>(
                name: "IdOrganizacao",
                table: "Usuarios",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));
        }
    }
}
