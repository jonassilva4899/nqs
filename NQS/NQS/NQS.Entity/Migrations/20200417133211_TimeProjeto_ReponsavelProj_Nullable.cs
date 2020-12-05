using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Leega.Entity.Migrations
{
    public partial class TimeProjeto_ReponsavelProj_Nullable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ResponsavelProjetos_Pessoas_IdPessoa",
                table: "ResponsavelProjetos");

            migrationBuilder.DropForeignKey(
                name: "FK_TimeProjetos_Times_IdTime",
                table: "TimeProjetos");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TimeProjetos",
                table: "TimeProjetos");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ResponsavelProjetos",
                table: "ResponsavelProjetos");

            migrationBuilder.AlterColumn<bool>(
                name: "Ativo",
                table: "TimeProjetos",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AlterColumn<Guid>(
                name: "IdTime",
                table: "TimeProjetos",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AddColumn<Guid>(
                name: "Id",
                table: "TimeProjetos",
                nullable: false,
                defaultValueSql: "NEWID()");

            migrationBuilder.AlterColumn<bool>(
                name: "Ativo",
                table: "ResponsavelProjetos",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AlterColumn<Guid>(
                name: "IdPessoa",
                table: "ResponsavelProjetos",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AddColumn<Guid>(
                name: "Id",
                table: "ResponsavelProjetos",
                nullable: false,
                defaultValueSql: "NEWID()");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TimeProjetos",
                table: "TimeProjetos",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ResponsavelProjetos",
                table: "ResponsavelProjetos",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_TimeProjetos_IdTime",
                table: "TimeProjetos",
                column: "IdTime");

            migrationBuilder.CreateIndex(
                name: "IX_ResponsavelProjetos_IdPessoa",
                table: "ResponsavelProjetos",
                column: "IdPessoa");

            migrationBuilder.AddForeignKey(
                name: "FK_ResponsavelProjetos_Pessoas_IdPessoa",
                table: "ResponsavelProjetos",
                column: "IdPessoa",
                principalTable: "Pessoas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TimeProjetos_Times_IdTime",
                table: "TimeProjetos",
                column: "IdTime",
                principalTable: "Times",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ResponsavelProjetos_Pessoas_IdPessoa",
                table: "ResponsavelProjetos");

            migrationBuilder.DropForeignKey(
                name: "FK_TimeProjetos_Times_IdTime",
                table: "TimeProjetos");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TimeProjetos",
                table: "TimeProjetos");

            migrationBuilder.DropIndex(
                name: "IX_TimeProjetos_IdTime",
                table: "TimeProjetos");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ResponsavelProjetos",
                table: "ResponsavelProjetos");

            migrationBuilder.DropIndex(
                name: "IX_ResponsavelProjetos_IdPessoa",
                table: "ResponsavelProjetos");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "TimeProjetos");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "ResponsavelProjetos");

            migrationBuilder.AlterColumn<Guid>(
                name: "IdTime",
                table: "TimeProjetos",
                type: "uniqueidentifier",
                nullable: false,
                oldClrType: typeof(Guid),
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "Ativo",
                table: "TimeProjetos",
                type: "bit",
                nullable: false,
                oldClrType: typeof(bool),
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "IdPessoa",
                table: "ResponsavelProjetos",
                type: "uniqueidentifier",
                nullable: false,
                oldClrType: typeof(Guid),
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "Ativo",
                table: "ResponsavelProjetos",
                type: "bit",
                nullable: false,
                oldClrType: typeof(bool),
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_TimeProjetos",
                table: "TimeProjetos",
                columns: new[] { "IdTime", "IdProjeto" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_ResponsavelProjetos",
                table: "ResponsavelProjetos",
                columns: new[] { "IdPessoa", "IdProjeto" });

            migrationBuilder.AddForeignKey(
                name: "FK_ResponsavelProjetos_Pessoas_IdPessoa",
                table: "ResponsavelProjetos",
                column: "IdPessoa",
                principalTable: "Pessoas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TimeProjetos_Times_IdTime",
                table: "TimeProjetos",
                column: "IdTime",
                principalTable: "Times",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
