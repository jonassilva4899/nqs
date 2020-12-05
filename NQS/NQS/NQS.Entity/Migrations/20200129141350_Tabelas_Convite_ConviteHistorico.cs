using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Leega.Entity.Migrations
{
    public partial class Tabelas_Convite_ConviteHistorico : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Convites",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Nome = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    Status = table.Column<int>(nullable: false),
                    IdPessoaCriada = table.Column<Guid>(nullable: false),
                    PessoaCriadaId = table.Column<Guid>(nullable: true),
                    IdOrganizacao = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Convites", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Convites_Pessoas_PessoaCriadaId",
                        column: x => x.PessoaCriadaId,
                        principalTable: "Pessoas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ConvitesHistorico",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    DataEnvio = table.Column<DateTime>(nullable: false),
                    DataExpiracao = table.Column<DateTime>(nullable: false),
                    MensagemNotificacao = table.Column<string>(nullable: true),
                    Token = table.Column<string>(nullable: true),
                    FoiEnviado = table.Column<bool>(nullable: false),
                    MensagemResultadoNotificacao = table.Column<string>(nullable: true),
                    IdPessoaRequisita = table.Column<Guid>(nullable: false),
                    PessoaRequisitaId = table.Column<Guid>(nullable: true),
                    IdConvite = table.Column<Guid>(nullable: false),
                    IdOrganizacao = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ConvitesHistorico", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ConvitesHistorico_Convites_IdConvite",
                        column: x => x.IdConvite,
                        principalTable: "Convites",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ConvitesHistorico_Pessoas_PessoaRequisitaId",
                        column: x => x.PessoaRequisitaId,
                        principalTable: "Pessoas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Convites_PessoaCriadaId",
                table: "Convites",
                column: "PessoaCriadaId");

            migrationBuilder.CreateIndex(
                name: "IX_ConvitesHistorico_IdConvite",
                table: "ConvitesHistorico",
                column: "IdConvite");

            migrationBuilder.CreateIndex(
                name: "IX_ConvitesHistorico_PessoaRequisitaId",
                table: "ConvitesHistorico",
                column: "PessoaRequisitaId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ConvitesHistorico");

            migrationBuilder.DropTable(
                name: "Convites");
        }
    }
}
