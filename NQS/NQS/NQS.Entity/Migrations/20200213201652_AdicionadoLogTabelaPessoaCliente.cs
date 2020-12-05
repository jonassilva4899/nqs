using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Leega.Entity.Migrations
{
    public partial class AdicionadoLogTabelaPessoaCliente : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "DataCriacao",
                table: "PessoaClientes",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DataEdicao",
                table: "PessoaClientes",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<Guid>(
                name: "IdOrganizacao",
                table: "PessoaClientes",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "ResponsavelCriacao",
                table: "PessoaClientes",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "ResponsavelEdicao",
                table: "PessoaClientes",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DataCriacao",
                table: "PessoaClientes");

            migrationBuilder.DropColumn(
                name: "DataEdicao",
                table: "PessoaClientes");

            migrationBuilder.DropColumn(
                name: "IdOrganizacao",
                table: "PessoaClientes");

            migrationBuilder.DropColumn(
                name: "ResponsavelCriacao",
                table: "PessoaClientes");

            migrationBuilder.DropColumn(
                name: "ResponsavelEdicao",
                table: "PessoaClientes");
        }
    }
}
