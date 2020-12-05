using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Leega.Entity.Migrations
{
    public partial class AdicionadaTabelaOrganizacaoUsuarioRole : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "IdOrganizacaoUsuarioRole",
                table: "OrganizacaoUsuarios",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "OrganizacaoUsuarioRoles",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Role = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrganizacaoUsuarioRoles", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_OrganizacaoUsuarios_IdOrganizacaoUsuarioRole",
                table: "OrganizacaoUsuarios",
                column: "IdOrganizacaoUsuarioRole");

            migrationBuilder.AddForeignKey(
                name: "FK_OrganizacaoUsuarios_OrganizacaoUsuarioRoles_IdOrganizacaoUsuarioRole",
                table: "OrganizacaoUsuarios",
                column: "IdOrganizacaoUsuarioRole",
                principalTable: "OrganizacaoUsuarioRoles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrganizacaoUsuarios_OrganizacaoUsuarioRoles_IdOrganizacaoUsuarioRole",
                table: "OrganizacaoUsuarios");

            migrationBuilder.DropTable(
                name: "OrganizacaoUsuarioRoles");

            migrationBuilder.DropIndex(
                name: "IX_OrganizacaoUsuarios_IdOrganizacaoUsuarioRole",
                table: "OrganizacaoUsuarios");

            migrationBuilder.DropColumn(
                name: "IdOrganizacaoUsuarioRole",
                table: "OrganizacaoUsuarios");
        }
    }
}
