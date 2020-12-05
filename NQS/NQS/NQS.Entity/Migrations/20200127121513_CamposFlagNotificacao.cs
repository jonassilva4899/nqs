using Microsoft.EntityFrameworkCore.Migrations;

namespace Leega.Entity.Migrations
{
    public partial class CamposFlagNotificacao : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_NotificacaoUsuarios",
                table: "NotificacaoUsuarios");

            migrationBuilder.DropIndex(
                name: "IX_NotificacaoUsuarios_IdNotificacao",
                table: "NotificacaoUsuarios");

            migrationBuilder.AddColumn<bool>(
                name: "ConfirmacaoLeitura",
                table: "Notificacoes",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "EnviadoPorEmail",
                table: "Notificacoes",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddPrimaryKey(
                name: "PK_NotificacaoUsuarios",
                table: "NotificacaoUsuarios",
                columns: new[] { "IdNotificacao", "IdUsuario" });

            migrationBuilder.CreateIndex(
                name: "IX_NotificacaoUsuarios_IdUsuario",
                table: "NotificacaoUsuarios",
                column: "IdUsuario");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_NotificacaoUsuarios",
                table: "NotificacaoUsuarios");

            migrationBuilder.DropIndex(
                name: "IX_NotificacaoUsuarios_IdUsuario",
                table: "NotificacaoUsuarios");

            migrationBuilder.DropColumn(
                name: "ConfirmacaoLeitura",
                table: "Notificacoes");

            migrationBuilder.DropColumn(
                name: "EnviadoPorEmail",
                table: "Notificacoes");

            migrationBuilder.AddPrimaryKey(
                name: "PK_NotificacaoUsuarios",
                table: "NotificacaoUsuarios",
                columns: new[] { "IdUsuario", "IdNotificacao" });

            migrationBuilder.CreateIndex(
                name: "IX_NotificacaoUsuarios_IdNotificacao",
                table: "NotificacaoUsuarios",
                column: "IdNotificacao");
        }
    }
}
