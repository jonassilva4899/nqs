using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Leega.Entity.Migrations
{
    public partial class TabelaPersonalMapping_TituloItem : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<Guid>(
                name: "IdResponsavel",
                table: "Acao",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AlterColumn<Guid>(
                name: "IdPessoaCriacao",
                table: "Acao",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.CreateTable(
                name: "PersonalMappingTitulos",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Titulo = table.Column<string>(type: "VARCHAR(100)", nullable: true),
                    IdPessoa = table.Column<Guid>(nullable: false),
                    DataCriacao = table.Column<DateTime>(nullable: false),
                    ResponsavelCriacao = table.Column<Guid>(nullable: false),
                    DataEdicao = table.Column<DateTime>(nullable: false),
                    ResponsavelEdicao = table.Column<Guid>(nullable: false),
                    IdOrganizacao = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PersonalMappingTitulos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PersonalMappingTitulos_Pessoas_IdPessoa",
                        column: x => x.IdPessoa,
                        principalTable: "Pessoas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PersonalMappingItens",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Item = table.Column<string>(type: "VARCHAR(1000)", nullable: true),
                    IdPersonalMappingTitulo = table.Column<Guid>(nullable: false),
                    DataCriacao = table.Column<DateTime>(nullable: false),
                    ResponsavelCriacao = table.Column<Guid>(nullable: false),
                    DataEdicao = table.Column<DateTime>(nullable: false),
                    ResponsavelEdicao = table.Column<Guid>(nullable: false),
                    IdOrganizacao = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PersonalMappingItens", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PersonalMappingItens_PersonalMappingTitulos_IdPersonalMappingTitulo",
                        column: x => x.IdPersonalMappingTitulo,
                        principalTable: "PersonalMappingTitulos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PersonalMappingItens_IdPersonalMappingTitulo",
                table: "PersonalMappingItens",
                column: "IdPersonalMappingTitulo");

            migrationBuilder.CreateIndex(
                name: "IX_PersonalMappingTitulos_IdPessoa",
                table: "PersonalMappingTitulos",
                column: "IdPessoa");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PersonalMappingItens");

            migrationBuilder.DropTable(
                name: "PersonalMappingTitulos");

            migrationBuilder.AlterColumn<Guid>(
                name: "IdResponsavel",
                table: "Acao",
                type: "uniqueidentifier",
                nullable: false,
                oldClrType: typeof(Guid),
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "IdPessoaCriacao",
                table: "Acao",
                type: "uniqueidentifier",
                nullable: false,
                oldClrType: typeof(Guid),
                oldNullable: true);
        }
    }
}
