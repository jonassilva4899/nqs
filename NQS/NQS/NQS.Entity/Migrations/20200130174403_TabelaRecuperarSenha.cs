using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Leega.Entity.Migrations
{
    public partial class TabelaRecuperarSenha : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "RecuperarSenhas",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    DataSolicitacao = table.Column<DateTime>(nullable: false),
                    DataExpiracao = table.Column<DateTime>(nullable: false),
                    Ativo = table.Column<bool>(nullable: false),
                    Token = table.Column<string>(nullable: true),
                    NotificacaoFoiEnviada = table.Column<bool>(nullable: false),
                    MensagemResultadoNotificacao = table.Column<string>(nullable: true),
                    IdPessoa = table.Column<Guid>(nullable: false),
                    IdOrganizacao = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RecuperarSenhas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RecuperarSenhas_Pessoas_IdPessoa",
                        column: x => x.IdPessoa,
                        principalTable: "Pessoas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_RecuperarSenhas_IdPessoa",
                table: "RecuperarSenhas",
                column: "IdPessoa");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RecuperarSenhas");
        }
    }
}
