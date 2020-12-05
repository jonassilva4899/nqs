using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Leega.Entity.Migrations
{
    public partial class teste : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Convites_Pessoas_IdPessoaCriada",
                table: "Convites");

            migrationBuilder.DropForeignKey(
                name: "FK_ConvitesHistorico_Convites_IdConvite",
                table: "ConvitesHistorico");

            migrationBuilder.DropForeignKey(
                name: "FK_ConvitesHistorico_Pessoas_IdPessoaRequisita",
                table: "ConvitesHistorico");

            migrationBuilder.DropForeignKey(
                name: "FK_NotificacaoUsuarios_Notificacoes_IdNotificacao",
                table: "NotificacaoUsuarios");

            migrationBuilder.DropForeignKey(
                name: "FK_PessoaHabilidades_Habilidades_IdHabilidade",
                table: "PessoaHabilidades");

            migrationBuilder.DropTable(
                name: "Acao");

            migrationBuilder.DropTable(
                name: "AssessmentPraticasHistorico");

            migrationBuilder.DropTable(
                name: "AssessmentRespostasCompetencias");

            migrationBuilder.DropTable(
                name: "AssessmentRespostasQuestoes");

            migrationBuilder.DropTable(
                name: "BoxKudoCard");

            migrationBuilder.DropTable(
                name: "CapacityQuadros");

            migrationBuilder.DropTable(
                name: "CardAnexos");

            migrationBuilder.DropTable(
                name: "CardComentarios");

            migrationBuilder.DropTable(
                name: "CardEtiquetas");

            migrationBuilder.DropTable(
                name: "CardLogs");

            migrationBuilder.DropTable(
                name: "Checkpoints");

            migrationBuilder.DropTable(
                name: "CompetenciaPraticas");

            migrationBuilder.DropTable(
                name: "CompetenciaQuestaoOpcoes");

            migrationBuilder.DropTable(
                name: "Dailies");

            migrationBuilder.DropTable(
                name: "DailyConfiguracoes");

            migrationBuilder.DropTable(
                name: "DelegationBoards");

            migrationBuilder.DropTable(
                name: "DicaAgileCoachCategorias");

            migrationBuilder.DropTable(
                name: "EnpsRespostas");

            migrationBuilder.DropTable(
                name: "Habilidades");

            migrationBuilder.DropTable(
                name: "Indicadores");

            migrationBuilder.DropTable(
                name: "LeadtimeManuais");

            migrationBuilder.DropTable(
                name: "LeadtimeQuadros");

            migrationBuilder.DropTable(
                name: "MelhoriasContinuas");

            migrationBuilder.DropTable(
                name: "MovimentoQuadros");

            migrationBuilder.DropTable(
                name: "NotificacaoPraticasAgeis");

            migrationBuilder.DropTable(
                name: "PessoaMotivadores");

            migrationBuilder.DropTable(
                name: "PlanningConfiguracoes");

            migrationBuilder.DropTable(
                name: "PlanningObjetivos");

            migrationBuilder.DropTable(
                name: "PortfolioAcoes");

            migrationBuilder.DropTable(
                name: "PraticasAgeisTimes");

            migrationBuilder.DropTable(
                name: "ProjetoPortfolioMetas");

            migrationBuilder.DropTable(
                name: "ResponsavelCards");

            migrationBuilder.DropTable(
                name: "ResponsavelProjetos");

            migrationBuilder.DropTable(
                name: "Retrospectiva");

            migrationBuilder.DropTable(
                name: "RetrospectivaConfiguracao");

            migrationBuilder.DropTable(
                name: "ReviewConfiguracoes");

            migrationBuilder.DropTable(
                name: "Reviews");

            migrationBuilder.DropTable(
                name: "Seguidores");

            migrationBuilder.DropTable(
                name: "SentimentosPessoas");

            migrationBuilder.DropTable(
                name: "ThroughputManuais");

            migrationBuilder.DropTable(
                name: "ThroughputQuadros");

            migrationBuilder.DropTable(
                name: "TimeDicasAgileCoach");

            migrationBuilder.DropTable(
                name: "TimeProjetos");

            migrationBuilder.DropTable(
                name: "AssessmentPesquisaQuestoes");

            migrationBuilder.DropTable(
                name: "KudoCards");

            migrationBuilder.DropTable(
                name: "CapacityConfiguracoes");

            migrationBuilder.DropTable(
                name: "Etiquetas");

            migrationBuilder.DropTable(
                name: "Dominios");

            migrationBuilder.DropTable(
                name: "Categorias");

            migrationBuilder.DropTable(
                name: "EnpsPesquisaPerguntas");

            migrationBuilder.DropTable(
                name: "Leadtimes");

            migrationBuilder.DropTable(
                name: "MovimentoConfiguracoes");

            migrationBuilder.DropTable(
                name: "Motivadores");

            migrationBuilder.DropTable(
                name: "PraticasAgeis");

            migrationBuilder.DropTable(
                name: "PortfolioMetas");

            migrationBuilder.DropTable(
                name: "ColunaCards");

            migrationBuilder.DropTable(
                name: "TecnicaRestrospectiva");

            migrationBuilder.DropTable(
                name: "Plannings");

            migrationBuilder.DropTable(
                name: "Throughputs");

            migrationBuilder.DropTable(
                name: "DicasAgileCoach");

            migrationBuilder.DropTable(
                name: "AssessmentPesquisaCompetencias");

            migrationBuilder.DropTable(
                name: "CompetenciaQuestoes");

            migrationBuilder.DropTable(
                name: "EnpsPerguntas");

            migrationBuilder.DropTable(
                name: "EnpsPesquisas");

            migrationBuilder.DropTable(
                name: "PortfolioObjetivos");

            migrationBuilder.DropTable(
                name: "Epicos");

            migrationBuilder.DropTable(
                name: "Iteracoes");

            migrationBuilder.DropTable(
                name: "QuadroColunas");

            migrationBuilder.DropTable(
                name: "TecnicasPlannings");

            migrationBuilder.DropTable(
                name: "AssessmentPesquisas");

            migrationBuilder.DropTable(
                name: "Competencias");

            migrationBuilder.DropTable(
                name: "Projetos");

            migrationBuilder.DropTable(
                name: "Quadros");

            migrationBuilder.DropIndex(
                name: "IX_PessoaHabilidades_IdHabilidade",
                table: "PessoaHabilidades");

            migrationBuilder.DropIndex(
                name: "IX_ConvitesHistorico_IdConvite",
                table: "ConvitesHistorico");

            migrationBuilder.DropIndex(
                name: "IX_ConvitesHistorico_IdPessoaRequisita",
                table: "ConvitesHistorico");

            migrationBuilder.DropIndex(
                name: "IX_Convites_IdPessoaCriada",
                table: "Convites");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Notificacoes",
                table: "Notificacoes");

            migrationBuilder.RenameTable(
                name: "Notificacoes",
                newName: "Notificacao");

            migrationBuilder.AddColumn<Guid>(
                name: "NotificacaoId",
                table: "NotificacaoUsuarios",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "ConviteId",
                table: "ConvitesHistorico",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "PessoaRequisitaId",
                table: "ConvitesHistorico",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "PessoaCriadaId",
                table: "Convites",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Notificacao",
                table: "Notificacao",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_NotificacaoUsuarios_NotificacaoId",
                table: "NotificacaoUsuarios",
                column: "NotificacaoId");

            migrationBuilder.CreateIndex(
                name: "IX_ConvitesHistorico_ConviteId",
                table: "ConvitesHistorico",
                column: "ConviteId");

            migrationBuilder.CreateIndex(
                name: "IX_ConvitesHistorico_PessoaRequisitaId",
                table: "ConvitesHistorico",
                column: "PessoaRequisitaId");

            migrationBuilder.CreateIndex(
                name: "IX_Convites_PessoaCriadaId",
                table: "Convites",
                column: "PessoaCriadaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Convites_Pessoas_PessoaCriadaId",
                table: "Convites",
                column: "PessoaCriadaId",
                principalTable: "Pessoas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ConvitesHistorico_Convites_ConviteId",
                table: "ConvitesHistorico",
                column: "ConviteId",
                principalTable: "Convites",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ConvitesHistorico_Pessoas_PessoaRequisitaId",
                table: "ConvitesHistorico",
                column: "PessoaRequisitaId",
                principalTable: "Pessoas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_NotificacaoUsuarios_Notificacao_NotificacaoId",
                table: "NotificacaoUsuarios",
                column: "NotificacaoId",
                principalTable: "Notificacao",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Convites_Pessoas_PessoaCriadaId",
                table: "Convites");

            migrationBuilder.DropForeignKey(
                name: "FK_ConvitesHistorico_Convites_ConviteId",
                table: "ConvitesHistorico");

            migrationBuilder.DropForeignKey(
                name: "FK_ConvitesHistorico_Pessoas_PessoaRequisitaId",
                table: "ConvitesHistorico");

            migrationBuilder.DropForeignKey(
                name: "FK_NotificacaoUsuarios_Notificacao_NotificacaoId",
                table: "NotificacaoUsuarios");

            migrationBuilder.DropIndex(
                name: "IX_NotificacaoUsuarios_NotificacaoId",
                table: "NotificacaoUsuarios");

            migrationBuilder.DropIndex(
                name: "IX_ConvitesHistorico_ConviteId",
                table: "ConvitesHistorico");

            migrationBuilder.DropIndex(
                name: "IX_ConvitesHistorico_PessoaRequisitaId",
                table: "ConvitesHistorico");

            migrationBuilder.DropIndex(
                name: "IX_Convites_PessoaCriadaId",
                table: "Convites");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Notificacao",
                table: "Notificacao");

            migrationBuilder.DropColumn(
                name: "NotificacaoId",
                table: "NotificacaoUsuarios");

            migrationBuilder.DropColumn(
                name: "ConviteId",
                table: "ConvitesHistorico");

            migrationBuilder.DropColumn(
                name: "PessoaRequisitaId",
                table: "ConvitesHistorico");

            migrationBuilder.DropColumn(
                name: "PessoaCriadaId",
                table: "Convites");

            migrationBuilder.RenameTable(
                name: "Notificacao",
                newName: "Notificacoes");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Notificacoes",
                table: "Notificacoes",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "Acao",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Data = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DataCriacao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DataEdicao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DetalheAcao = table.Column<string>(type: "VARCHAR(MAX)", nullable: true),
                    IdOrganizacao = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IdPessoaCriacao = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IdResponsavel = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    NomeAcao = table.Column<string>(type: "VARCHAR(100)", nullable: true),
                    ResponsavelCriacao = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ResponsavelEdicao = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Acao", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Acao_Pessoas_IdPessoaCriacao",
                        column: x => x.IdPessoaCriacao,
                        principalTable: "Pessoas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Acao_Pessoas_IdResponsavel",
                        column: x => x.IdResponsavel,
                        principalTable: "Pessoas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AssessmentPesquisas",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ApenasUsuarios = table.Column<bool>(type: "bit", nullable: false),
                    DataCriacao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DataEdicao = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IdOrganizacao = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IdTime = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ResponsavelCriacao = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ResponsavelEdicao = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AssessmentPesquisas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AssessmentPesquisas_Organizacoes_IdOrganizacao",
                        column: x => x.IdOrganizacao,
                        principalTable: "Organizacoes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AssessmentPesquisas_Times_IdTime",
                        column: x => x.IdTime,
                        principalTable: "Times",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CapacityConfiguracoes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CaminhoExcel = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DataCriacao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DataEdicao = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IdOrganizacao = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IdTime = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ResponsavelCriacao = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ResponsavelEdicao = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Tipo = table.Column<int>(type: "int", nullable: false),
                    ValorManual = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CapacityConfiguracoes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CapacityConfiguracoes_Times_IdTime",
                        column: x => x.IdTime,
                        principalTable: "Times",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Categorias",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DataCriacao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IdOrganizacao = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nome = table.Column<string>(type: "VARCHAR(100)", nullable: true),
                    ResponsavelCriacao = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categorias", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Checkpoints",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DataAgendamento = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DataCriacao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DataEdicao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DataRealizacao = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IdAnalista = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IdOrganizacao = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IdPessoa = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Observacoes = table.Column<string>(type: "VARCHAR(1000)", nullable: true),
                    ResponsavelCriacao = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ResponsavelEdicao = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SentimentoColaborador = table.Column<int>(type: "int", nullable: false),
                    SentimentoRhAgil = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Checkpoints", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Checkpoints_Pessoas_IdAnalista",
                        column: x => x.IdAnalista,
                        principalTable: "Pessoas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Checkpoints_Pessoas_IdPessoa",
                        column: x => x.IdPessoa,
                        principalTable: "Pessoas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Competencias",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Ativo = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    DataCriacao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DataEdicao = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Descricao = table.Column<string>(type: "VARCHAR(3000)", nullable: true),
                    IdOrganizacao = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nome = table.Column<string>(type: "VARCHAR(100)", nullable: true),
                    ResponsavelCriacao = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ResponsavelEdicao = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Competencias", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Dailies",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DataCriacao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DataEdicao = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DataHoraRegistro = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IdOrganizacao = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IdResponsavelRegistro = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IdTime = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Observacao = table.Column<string>(type: "VARCHAR(1000)", nullable: true),
                    ResponsavelCriacao = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ResponsavelEdicao = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dailies", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Dailies_Pessoas_IdResponsavelRegistro",
                        column: x => x.IdResponsavelRegistro,
                        principalTable: "Pessoas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Dailies_Times_IdTime",
                        column: x => x.IdTime,
                        principalTable: "Times",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DailyConfiguracoes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DataCriacao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DataEdicao = table.Column<DateTime>(type: "datetime2", nullable: true),
                    HorarioDaily = table.Column<string>(type: "VARCHAR(10)", nullable: true),
                    IdOrganizacao = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IdTime = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ResponsavelCriacao = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ResponsavelEdicao = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DailyConfiguracoes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DailyConfiguracoes_Times_IdTime",
                        column: x => x.IdTime,
                        principalTable: "Times",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DicasAgileCoach",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DataCriacao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DataEdicao = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Descricao = table.Column<string>(type: "VARCHAR(2000)", nullable: true),
                    IdOrganizacao = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ResponsavelCriacao = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ResponsavelEdicao = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Tema = table.Column<string>(type: "VARCHAR(100)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DicasAgileCoach", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Dominios",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DataCriacao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IdOrganizacao = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nome = table.Column<string>(type: "VARCHAR(100)", nullable: true),
                    ResponsavelCriacao = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dominios", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "EnpsPerguntas",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DataCriacao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DataEdicao = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ResponsavelCriacao = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ResponsavelEdicao = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Texto = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EnpsPerguntas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "EnpsPesquisas",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DataCriacao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DataEdicao = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Descricao = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IdOrganizacao = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IdTime = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ResponsavelCriacao = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ResponsavelEdicao = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    SomenteMembros = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EnpsPesquisas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EnpsPesquisas_Organizacoes_IdOrganizacao",
                        column: x => x.IdOrganizacao,
                        principalTable: "Organizacoes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EnpsPesquisas_Times_IdTime",
                        column: x => x.IdTime,
                        principalTable: "Times",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Etiquetas",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Cor = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DataCriacao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IdOrganizacao = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nome = table.Column<string>(type: "VARCHAR(50)", nullable: true),
                    ResponsavelCriacao = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Etiquetas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Habilidades",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DataCriacao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IdOrganizacao = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nome = table.Column<string>(type: "VARCHAR(100)", nullable: true),
                    ResponsavelCriacao = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Habilidades", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Indicadores",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CaminhoExcel = table.Column<string>(type: "VARCHAR(500)", nullable: true),
                    DataCriacao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DataEdicao = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ExibeDashPratica = table.Column<bool>(type: "bit", nullable: false),
                    IdOrganizacao = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IdTime = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ResponsavelCriacao = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ResponsavelEdicao = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Tipo = table.Column<int>(type: "int", nullable: true),
                    TipoCalculo = table.Column<int>(type: "int", nullable: true),
                    Titulo = table.Column<string>(type: "VARCHAR(100)", nullable: true),
                    ValorOpcionalDois = table.Column<string>(type: "VARCHAR(100)", nullable: true),
                    ValorOpcionalUm = table.Column<string>(type: "VARCHAR(100)", nullable: true),
                    ValorPrincipal = table.Column<string>(type: "VARCHAR(100)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Indicadores", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Indicadores_Times_IdTime",
                        column: x => x.IdTime,
                        principalTable: "Times",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Iteracoes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DataCriacao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IdOrganizacao = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nome = table.Column<string>(type: "VARCHAR(50)", nullable: true),
                    ResponsavelCriacao = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Iteracoes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "KudoCards",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DataCriacao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DataEdicao = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IdOrganizacao = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Mensagem = table.Column<string>(type: "VARCHAR(50)", nullable: true),
                    ResponsavelCriacao = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ResponsavelEdicao = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Tipo = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KudoCards", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Leadtimes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DataCriacao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DataEdicao = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IdOrganizacao = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IdTime = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ResponsavelCriacao = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ResponsavelEdicao = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Tipo = table.Column<int>(type: "int", nullable: false),
                    UrlPlanilha = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Leadtimes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Leadtimes_Times_IdTime",
                        column: x => x.IdTime,
                        principalTable: "Times",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MelhoriasContinuas",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Acao = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Competencia = table.Column<int>(type: "int", nullable: false),
                    DataCriacao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DataEdicao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DataInclusao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Descricao = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IdOrganizacao = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IdResponsavelMelhoriaContinua = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IdTime = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Origem = table.Column<int>(type: "int", nullable: false),
                    ResponsavelCriacao = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ResponsavelEdicao = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MelhoriasContinuas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MelhoriasContinuas_Pessoas_IdResponsavelMelhoriaContinua",
                        column: x => x.IdResponsavelMelhoriaContinua,
                        principalTable: "Pessoas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MelhoriasContinuas_Times_IdTime",
                        column: x => x.IdTime,
                        principalTable: "Times",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Motivadores",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DataCriacao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Foto = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Nome = table.Column<string>(type: "VARCHAR(30)", nullable: true),
                    ResponsavelCriacao = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Motivadores", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MovimentoConfiguracoes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CaminhoExcel = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DataCriacao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DataEdicao = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IdOrganizacao = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IdTime = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ResponsavelCriacao = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ResponsavelEdicao = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Tipo = table.Column<int>(type: "int", nullable: false),
                    ValorManual = table.Column<string>(type: "VARCHAR(100)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MovimentoConfiguracoes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MovimentoConfiguracoes_Times_IdTime",
                        column: x => x.IdTime,
                        principalTable: "Times",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PlanningConfiguracoes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DataCriacao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DataEdicao = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DataPrecursora = table.Column<DateTime>(type: "datetime2", nullable: false),
                    HorarioPlanning = table.Column<string>(type: "VARCHAR(5)", nullable: true),
                    IdOrganizacao = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IdTime = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Periodicidade = table.Column<int>(type: "int", nullable: false),
                    ProximaData = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ResponsavelCriacao = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ResponsavelEdicao = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    UltimaData = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlanningConfiguracoes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PlanningConfiguracoes_Times_IdTime",
                        column: x => x.IdTime,
                        principalTable: "Times",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PortfolioObjetivos",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Cor = table.Column<string>(type: "VARCHAR(100)", nullable: true),
                    DataCriacao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DataEdicao = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IdOrganizacao = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Objetivo = table.Column<string>(type: "VARCHAR(500)", nullable: true),
                    ResponsavelCriacao = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ResponsavelEdicao = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PortfolioObjetivos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PraticasAgeis",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Ativo = table.Column<bool>(type: "bit", nullable: false),
                    Chave = table.Column<string>(type: "VARCHAR(50)", nullable: true),
                    DataCriacao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Nome = table.Column<string>(type: "VARCHAR(100)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PraticasAgeis", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Projetos",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CategoriaProjeto = table.Column<int>(type: "int", nullable: true),
                    Custo = table.Column<double>(type: "float", nullable: true),
                    DataCriacao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DataEdicao = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DataFim = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DataInicio = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeliveryProjeto = table.Column<int>(type: "int", nullable: true),
                    Descricao = table.Column<string>(type: "VARCHAR(1000)", nullable: false),
                    Esforco = table.Column<int>(type: "int", nullable: true),
                    IdCliente = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IdOrganizacao = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IdResponsavelComercial = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Logo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Nome = table.Column<string>(type: "VARCHAR(50)", nullable: false),
                    Receita = table.Column<double>(type: "float", nullable: true),
                    ResponsavelCriacao = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ResponsavelEdicao = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Status = table.Column<bool>(type: "bit", nullable: true),
                    StatusProjeto = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Projetos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Projetos_Clientes_IdCliente",
                        column: x => x.IdCliente,
                        principalTable: "Clientes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Projetos_Pessoas_IdResponsavelComercial",
                        column: x => x.IdResponsavelComercial,
                        principalTable: "Pessoas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Quadros",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DataCriacao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DataEdicao = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IdOrganizacao = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IdTime = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nome = table.Column<string>(type: "VARCHAR(50)", nullable: true),
                    ResponsavelCriacao = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ResponsavelEdicao = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Quadros", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Quadros_Times_IdTime",
                        column: x => x.IdTime,
                        principalTable: "Times",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RetrospectivaConfiguracao",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DataCriacao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DataEdicao = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DataPrecursora = table.Column<DateTime>(type: "datetime2", nullable: false),
                    HorarioRetrospectiva = table.Column<string>(type: "VARCHAR(5)", nullable: true),
                    IdOrganizacao = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IdTime = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Periodicidade = table.Column<int>(type: "int", nullable: false),
                    ProximaData = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ResponsavelCriacao = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ResponsavelEdicao = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UltimaData = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RetrospectivaConfiguracao", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RetrospectivaConfiguracao_Times_IdTime",
                        column: x => x.IdTime,
                        principalTable: "Times",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ReviewConfiguracoes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DataCriacao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DataEdicao = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DataPrecursora = table.Column<DateTime>(type: "datetime2", nullable: false),
                    HorarioReview = table.Column<string>(type: "VARCHAR(5)", nullable: true),
                    IdOrganizacao = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IdTime = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Periodicidade = table.Column<int>(type: "int", nullable: false),
                    ProximaData = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ResponsavelCriacao = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ResponsavelEdicao = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    UltimaData = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReviewConfiguracoes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ReviewConfiguracoes_Times_IdTime",
                        column: x => x.IdTime,
                        principalTable: "Times",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Seguidores",
                columns: table => new
                {
                    IdTime = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IdUsuario = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DataCriacao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DataEdicao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DataSeguir = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IdOrganizacao = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ResponsavelCriacao = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ResponsavelEdicao = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Seguidores", x => new { x.IdTime, x.IdUsuario });
                    table.ForeignKey(
                        name: "FK_Seguidores_Times_IdTime",
                        column: x => x.IdTime,
                        principalTable: "Times",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Seguidores_Usuarios_IdUsuario",
                        column: x => x.IdUsuario,
                        principalTable: "Usuarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SentimentosPessoas",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DataCriacao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DataEdicao = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DataRealizacao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IdOrganizacao = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IdPessoa = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ResponsavelCriacao = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ResponsavelEdicao = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Sentimento = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SentimentosPessoas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SentimentosPessoas_Pessoas_IdPessoa",
                        column: x => x.IdPessoa,
                        principalTable: "Pessoas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TecnicaRestrospectiva",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Ativo = table.Column<bool>(type: "bit", nullable: false),
                    DataCriacao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DataEdicao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IdOrganizacao = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nome = table.Column<string>(type: "VARCHAR(100)", nullable: true),
                    ResponsavelCriacao = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ResponsavelEdicao = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TecnicaRestrospectiva", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TecnicasPlannings",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Ativo = table.Column<bool>(type: "bit", nullable: false),
                    DataCriacao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DataEdicao = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IdOrganizacao = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nome = table.Column<string>(type: "VARCHAR(100)", nullable: true),
                    ResponsavelCriacao = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ResponsavelEdicao = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TecnicasPlannings", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Throughputs",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CaminhoExcel = table.Column<string>(type: "VARCHAR(250)", nullable: true),
                    DataCriacao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DataEdicao = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IdOrganizacao = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IdTime = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ResponsavelCriacao = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ResponsavelEdicao = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Tipo = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Throughputs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Throughputs_Times_IdTime",
                        column: x => x.IdTime,
                        principalTable: "Times",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AssessmentPesquisaCompetencias",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DataCriacao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IdCompetencia = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IdOrganizacao = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IdPesquisa = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ResponsavelCriacao = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AssessmentPesquisaCompetencias", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AssessmentPesquisaCompetencias_Competencias_IdCompetencia",
                        column: x => x.IdCompetencia,
                        principalTable: "Competencias",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AssessmentPesquisaCompetencias_Organizacoes_IdOrganizacao",
                        column: x => x.IdOrganizacao,
                        principalTable: "Organizacoes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AssessmentPesquisaCompetencias_AssessmentPesquisas_IdPesquisa",
                        column: x => x.IdPesquisa,
                        principalTable: "AssessmentPesquisas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CompetenciaQuestoes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Ativo = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    DataCriacao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DataEdicao = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IdCompetencia = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IdOrganizacao = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ResponsavelCriacao = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ResponsavelEdicao = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    TituloQuestao = table.Column<string>(type: "VARCHAR(1000)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CompetenciaQuestoes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CompetenciaQuestoes_Competencias_IdCompetencia",
                        column: x => x.IdCompetencia,
                        principalTable: "Competencias",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DicaAgileCoachCategorias",
                columns: table => new
                {
                    IdDicaAgileCoach = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IdCategoria = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DataCriacao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IdOrganizacao = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ResponsavelCriacao = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DicaAgileCoachCategorias", x => new { x.IdDicaAgileCoach, x.IdCategoria });
                    table.ForeignKey(
                        name: "FK_DicaAgileCoachCategorias_Categorias_IdCategoria",
                        column: x => x.IdCategoria,
                        principalTable: "Categorias",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DicaAgileCoachCategorias_DicasAgileCoach_IdDicaAgileCoach",
                        column: x => x.IdDicaAgileCoach,
                        principalTable: "DicasAgileCoach",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TimeDicasAgileCoach",
                columns: table => new
                {
                    IdTime = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IdDicaAgileCoach = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DataCriacao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DataEdicao = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DataEnvioDica = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IdOrganizacao = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ResponsavelCriacao = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ResponsavelEdicao = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    StatusDica = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TimeDicasAgileCoach", x => new { x.IdTime, x.IdDicaAgileCoach });
                    table.ForeignKey(
                        name: "FK_TimeDicasAgileCoach_DicasAgileCoach_IdDicaAgileCoach",
                        column: x => x.IdDicaAgileCoach,
                        principalTable: "DicasAgileCoach",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TimeDicasAgileCoach_Times_IdTime",
                        column: x => x.IdTime,
                        principalTable: "Times",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DelegationBoards",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DataCriacao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DataEdicao = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IdDominio = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IdOrganizacao = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IdResponsavelTime = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IdSupervisor = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IdTime = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    NivelAutoridade = table.Column<int>(type: "int", nullable: false),
                    Observacao = table.Column<string>(type: "VARCHAR(1000)", nullable: true),
                    ResponsavelCriacao = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ResponsavelEdicao = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DelegationBoards", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DelegationBoards_Dominios_IdDominio",
                        column: x => x.IdDominio,
                        principalTable: "Dominios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DelegationBoards_Pessoas_IdResponsavelTime",
                        column: x => x.IdResponsavelTime,
                        principalTable: "Pessoas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DelegationBoards_Pessoas_IdSupervisor",
                        column: x => x.IdSupervisor,
                        principalTable: "Pessoas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DelegationBoards_Times_IdTime",
                        column: x => x.IdTime,
                        principalTable: "Times",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EnpsPesquisaPerguntas",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IdPergunta = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IdPesquisa = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Ordem = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EnpsPesquisaPerguntas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EnpsPesquisaPerguntas_EnpsPerguntas_IdPergunta",
                        column: x => x.IdPergunta,
                        principalTable: "EnpsPerguntas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_EnpsPesquisaPerguntas_EnpsPesquisas_IdPesquisa",
                        column: x => x.IdPesquisa,
                        principalTable: "EnpsPesquisas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "BoxKudoCard",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DataCriacao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DataEnvio = table.Column<DateTime>(type: "datetime2", nullable: false),
                    De = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IdKudoCard = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IdOrganizacao = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IdTime = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Mensagem = table.Column<string>(type: "VARCHAR(1000)", nullable: true),
                    Para = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ResponsavelCriacao = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Tipo = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BoxKudoCard", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BoxKudoCard_Pessoas_De",
                        column: x => x.De,
                        principalTable: "Pessoas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BoxKudoCard_KudoCards_IdKudoCard",
                        column: x => x.IdKudoCard,
                        principalTable: "KudoCards",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BoxKudoCard_Times_IdTime",
                        column: x => x.IdTime,
                        principalTable: "Times",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_BoxKudoCard_Pessoas_Para",
                        column: x => x.Para,
                        principalTable: "Pessoas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "LeadtimeManuais",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DataMes = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IdLeadtime = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Valor = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LeadtimeManuais", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LeadtimeManuais_Leadtimes_IdLeadtime",
                        column: x => x.IdLeadtime,
                        principalTable: "Leadtimes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PessoaMotivadores",
                columns: table => new
                {
                    IdPessoa = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IdMotivador = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DataCriacao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DataEdicao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IdOrganizacao = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Indice = table.Column<int>(type: "int", nullable: false),
                    ResponsavelCriacao = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ResponsavelEdicao = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PessoaMotivadores", x => new { x.IdPessoa, x.IdMotivador });
                    table.ForeignKey(
                        name: "FK_PessoaMotivadores_Motivadores_IdMotivador",
                        column: x => x.IdMotivador,
                        principalTable: "Motivadores",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PessoaMotivadores_Pessoas_IdPessoa",
                        column: x => x.IdPessoa,
                        principalTable: "Pessoas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PortfolioMetas",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Ativo = table.Column<bool>(type: "bit", nullable: false),
                    DataCriacao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DataEdicao = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IdOrganizacao = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IdPortfolioObjetivo = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Meta = table.Column<string>(type: "VARCHAR(500)", nullable: true),
                    Periodo = table.Column<string>(type: "VARCHAR(10)", nullable: true),
                    Realizado = table.Column<string>(type: "VARCHAR(100)", nullable: true),
                    ResponsavelCriacao = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ResponsavelEdicao = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PortfolioMetas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PortfolioMetas_PortfolioObjetivos_IdPortfolioObjetivo",
                        column: x => x.IdPortfolioObjetivo,
                        principalTable: "PortfolioObjetivos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AssessmentPraticasHistorico",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DataCriacao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IdOrganizacao = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IdPesquisa = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IdPraticaAgil = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PontoTemperatura = table.Column<int>(type: "int", nullable: false),
                    ResponsavelCriacao = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AssessmentPraticasHistorico", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AssessmentPraticasHistorico_Organizacoes_IdOrganizacao",
                        column: x => x.IdOrganizacao,
                        principalTable: "Organizacoes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AssessmentPraticasHistorico_AssessmentPesquisas_IdPesquisa",
                        column: x => x.IdPesquisa,
                        principalTable: "AssessmentPesquisas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AssessmentPraticasHistorico_PraticasAgeis_IdPraticaAgil",
                        column: x => x.IdPraticaAgil,
                        principalTable: "PraticasAgeis",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CompetenciaPraticas",
                columns: table => new
                {
                    IdCompetencia = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IdPraticaAgil = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DataCriacao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IdOrganizacao = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ResponsavelCriacao = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CompetenciaPraticas", x => new { x.IdCompetencia, x.IdPraticaAgil });
                    table.ForeignKey(
                        name: "FK_CompetenciaPraticas_Competencias_IdCompetencia",
                        column: x => x.IdCompetencia,
                        principalTable: "Competencias",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CompetenciaPraticas_PraticasAgeis_IdPraticaAgil",
                        column: x => x.IdPraticaAgil,
                        principalTable: "PraticasAgeis",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "NotificacaoPraticasAgeis",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AntecedenciaMin = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IdOrganizacao = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IdPraticaAgil = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IdTime = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PosterioridadeMin = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NotificacaoPraticasAgeis", x => x.Id);
                    table.ForeignKey(
                        name: "FK_NotificacaoPraticasAgeis_PraticasAgeis_IdPraticaAgil",
                        column: x => x.IdPraticaAgil,
                        principalTable: "PraticasAgeis",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_NotificacaoPraticasAgeis_Times_IdTime",
                        column: x => x.IdTime,
                        principalTable: "Times",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PraticasAgeisTimes",
                columns: table => new
                {
                    IdPraticaAgil = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IdTime = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DataCriacao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DataEdicao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DataInicio = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Engajamento = table.Column<int>(type: "int", nullable: false),
                    IdOrganizacao = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ResponsavelCriacao = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ResponsavelEdicao = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Status = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PraticasAgeisTimes", x => new { x.IdPraticaAgil, x.IdTime });
                    table.ForeignKey(
                        name: "FK_PraticasAgeisTimes_PraticasAgeis_IdPraticaAgil",
                        column: x => x.IdPraticaAgil,
                        principalTable: "PraticasAgeis",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PraticasAgeisTimes_Times_IdTime",
                        column: x => x.IdTime,
                        principalTable: "Times",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Epicos",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DataCriacao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DataEdicao = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DataEntrega = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Descricao = table.Column<string>(type: "VARCHAR(2000)", nullable: true),
                    IdOrganizacao = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IdOwner = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IdProjeto = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IdResponsavel = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nome = table.Column<string>(type: "VARCHAR(100)", nullable: true),
                    ResponsavelCriacao = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ResponsavelEdicao = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Status = table.Column<int>(type: "int", nullable: false),
                    Tamanho = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Epicos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Epicos_Pessoas_IdOwner",
                        column: x => x.IdOwner,
                        principalTable: "Pessoas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Epicos_Projetos_IdProjeto",
                        column: x => x.IdProjeto,
                        principalTable: "Projetos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Epicos_Pessoas_IdResponsavel",
                        column: x => x.IdResponsavel,
                        principalTable: "Pessoas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ResponsavelProjetos",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NEWID()"),
                    Ativo = table.Column<bool>(type: "bit", nullable: true),
                    DataCriacao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DataEdicao = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IdOrganizacao = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IdPessoa = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IdProjeto = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ResponsavelCriacao = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ResponsavelEdicao = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ResponsavelProjetos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ResponsavelProjetos_Pessoas_IdPessoa",
                        column: x => x.IdPessoa,
                        principalTable: "Pessoas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ResponsavelProjetos_Projetos_IdProjeto",
                        column: x => x.IdProjeto,
                        principalTable: "Projetos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TimeProjetos",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NEWID()"),
                    Ativo = table.Column<bool>(type: "bit", nullable: true),
                    DataCriacao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DataEdicao = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IdOrganizacao = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IdProjeto = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IdTime = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ResponsavelCriacao = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ResponsavelEdicao = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TimeProjetos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TimeProjetos_Projetos_IdProjeto",
                        column: x => x.IdProjeto,
                        principalTable: "Projetos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TimeProjetos_Times_IdTime",
                        column: x => x.IdTime,
                        principalTable: "Times",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CapacityQuadros",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DataCriacao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IdCapacityConfiguracao = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IdOrganizacao = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IdQuadro = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ResponsavelCriacao = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CapacityQuadros", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CapacityQuadros_CapacityConfiguracoes_IdCapacityConfiguracao",
                        column: x => x.IdCapacityConfiguracao,
                        principalTable: "CapacityConfiguracoes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CapacityQuadros_Quadros_IdQuadro",
                        column: x => x.IdQuadro,
                        principalTable: "Quadros",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "LeadtimeQuadros",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IdLeadtime = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IdQuadro = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LeadtimeQuadros", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LeadtimeQuadros_Leadtimes_IdLeadtime",
                        column: x => x.IdLeadtime,
                        principalTable: "Leadtimes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LeadtimeQuadros_Quadros_IdQuadro",
                        column: x => x.IdQuadro,
                        principalTable: "Quadros",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "MovimentoQuadros",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DataCriacao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IdMovimentoConfiguracao = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IdOrganizacao = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IdQuadro = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ResponsavelCriacao = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MovimentoQuadros", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MovimentoQuadros_MovimentoConfiguracoes_IdMovimentoConfiguracao",
                        column: x => x.IdMovimentoConfiguracao,
                        principalTable: "MovimentoConfiguracoes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MovimentoQuadros_Quadros_IdQuadro",
                        column: x => x.IdQuadro,
                        principalTable: "Quadros",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "QuadroColunas",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DataCriacao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DataEdicao = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IdOrganizacao = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IdQuadro = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Indice = table.Column<int>(type: "int", nullable: false),
                    Nome = table.Column<string>(type: "VARCHAR(50)", nullable: true),
                    ResponsavelCriacao = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ResponsavelEdicao = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    TipoColuna = table.Column<int>(type: "int", nullable: true),
                    WipLimit = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QuadroColunas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_QuadroColunas_Quadros_IdQuadro",
                        column: x => x.IdQuadro,
                        principalTable: "Quadros",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Retrospectiva",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DataCriacao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DataEdicao = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DataHoraRegistro = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IdOrganizacao = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IdResponsavelRegistro = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IdTecnicaUtilizada = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IdTime = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Observacao = table.Column<string>(type: "VARCHAR(1000)", nullable: true),
                    ResponsavelCriacao = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ResponsavelEdicao = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Retrospectiva", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Retrospectiva_Pessoas_IdResponsavelRegistro",
                        column: x => x.IdResponsavelRegistro,
                        principalTable: "Pessoas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Retrospectiva_TecnicaRestrospectiva_IdTecnicaUtilizada",
                        column: x => x.IdTecnicaUtilizada,
                        principalTable: "TecnicaRestrospectiva",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Retrospectiva_Times_IdTime",
                        column: x => x.IdTime,
                        principalTable: "Times",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Plannings",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DataCriacao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DataEdicao = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DataHoraRegistro = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IdOrganizacao = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IdResponsavelRegistro = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IdTecnicaUtilizada = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IdTime = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Observacao = table.Column<string>(type: "VARCHAR(2000)", nullable: true),
                    ResponsavelCriacao = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ResponsavelEdicao = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Plannings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Plannings_Pessoas_IdResponsavelRegistro",
                        column: x => x.IdResponsavelRegistro,
                        principalTable: "Pessoas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Plannings_TecnicasPlannings_IdTecnicaUtilizada",
                        column: x => x.IdTecnicaUtilizada,
                        principalTable: "TecnicasPlannings",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Plannings_Times_IdTime",
                        column: x => x.IdTime,
                        principalTable: "Times",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ThroughputManuais",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DataMes = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IdThroughput = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Valor = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ThroughputManuais", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ThroughputManuais_Throughputs_IdThroughput",
                        column: x => x.IdThroughput,
                        principalTable: "Throughputs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ThroughputQuadros",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IdQuadro = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IdThroughput = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ThroughputQuadros", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ThroughputQuadros_Quadros_IdQuadro",
                        column: x => x.IdQuadro,
                        principalTable: "Quadros",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ThroughputQuadros_Throughputs_IdThroughput",
                        column: x => x.IdThroughput,
                        principalTable: "Throughputs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AssessmentRespostasCompetencias",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DataCriacao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DataEdicao = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IdOrganizacao = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IdPesquisaCompetencia = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IdPessoa = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Observacao = table.Column<string>(type: "VARCHAR(2000)", nullable: true),
                    ResponsavelCriacao = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ResponsavelEdicao = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AssessmentRespostasCompetencias", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AssessmentRespostasCompetencias_Organizacoes_IdOrganizacao",
                        column: x => x.IdOrganizacao,
                        principalTable: "Organizacoes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AssessmentRespostasCompetencias_AssessmentPesquisaCompetencias_IdPesquisaCompetencia",
                        column: x => x.IdPesquisaCompetencia,
                        principalTable: "AssessmentPesquisaCompetencias",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AssessmentRespostasCompetencias_Pessoas_IdPessoa",
                        column: x => x.IdPessoa,
                        principalTable: "Pessoas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AssessmentPesquisaQuestoes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DataCriacao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IdOrganizacao = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IdPesquisaCompetencia = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IdQuestao = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Ordem = table.Column<int>(type: "int", nullable: false),
                    ResponsavelCriacao = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AssessmentPesquisaQuestoes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AssessmentPesquisaQuestoes_Organizacoes_IdOrganizacao",
                        column: x => x.IdOrganizacao,
                        principalTable: "Organizacoes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AssessmentPesquisaQuestoes_AssessmentPesquisaCompetencias_IdPesquisaCompetencia",
                        column: x => x.IdPesquisaCompetencia,
                        principalTable: "AssessmentPesquisaCompetencias",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AssessmentPesquisaQuestoes_CompetenciaQuestoes_IdQuestao",
                        column: x => x.IdQuestao,
                        principalTable: "CompetenciaQuestoes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CompetenciaQuestaoOpcoes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DataCriacao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DataEdicao = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Descricao = table.Column<string>(type: "VARCHAR(1000)", nullable: true),
                    IdCompetenciaQuestao = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IdOrganizacao = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ResponsavelCriacao = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ResponsavelEdicao = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    TemperaturaTermometro = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CompetenciaQuestaoOpcoes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CompetenciaQuestaoOpcoes_CompetenciaQuestoes_IdCompetenciaQuestao",
                        column: x => x.IdCompetenciaQuestao,
                        principalTable: "CompetenciaQuestoes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EnpsRespostas",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DataCriacao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DataEdicao = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IdOrganizacao = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IdPesquisaPergunta = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IdPessoa = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ResponsavelCriacao = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ResponsavelEdicao = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Resposta = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EnpsRespostas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EnpsRespostas_Organizacoes_IdOrganizacao",
                        column: x => x.IdOrganizacao,
                        principalTable: "Organizacoes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EnpsRespostas_EnpsPesquisaPerguntas_IdPesquisaPergunta",
                        column: x => x.IdPesquisaPergunta,
                        principalTable: "EnpsPesquisaPerguntas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EnpsRespostas_Pessoas_IdPessoa",
                        column: x => x.IdPessoa,
                        principalTable: "Pessoas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PortfolioAcoes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DataCriacao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DataEdicao = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Descricao = table.Column<string>(type: "VARCHAR(5000)", nullable: true),
                    IdOrganizacao = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IdPessoaResponsavel = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IdPortfolioMeta = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nome = table.Column<string>(type: "VARCHAR(250)", nullable: true),
                    ResponsavelCriacao = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ResponsavelEdicao = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PortfolioAcoes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PortfolioAcoes_Pessoas_IdPessoaResponsavel",
                        column: x => x.IdPessoaResponsavel,
                        principalTable: "Pessoas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PortfolioAcoes_PortfolioMetas_IdPortfolioMeta",
                        column: x => x.IdPortfolioMeta,
                        principalTable: "PortfolioMetas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProjetoPortfolioMetas",
                columns: table => new
                {
                    IdProjeto = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IdPortfolioMeta = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DataCriacao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IdOrganizacao = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ResponsavelCriacao = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProjetoPortfolioMetas", x => new { x.IdProjeto, x.IdPortfolioMeta });
                    table.ForeignKey(
                        name: "FK_ProjetoPortfolioMetas_PortfolioMetas_IdPortfolioMeta",
                        column: x => x.IdPortfolioMeta,
                        principalTable: "PortfolioMetas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProjetoPortfolioMetas_Projetos_IdProjeto",
                        column: x => x.IdProjeto,
                        principalTable: "Projetos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ColunaCards",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Bloqueado = table.Column<bool>(type: "bit", nullable: false),
                    DataCriacao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DataEdicao = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Descricao = table.Column<string>(type: "VARCHAR(2000)", nullable: true),
                    IdEpico = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IdIteracao = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IdOrganizacao = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IdProjeto = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IdQuadroColuna = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Indice = table.Column<int>(type: "int", nullable: false),
                    MotivoBloqueio = table.Column<string>(type: "VARCHAR(1000)", nullable: true),
                    Nome = table.Column<string>(type: "VARCHAR(100)", nullable: true),
                    Pontuacao = table.Column<int>(type: "int", nullable: true),
                    ResponsavelCriacao = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ResponsavelEdicao = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ColunaCards", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ColunaCards_Epicos_IdEpico",
                        column: x => x.IdEpico,
                        principalTable: "Epicos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ColunaCards_Iteracoes_IdIteracao",
                        column: x => x.IdIteracao,
                        principalTable: "Iteracoes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ColunaCards_Projetos_IdProjeto",
                        column: x => x.IdProjeto,
                        principalTable: "Projetos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ColunaCards_QuadroColunas_IdQuadroColuna",
                        column: x => x.IdQuadroColuna,
                        principalTable: "QuadroColunas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PlanningObjetivos",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DataCriacao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DataEdicao = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IdOrganizacao = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IdPalnning = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Objetivo = table.Column<string>(type: "VARCHAR(500)", nullable: true),
                    ResponsavelCriacao = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ResponsavelEdicao = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    StatusObjetivo = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlanningObjetivos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PlanningObjetivos_Plannings_IdPalnning",
                        column: x => x.IdPalnning,
                        principalTable: "Plannings",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Reviews",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DataCriacao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DataEdicao = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DataHoraRegistro = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IdOrganizacao = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IdPlanning = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IdResponsavelRegistro = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IdTime = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Observacao = table.Column<string>(type: "VARCHAR(2000)", nullable: true),
                    ResponsavelCriacao = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ResponsavelEdicao = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reviews", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Reviews_Plannings_IdPlanning",
                        column: x => x.IdPlanning,
                        principalTable: "Plannings",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Reviews_Pessoas_IdResponsavelRegistro",
                        column: x => x.IdResponsavelRegistro,
                        principalTable: "Pessoas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Reviews_Times_IdTime",
                        column: x => x.IdTime,
                        principalTable: "Times",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AssessmentRespostasQuestoes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DataCriacao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DataEdicao = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IdOrganizacao = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IdPesquisaQuestao = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IdPessoa = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ResponsavelCriacao = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ResponsavelEdicao = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Resposta = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AssessmentRespostasQuestoes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AssessmentRespostasQuestoes_Organizacoes_IdOrganizacao",
                        column: x => x.IdOrganizacao,
                        principalTable: "Organizacoes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AssessmentRespostasQuestoes_AssessmentPesquisaQuestoes_IdPesquisaQuestao",
                        column: x => x.IdPesquisaQuestao,
                        principalTable: "AssessmentPesquisaQuestoes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AssessmentRespostasQuestoes_Pessoas_IdPessoa",
                        column: x => x.IdPessoa,
                        principalTable: "Pessoas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CardAnexos",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CaminhoArquivo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DataCriacao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IdColunaCard = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IdOrganizacao = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IdPessoa = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nome = table.Column<string>(type: "VARCHAR(100)", nullable: true),
                    ResponsavelCriacao = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CardAnexos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CardAnexos_ColunaCards_IdColunaCard",
                        column: x => x.IdColunaCard,
                        principalTable: "ColunaCards",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CardAnexos_Pessoas_IdPessoa",
                        column: x => x.IdPessoa,
                        principalTable: "Pessoas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CardComentarios",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Comentario = table.Column<string>(type: "VARCHAR(1000)", nullable: true),
                    DataCriacao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DataEdicao = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IdColunaCard = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IdOrganizacao = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IdPessoa = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ResponsavelCriacao = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ResponsavelEdicao = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CardComentarios", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CardComentarios_ColunaCards_IdColunaCard",
                        column: x => x.IdColunaCard,
                        principalTable: "ColunaCards",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CardComentarios_Pessoas_IdPessoa",
                        column: x => x.IdPessoa,
                        principalTable: "Pessoas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CardEtiquetas",
                columns: table => new
                {
                    IdColunaCard = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IdEtiqueta = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DataCriacao = table.Column<string>(type: "VARCHAR(30)", nullable: false),
                    DataEdicao = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IdOrganizacao = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ResponsavelCriacao = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ResponsavelEdicao = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CardEtiquetas", x => new { x.IdColunaCard, x.IdEtiqueta });
                    table.ForeignKey(
                        name: "FK_CardEtiquetas_ColunaCards_IdColunaCard",
                        column: x => x.IdColunaCard,
                        principalTable: "ColunaCards",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CardEtiquetas_Etiquetas_IdEtiqueta",
                        column: x => x.IdEtiqueta,
                        principalTable: "Etiquetas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CardLogs",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DataCriacao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DataMovimentacao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IdColunaCard = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IdOrganizacao = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IdPessoaMoveu = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IdQuadroColunaDe = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IdQuadroColunaPara = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ResponsavelCriacao = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CardLogs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CardLogs_ColunaCards_IdColunaCard",
                        column: x => x.IdColunaCard,
                        principalTable: "ColunaCards",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CardLogs_Pessoas_IdPessoaMoveu",
                        column: x => x.IdPessoaMoveu,
                        principalTable: "Pessoas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CardLogs_QuadroColunas_IdQuadroColunaDe",
                        column: x => x.IdQuadroColunaDe,
                        principalTable: "QuadroColunas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CardLogs_QuadroColunas_IdQuadroColunaPara",
                        column: x => x.IdQuadroColunaPara,
                        principalTable: "QuadroColunas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ResponsavelCards",
                columns: table => new
                {
                    IdPessoa = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IdColunaCard = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Ativo = table.Column<bool>(type: "bit", nullable: false),
                    DataCriacao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DataEdicao = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IdOrganizacao = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ResponsavelCriacao = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ResponsavelEdicao = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ResponsavelCards", x => new { x.IdPessoa, x.IdColunaCard });
                    table.ForeignKey(
                        name: "FK_ResponsavelCards_ColunaCards_IdColunaCard",
                        column: x => x.IdColunaCard,
                        principalTable: "ColunaCards",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ResponsavelCards_Pessoas_IdPessoa",
                        column: x => x.IdPessoa,
                        principalTable: "Pessoas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PessoaHabilidades_IdHabilidade",
                table: "PessoaHabilidades",
                column: "IdHabilidade");

            migrationBuilder.CreateIndex(
                name: "IX_ConvitesHistorico_IdConvite",
                table: "ConvitesHistorico",
                column: "IdConvite");

            migrationBuilder.CreateIndex(
                name: "IX_ConvitesHistorico_IdPessoaRequisita",
                table: "ConvitesHistorico",
                column: "IdPessoaRequisita");

            migrationBuilder.CreateIndex(
                name: "IX_Convites_IdPessoaCriada",
                table: "Convites",
                column: "IdPessoaCriada");

            migrationBuilder.CreateIndex(
                name: "IX_Acao_IdPessoaCriacao",
                table: "Acao",
                column: "IdPessoaCriacao");

            migrationBuilder.CreateIndex(
                name: "IX_Acao_IdResponsavel",
                table: "Acao",
                column: "IdResponsavel");

            migrationBuilder.CreateIndex(
                name: "IX_AssessmentPesquisaCompetencias_IdCompetencia",
                table: "AssessmentPesquisaCompetencias",
                column: "IdCompetencia");

            migrationBuilder.CreateIndex(
                name: "IX_AssessmentPesquisaCompetencias_IdOrganizacao",
                table: "AssessmentPesquisaCompetencias",
                column: "IdOrganizacao");

            migrationBuilder.CreateIndex(
                name: "IX_AssessmentPesquisaCompetencias_IdPesquisa",
                table: "AssessmentPesquisaCompetencias",
                column: "IdPesquisa");

            migrationBuilder.CreateIndex(
                name: "IX_AssessmentPesquisaQuestoes_IdOrganizacao",
                table: "AssessmentPesquisaQuestoes",
                column: "IdOrganizacao");

            migrationBuilder.CreateIndex(
                name: "IX_AssessmentPesquisaQuestoes_IdPesquisaCompetencia",
                table: "AssessmentPesquisaQuestoes",
                column: "IdPesquisaCompetencia");

            migrationBuilder.CreateIndex(
                name: "IX_AssessmentPesquisaQuestoes_IdQuestao",
                table: "AssessmentPesquisaQuestoes",
                column: "IdQuestao");

            migrationBuilder.CreateIndex(
                name: "IX_AssessmentPesquisas_IdOrganizacao",
                table: "AssessmentPesquisas",
                column: "IdOrganizacao");

            migrationBuilder.CreateIndex(
                name: "IX_AssessmentPesquisas_IdTime",
                table: "AssessmentPesquisas",
                column: "IdTime");

            migrationBuilder.CreateIndex(
                name: "IX_AssessmentPraticasHistorico_IdOrganizacao",
                table: "AssessmentPraticasHistorico",
                column: "IdOrganizacao");

            migrationBuilder.CreateIndex(
                name: "IX_AssessmentPraticasHistorico_IdPesquisa",
                table: "AssessmentPraticasHistorico",
                column: "IdPesquisa");

            migrationBuilder.CreateIndex(
                name: "IX_AssessmentPraticasHistorico_IdPraticaAgil",
                table: "AssessmentPraticasHistorico",
                column: "IdPraticaAgil");

            migrationBuilder.CreateIndex(
                name: "IX_AssessmentRespostasCompetencias_IdOrganizacao",
                table: "AssessmentRespostasCompetencias",
                column: "IdOrganizacao");

            migrationBuilder.CreateIndex(
                name: "IX_AssessmentRespostasCompetencias_IdPesquisaCompetencia",
                table: "AssessmentRespostasCompetencias",
                column: "IdPesquisaCompetencia");

            migrationBuilder.CreateIndex(
                name: "IX_AssessmentRespostasCompetencias_IdPessoa",
                table: "AssessmentRespostasCompetencias",
                column: "IdPessoa");

            migrationBuilder.CreateIndex(
                name: "IX_AssessmentRespostasQuestoes_IdOrganizacao",
                table: "AssessmentRespostasQuestoes",
                column: "IdOrganizacao");

            migrationBuilder.CreateIndex(
                name: "IX_AssessmentRespostasQuestoes_IdPesquisaQuestao",
                table: "AssessmentRespostasQuestoes",
                column: "IdPesquisaQuestao");

            migrationBuilder.CreateIndex(
                name: "IX_AssessmentRespostasQuestoes_IdPessoa",
                table: "AssessmentRespostasQuestoes",
                column: "IdPessoa");

            migrationBuilder.CreateIndex(
                name: "IX_BoxKudoCard_De",
                table: "BoxKudoCard",
                column: "De");

            migrationBuilder.CreateIndex(
                name: "IX_BoxKudoCard_IdKudoCard",
                table: "BoxKudoCard",
                column: "IdKudoCard");

            migrationBuilder.CreateIndex(
                name: "IX_BoxKudoCard_IdTime",
                table: "BoxKudoCard",
                column: "IdTime");

            migrationBuilder.CreateIndex(
                name: "IX_BoxKudoCard_Para",
                table: "BoxKudoCard",
                column: "Para");

            migrationBuilder.CreateIndex(
                name: "IX_CapacityConfiguracoes_IdTime",
                table: "CapacityConfiguracoes",
                column: "IdTime",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_CapacityQuadros_IdCapacityConfiguracao",
                table: "CapacityQuadros",
                column: "IdCapacityConfiguracao");

            migrationBuilder.CreateIndex(
                name: "IX_CapacityQuadros_IdQuadro",
                table: "CapacityQuadros",
                column: "IdQuadro",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_CardAnexos_IdColunaCard",
                table: "CardAnexos",
                column: "IdColunaCard");

            migrationBuilder.CreateIndex(
                name: "IX_CardAnexos_IdPessoa",
                table: "CardAnexos",
                column: "IdPessoa");

            migrationBuilder.CreateIndex(
                name: "IX_CardComentarios_IdColunaCard",
                table: "CardComentarios",
                column: "IdColunaCard");

            migrationBuilder.CreateIndex(
                name: "IX_CardComentarios_IdPessoa",
                table: "CardComentarios",
                column: "IdPessoa");

            migrationBuilder.CreateIndex(
                name: "IX_CardEtiquetas_IdEtiqueta",
                table: "CardEtiquetas",
                column: "IdEtiqueta");

            migrationBuilder.CreateIndex(
                name: "IX_CardLogs_IdColunaCard",
                table: "CardLogs",
                column: "IdColunaCard");

            migrationBuilder.CreateIndex(
                name: "IX_CardLogs_IdPessoaMoveu",
                table: "CardLogs",
                column: "IdPessoaMoveu");

            migrationBuilder.CreateIndex(
                name: "IX_CardLogs_IdQuadroColunaDe",
                table: "CardLogs",
                column: "IdQuadroColunaDe");

            migrationBuilder.CreateIndex(
                name: "IX_CardLogs_IdQuadroColunaPara",
                table: "CardLogs",
                column: "IdQuadroColunaPara");

            migrationBuilder.CreateIndex(
                name: "IX_Checkpoints_IdAnalista",
                table: "Checkpoints",
                column: "IdAnalista");

            migrationBuilder.CreateIndex(
                name: "IX_Checkpoints_IdPessoa",
                table: "Checkpoints",
                column: "IdPessoa");

            migrationBuilder.CreateIndex(
                name: "IX_ColunaCards_IdEpico",
                table: "ColunaCards",
                column: "IdEpico");

            migrationBuilder.CreateIndex(
                name: "IX_ColunaCards_IdIteracao",
                table: "ColunaCards",
                column: "IdIteracao");

            migrationBuilder.CreateIndex(
                name: "IX_ColunaCards_IdProjeto",
                table: "ColunaCards",
                column: "IdProjeto");

            migrationBuilder.CreateIndex(
                name: "IX_ColunaCards_IdQuadroColuna",
                table: "ColunaCards",
                column: "IdQuadroColuna");

            migrationBuilder.CreateIndex(
                name: "IX_CompetenciaPraticas_IdPraticaAgil",
                table: "CompetenciaPraticas",
                column: "IdPraticaAgil");

            migrationBuilder.CreateIndex(
                name: "IX_CompetenciaQuestaoOpcoes_IdCompetenciaQuestao",
                table: "CompetenciaQuestaoOpcoes",
                column: "IdCompetenciaQuestao");

            migrationBuilder.CreateIndex(
                name: "IX_CompetenciaQuestoes_IdCompetencia",
                table: "CompetenciaQuestoes",
                column: "IdCompetencia");

            migrationBuilder.CreateIndex(
                name: "IX_Dailies_IdResponsavelRegistro",
                table: "Dailies",
                column: "IdResponsavelRegistro");

            migrationBuilder.CreateIndex(
                name: "IX_Dailies_IdTime",
                table: "Dailies",
                column: "IdTime");

            migrationBuilder.CreateIndex(
                name: "IX_DailyConfiguracoes_IdTime",
                table: "DailyConfiguracoes",
                column: "IdTime",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_DelegationBoards_IdDominio",
                table: "DelegationBoards",
                column: "IdDominio");

            migrationBuilder.CreateIndex(
                name: "IX_DelegationBoards_IdResponsavelTime",
                table: "DelegationBoards",
                column: "IdResponsavelTime");

            migrationBuilder.CreateIndex(
                name: "IX_DelegationBoards_IdSupervisor",
                table: "DelegationBoards",
                column: "IdSupervisor");

            migrationBuilder.CreateIndex(
                name: "IX_DelegationBoards_IdTime",
                table: "DelegationBoards",
                column: "IdTime");

            migrationBuilder.CreateIndex(
                name: "IX_DicaAgileCoachCategorias_IdCategoria",
                table: "DicaAgileCoachCategorias",
                column: "IdCategoria");

            migrationBuilder.CreateIndex(
                name: "IX_EnpsPesquisaPerguntas_IdPergunta",
                table: "EnpsPesquisaPerguntas",
                column: "IdPergunta");

            migrationBuilder.CreateIndex(
                name: "IX_EnpsPesquisaPerguntas_IdPesquisa",
                table: "EnpsPesquisaPerguntas",
                column: "IdPesquisa");

            migrationBuilder.CreateIndex(
                name: "IX_EnpsPesquisas_IdOrganizacao",
                table: "EnpsPesquisas",
                column: "IdOrganizacao");

            migrationBuilder.CreateIndex(
                name: "IX_EnpsPesquisas_IdTime",
                table: "EnpsPesquisas",
                column: "IdTime");

            migrationBuilder.CreateIndex(
                name: "IX_EnpsRespostas_IdOrganizacao",
                table: "EnpsRespostas",
                column: "IdOrganizacao");

            migrationBuilder.CreateIndex(
                name: "IX_EnpsRespostas_IdPesquisaPergunta",
                table: "EnpsRespostas",
                column: "IdPesquisaPergunta");

            migrationBuilder.CreateIndex(
                name: "IX_EnpsRespostas_IdPessoa",
                table: "EnpsRespostas",
                column: "IdPessoa");

            migrationBuilder.CreateIndex(
                name: "IX_Epicos_IdOwner",
                table: "Epicos",
                column: "IdOwner");

            migrationBuilder.CreateIndex(
                name: "IX_Epicos_IdProjeto",
                table: "Epicos",
                column: "IdProjeto");

            migrationBuilder.CreateIndex(
                name: "IX_Epicos_IdResponsavel",
                table: "Epicos",
                column: "IdResponsavel");

            migrationBuilder.CreateIndex(
                name: "IX_Indicadores_IdTime",
                table: "Indicadores",
                column: "IdTime");

            migrationBuilder.CreateIndex(
                name: "IX_LeadtimeManuais_IdLeadtime",
                table: "LeadtimeManuais",
                column: "IdLeadtime");

            migrationBuilder.CreateIndex(
                name: "IX_LeadtimeQuadros_IdLeadtime",
                table: "LeadtimeQuadros",
                column: "IdLeadtime");

            migrationBuilder.CreateIndex(
                name: "IX_LeadtimeQuadros_IdQuadro",
                table: "LeadtimeQuadros",
                column: "IdQuadro");

            migrationBuilder.CreateIndex(
                name: "IX_Leadtimes_IdTime",
                table: "Leadtimes",
                column: "IdTime");

            migrationBuilder.CreateIndex(
                name: "IX_MelhoriasContinuas_IdResponsavelMelhoriaContinua",
                table: "MelhoriasContinuas",
                column: "IdResponsavelMelhoriaContinua");

            migrationBuilder.CreateIndex(
                name: "IX_MelhoriasContinuas_IdTime",
                table: "MelhoriasContinuas",
                column: "IdTime");

            migrationBuilder.CreateIndex(
                name: "IX_MovimentoConfiguracoes_IdTime",
                table: "MovimentoConfiguracoes",
                column: "IdTime",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_MovimentoQuadros_IdMovimentoConfiguracao",
                table: "MovimentoQuadros",
                column: "IdMovimentoConfiguracao");

            migrationBuilder.CreateIndex(
                name: "IX_MovimentoQuadros_IdQuadro",
                table: "MovimentoQuadros",
                column: "IdQuadro",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_NotificacaoPraticasAgeis_IdPraticaAgil",
                table: "NotificacaoPraticasAgeis",
                column: "IdPraticaAgil");

            migrationBuilder.CreateIndex(
                name: "IX_NotificacaoPraticasAgeis_IdTime",
                table: "NotificacaoPraticasAgeis",
                column: "IdTime");

            migrationBuilder.CreateIndex(
                name: "IX_PessoaMotivadores_IdMotivador",
                table: "PessoaMotivadores",
                column: "IdMotivador");

            migrationBuilder.CreateIndex(
                name: "IX_PlanningConfiguracoes_IdTime",
                table: "PlanningConfiguracoes",
                column: "IdTime",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_PlanningObjetivos_IdPalnning",
                table: "PlanningObjetivos",
                column: "IdPalnning");

            migrationBuilder.CreateIndex(
                name: "IX_Plannings_IdResponsavelRegistro",
                table: "Plannings",
                column: "IdResponsavelRegistro");

            migrationBuilder.CreateIndex(
                name: "IX_Plannings_IdTecnicaUtilizada",
                table: "Plannings",
                column: "IdTecnicaUtilizada");

            migrationBuilder.CreateIndex(
                name: "IX_Plannings_IdTime",
                table: "Plannings",
                column: "IdTime");

            migrationBuilder.CreateIndex(
                name: "IX_PortfolioAcoes_IdPessoaResponsavel",
                table: "PortfolioAcoes",
                column: "IdPessoaResponsavel");

            migrationBuilder.CreateIndex(
                name: "IX_PortfolioAcoes_IdPortfolioMeta",
                table: "PortfolioAcoes",
                column: "IdPortfolioMeta");

            migrationBuilder.CreateIndex(
                name: "IX_PortfolioMetas_IdPortfolioObjetivo",
                table: "PortfolioMetas",
                column: "IdPortfolioObjetivo");

            migrationBuilder.CreateIndex(
                name: "IX_PraticasAgeisTimes_IdTime",
                table: "PraticasAgeisTimes",
                column: "IdTime");

            migrationBuilder.CreateIndex(
                name: "IX_ProjetoPortfolioMetas_IdPortfolioMeta",
                table: "ProjetoPortfolioMetas",
                column: "IdPortfolioMeta");

            migrationBuilder.CreateIndex(
                name: "IX_Projetos_IdCliente",
                table: "Projetos",
                column: "IdCliente");

            migrationBuilder.CreateIndex(
                name: "IX_Projetos_IdResponsavelComercial",
                table: "Projetos",
                column: "IdResponsavelComercial");

            migrationBuilder.CreateIndex(
                name: "IX_QuadroColunas_IdQuadro",
                table: "QuadroColunas",
                column: "IdQuadro");

            migrationBuilder.CreateIndex(
                name: "IX_Quadros_IdTime",
                table: "Quadros",
                column: "IdTime");

            migrationBuilder.CreateIndex(
                name: "IX_ResponsavelCards_IdColunaCard",
                table: "ResponsavelCards",
                column: "IdColunaCard");

            migrationBuilder.CreateIndex(
                name: "IX_ResponsavelProjetos_IdPessoa",
                table: "ResponsavelProjetos",
                column: "IdPessoa");

            migrationBuilder.CreateIndex(
                name: "IX_ResponsavelProjetos_IdProjeto",
                table: "ResponsavelProjetos",
                column: "IdProjeto");

            migrationBuilder.CreateIndex(
                name: "IX_Retrospectiva_IdResponsavelRegistro",
                table: "Retrospectiva",
                column: "IdResponsavelRegistro");

            migrationBuilder.CreateIndex(
                name: "IX_Retrospectiva_IdTecnicaUtilizada",
                table: "Retrospectiva",
                column: "IdTecnicaUtilizada");

            migrationBuilder.CreateIndex(
                name: "IX_Retrospectiva_IdTime",
                table: "Retrospectiva",
                column: "IdTime");

            migrationBuilder.CreateIndex(
                name: "IX_RetrospectivaConfiguracao_IdTime",
                table: "RetrospectivaConfiguracao",
                column: "IdTime",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ReviewConfiguracoes_IdTime",
                table: "ReviewConfiguracoes",
                column: "IdTime",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Reviews_IdPlanning",
                table: "Reviews",
                column: "IdPlanning",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Reviews_IdResponsavelRegistro",
                table: "Reviews",
                column: "IdResponsavelRegistro");

            migrationBuilder.CreateIndex(
                name: "IX_Reviews_IdTime",
                table: "Reviews",
                column: "IdTime");

            migrationBuilder.CreateIndex(
                name: "IX_Seguidores_IdUsuario",
                table: "Seguidores",
                column: "IdUsuario");

            migrationBuilder.CreateIndex(
                name: "IX_SentimentosPessoas_IdPessoa",
                table: "SentimentosPessoas",
                column: "IdPessoa");

            migrationBuilder.CreateIndex(
                name: "IX_ThroughputManuais_IdThroughput",
                table: "ThroughputManuais",
                column: "IdThroughput");

            migrationBuilder.CreateIndex(
                name: "IX_ThroughputQuadros_IdQuadro",
                table: "ThroughputQuadros",
                column: "IdQuadro");

            migrationBuilder.CreateIndex(
                name: "IX_ThroughputQuadros_IdThroughput",
                table: "ThroughputQuadros",
                column: "IdThroughput");

            migrationBuilder.CreateIndex(
                name: "IX_Throughputs_IdTime",
                table: "Throughputs",
                column: "IdTime");

            migrationBuilder.CreateIndex(
                name: "IX_TimeDicasAgileCoach_IdDicaAgileCoach",
                table: "TimeDicasAgileCoach",
                column: "IdDicaAgileCoach");

            migrationBuilder.CreateIndex(
                name: "IX_TimeProjetos_IdProjeto",
                table: "TimeProjetos",
                column: "IdProjeto");

            migrationBuilder.CreateIndex(
                name: "IX_TimeProjetos_IdTime",
                table: "TimeProjetos",
                column: "IdTime");

            migrationBuilder.AddForeignKey(
                name: "FK_Convites_Pessoas_IdPessoaCriada",
                table: "Convites",
                column: "IdPessoaCriada",
                principalTable: "Pessoas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ConvitesHistorico_Convites_IdConvite",
                table: "ConvitesHistorico",
                column: "IdConvite",
                principalTable: "Convites",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ConvitesHistorico_Pessoas_IdPessoaRequisita",
                table: "ConvitesHistorico",
                column: "IdPessoaRequisita",
                principalTable: "Pessoas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_NotificacaoUsuarios_Notificacoes_IdNotificacao",
                table: "NotificacaoUsuarios",
                column: "IdNotificacao",
                principalTable: "Notificacoes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PessoaHabilidades_Habilidades_IdHabilidade",
                table: "PessoaHabilidades",
                column: "IdHabilidade",
                principalTable: "Habilidades",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
