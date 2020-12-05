using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Leega.Entity.Migrations
{
    public partial class InseridoCamposLog : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "DataCriacao",
                table: "PessoaMotivadores",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DataEdicao",
                table: "PessoaMotivadores",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<Guid>(
                name: "IdOrganizacao",
                table: "PessoaMotivadores",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "ResponsavelCriacao",
                table: "PessoaMotivadores",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "ResponsavelEdicao",
                table: "PessoaMotivadores",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<DateTime>(
                name: "DataCriacao",
                table: "PessoaHabilidades",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<Guid>(
                name: "IdOrganizacao",
                table: "PessoaHabilidades",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "ResponsavelCriacao",
                table: "PessoaHabilidades",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<DateTime>(
                name: "DataCriacao",
                table: "Motivadores",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<Guid>(
                name: "IdOrganizacao",
                table: "Motivadores",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "ResponsavelCriacao",
                table: "Motivadores",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<DateTime>(
                name: "DataCriacao",
                table: "Habilidades",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<Guid>(
                name: "IdOrganizacao",
                table: "Habilidades",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "ResponsavelCriacao",
                table: "Habilidades",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<DateTime>(
                name: "DataCriacao",
                table: "Acao",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DataEdicao",
                table: "Acao",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<Guid>(
                name: "IdOrganizacao",
                table: "Acao",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "ResponsavelCriacao",
                table: "Acao",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "ResponsavelEdicao",
                table: "Acao",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DataCriacao",
                table: "PessoaMotivadores");

            migrationBuilder.DropColumn(
                name: "DataEdicao",
                table: "PessoaMotivadores");

            migrationBuilder.DropColumn(
                name: "IdOrganizacao",
                table: "PessoaMotivadores");

            migrationBuilder.DropColumn(
                name: "ResponsavelCriacao",
                table: "PessoaMotivadores");

            migrationBuilder.DropColumn(
                name: "ResponsavelEdicao",
                table: "PessoaMotivadores");

            migrationBuilder.DropColumn(
                name: "DataCriacao",
                table: "PessoaHabilidades");

            migrationBuilder.DropColumn(
                name: "IdOrganizacao",
                table: "PessoaHabilidades");

            migrationBuilder.DropColumn(
                name: "ResponsavelCriacao",
                table: "PessoaHabilidades");

            migrationBuilder.DropColumn(
                name: "DataCriacao",
                table: "Motivadores");

            migrationBuilder.DropColumn(
                name: "IdOrganizacao",
                table: "Motivadores");

            migrationBuilder.DropColumn(
                name: "ResponsavelCriacao",
                table: "Motivadores");

            migrationBuilder.DropColumn(
                name: "DataCriacao",
                table: "Habilidades");

            migrationBuilder.DropColumn(
                name: "IdOrganizacao",
                table: "Habilidades");

            migrationBuilder.DropColumn(
                name: "ResponsavelCriacao",
                table: "Habilidades");

            migrationBuilder.DropColumn(
                name: "DataCriacao",
                table: "Acao");

            migrationBuilder.DropColumn(
                name: "DataEdicao",
                table: "Acao");

            migrationBuilder.DropColumn(
                name: "IdOrganizacao",
                table: "Acao");

            migrationBuilder.DropColumn(
                name: "ResponsavelCriacao",
                table: "Acao");

            migrationBuilder.DropColumn(
                name: "ResponsavelEdicao",
                table: "Acao");
        }
    }
}
