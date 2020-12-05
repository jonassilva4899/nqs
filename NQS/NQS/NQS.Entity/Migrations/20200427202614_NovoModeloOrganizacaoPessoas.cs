using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Leega.Entity.Migrations
{
    public partial class NovoModeloOrganizacaoPessoas : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Usuarios_Pessoas_IdPessoa",
                table: "Usuarios");

            migrationBuilder.DropIndex(
                name: "IX_Usuarios_IdPessoa",
                table: "Usuarios");

            migrationBuilder.DropColumn(
                name: "IdPessoa",
                table: "Usuarios");

            //migrationBuilder.DropColumn(
            //    name: "FuncaoPrincipal",
            //    table: "Pessoas");

            migrationBuilder.AddColumn<string>(
                name: "FuncaoPrincipal",
                table: "OrganizacaoUsuarios",
                type: "VARCHAR(50)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FuncaoPrincipal",
                table: "OrganizacaoUsuarios");

            migrationBuilder.AddColumn<Guid>(
                name: "IdPessoa",
                table: "Usuarios",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<string>(
                name: "FuncaoPrincipal",
                table: "Pessoas",
                type: "VARCHAR(50)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Usuarios_IdPessoa",
                table: "Usuarios",
                column: "IdPessoa",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Usuarios_Pessoas_IdPessoa",
                table: "Usuarios",
                column: "IdPessoa",
                principalTable: "Pessoas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
