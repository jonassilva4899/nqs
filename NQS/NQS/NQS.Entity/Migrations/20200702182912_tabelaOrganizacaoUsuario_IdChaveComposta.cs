using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Leega.Entity.Migrations
{
    public partial class tabelaOrganizacaoUsuario_IdChaveComposta : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_OrganizacaoUsuarios",
                table: "OrganizacaoUsuarios");

            migrationBuilder.DropIndex(
                name: "IX_OrganizacaoUsuarios_IdPessoa",
                table: "OrganizacaoUsuarios");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "OrganizacaoUsuarios");

            migrationBuilder.AddPrimaryKey(
                name: "PK_OrganizacaoUsuarios",
                table: "OrganizacaoUsuarios",
                columns: new[] { "IdPessoa", "IdOrganizacao" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_OrganizacaoUsuarios",
                table: "OrganizacaoUsuarios");

            migrationBuilder.AddColumn<Guid>(
                name: "Id",
                table: "OrganizacaoUsuarios",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddPrimaryKey(
                name: "PK_OrganizacaoUsuarios",
                table: "OrganizacaoUsuarios",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_OrganizacaoUsuarios_IdPessoa",
                table: "OrganizacaoUsuarios",
                column: "IdPessoa");
        }
    }
}
