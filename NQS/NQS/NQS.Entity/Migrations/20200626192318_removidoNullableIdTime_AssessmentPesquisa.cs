using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Leega.Entity.Migrations
{
    public partial class removidoNullableIdTime_AssessmentPesquisa : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AssessmentPesquisas_Times_IdTime",
                table: "AssessmentPesquisas");

            migrationBuilder.AlterColumn<Guid>(
                name: "IdTime",
                table: "AssessmentPesquisas",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_AssessmentPesquisas_Times_IdTime",
                table: "AssessmentPesquisas",
                column: "IdTime",
                principalTable: "Times",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AssessmentPesquisas_Times_IdTime",
                table: "AssessmentPesquisas");

            migrationBuilder.AlterColumn<Guid>(
                name: "IdTime",
                table: "AssessmentPesquisas",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid));

            migrationBuilder.AddForeignKey(
                name: "FK_AssessmentPesquisas_Times_IdTime",
                table: "AssessmentPesquisas",
                column: "IdTime",
                principalTable: "Times",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
