using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Leega.Entity.Migrations
{
    public partial class RemoveRelacaoTimeUsuarioCriaTimePessoa : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TimeUsuarios");

            migrationBuilder.CreateTable(
                name: "TimePessoas",
                columns: table => new
                {
                    IdTime = table.Column<Guid>(nullable: false),
                    IdPessoa = table.Column<Guid>(nullable: false),
                    Papel = table.Column<string>(type: "VARCHAR(50)", nullable: true),
                    DataCriacao = table.Column<DateTime>(nullable: false),
                    ResponsavelCriacao = table.Column<Guid>(nullable: false),
                    DataEdicao = table.Column<DateTime>(nullable: false),
                    ResponsavelEdicao = table.Column<Guid>(nullable: false),
                    IdOrganizacao = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TimePessoas", x => new { x.IdTime, x.IdPessoa });
                    table.ForeignKey(
                        name: "FK_TimePessoas_Pessoas_IdPessoa",
                        column: x => x.IdPessoa,
                        principalTable: "Pessoas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TimePessoas_Times_IdTime",
                        column: x => x.IdTime,
                        principalTable: "Times",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TimePessoas_IdPessoa",
                table: "TimePessoas",
                column: "IdPessoa");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TimePessoas");

            migrationBuilder.CreateTable(
                name: "TimeUsuarios",
                columns: table => new
                {
                    IdTime = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IdUsuario = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DataCriacao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DataEdicao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IdOrganizacao = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Papel = table.Column<string>(type: "VARCHAR(50)", nullable: true),
                    ResponsavelCriacao = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ResponsavelEdicao = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TimeUsuarios", x => new { x.IdTime, x.IdUsuario });
                    table.ForeignKey(
                        name: "FK_TimeUsuarios_Times_IdTime",
                        column: x => x.IdTime,
                        principalTable: "Times",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TimeUsuarios_Usuarios_IdUsuario",
                        column: x => x.IdUsuario,
                        principalTable: "Usuarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TimeUsuarios_IdUsuario",
                table: "TimeUsuarios",
                column: "IdUsuario");
        }
    }
}
