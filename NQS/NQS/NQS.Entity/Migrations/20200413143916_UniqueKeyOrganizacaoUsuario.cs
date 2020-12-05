using Microsoft.EntityFrameworkCore.Migrations;

namespace Leega.Entity.Migrations
{
    public partial class UniqueKeyOrganizacaoUsuario : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_OrganizacaoUsuarios_IdOrganizacao",
                table: "OrganizacaoUsuarios");

            migrationBuilder.CreateIndex(
                name: "IX_OrganizacaoUsuarios_IdOrganizacao_IdPessoa_IdUsuario",
                table: "OrganizacaoUsuarios",
                columns: new[] { "IdOrganizacao", "IdPessoa", "IdUsuario" },
                unique: true,
                filter: "[IdUsuario] IS NOT NULL");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_OrganizacaoUsuarios_IdOrganizacao_IdPessoa_IdUsuario",
                table: "OrganizacaoUsuarios");

            migrationBuilder.CreateIndex(
                name: "IX_OrganizacaoUsuarios_IdOrganizacao",
                table: "OrganizacaoUsuarios",
                column: "IdOrganizacao");
        }
    }
}
