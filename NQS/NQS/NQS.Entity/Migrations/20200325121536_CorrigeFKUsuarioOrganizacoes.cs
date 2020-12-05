using Microsoft.EntityFrameworkCore.Migrations;

namespace Leega.Entity.Migrations
{
    public partial class CorrigeFKUsuarioOrganizacoes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UsuarioOrganizacao_Usuarios_IdOrganizacao",
                table: "UsuarioOrganizacao");

            migrationBuilder.DropForeignKey(
                name: "FK_UsuarioOrganizacao_Organizacoes_IdUsuario",
                table: "UsuarioOrganizacao");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UsuarioOrganizacao",
                table: "UsuarioOrganizacao");

            migrationBuilder.RenameTable(
                name: "UsuarioOrganizacao",
                newName: "UsuarioOrganizacoes");

            migrationBuilder.RenameIndex(
                name: "IX_UsuarioOrganizacao_IdUsuario",
                table: "UsuarioOrganizacoes",
                newName: "IX_UsuarioOrganizacoes_IdUsuario");

            migrationBuilder.RenameIndex(
                name: "IX_UsuarioOrganizacao_IdOrganizacao",
                table: "UsuarioOrganizacoes",
                newName: "IX_UsuarioOrganizacoes_IdOrganizacao");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UsuarioOrganizacoes",
                table: "UsuarioOrganizacoes",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_UsuarioOrganizacoes_Organizacoes_IdOrganizacao",
                table: "UsuarioOrganizacoes",
                column: "IdOrganizacao",
                principalTable: "Organizacoes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UsuarioOrganizacoes_Usuarios_IdUsuario",
                table: "UsuarioOrganizacoes",
                column: "IdUsuario",
                principalTable: "Usuarios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UsuarioOrganizacoes_Organizacoes_IdOrganizacao",
                table: "UsuarioOrganizacoes");

            migrationBuilder.DropForeignKey(
                name: "FK_UsuarioOrganizacoes_Usuarios_IdUsuario",
                table: "UsuarioOrganizacoes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UsuarioOrganizacoes",
                table: "UsuarioOrganizacoes");

            migrationBuilder.RenameTable(
                name: "UsuarioOrganizacoes",
                newName: "UsuarioOrganizacao");

            migrationBuilder.RenameIndex(
                name: "IX_UsuarioOrganizacoes_IdUsuario",
                table: "UsuarioOrganizacao",
                newName: "IX_UsuarioOrganizacao_IdUsuario");

            migrationBuilder.RenameIndex(
                name: "IX_UsuarioOrganizacoes_IdOrganizacao",
                table: "UsuarioOrganizacao",
                newName: "IX_UsuarioOrganizacao_IdOrganizacao");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UsuarioOrganizacao",
                table: "UsuarioOrganizacao",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_UsuarioOrganizacao_Usuarios_IdOrganizacao",
                table: "UsuarioOrganizacao",
                column: "IdOrganizacao",
                principalTable: "Usuarios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UsuarioOrganizacao_Organizacoes_IdUsuario",
                table: "UsuarioOrganizacao",
                column: "IdUsuario",
                principalTable: "Organizacoes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
