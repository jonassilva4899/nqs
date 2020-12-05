﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Leega.Entity.Context;

namespace Leega.Entity.Migrations
{
    [DbContext(typeof(goobeeteamsContext))]
    [Migration("20200205195443_DefinidoTipoTamanhoCampos")]
    partial class DefinidoTipoTamanhoCampos
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Leega.Entity.Configuracao", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Chave")
                        .HasColumnType("VARCHAR(50)");

                    b.Property<DateTime>("DataCriacao")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DataEdicao")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("IdOrganizacao")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("IdTime")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Nome")
                        .HasColumnType("VARCHAR(100)");

                    b.Property<Guid>("ResponsavelCriacao")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("ResponsavelEdicao")
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("Status")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.HasIndex("IdTime");

                    b.ToTable("Configuracoes");
                });

            modelBuilder.Entity("Leega.Entity.Convite", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("DataCriacao")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DataEdicao")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .HasColumnType("VARCHAR(100)");

                    b.Property<Guid>("IdOrganizacao")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("IdPessoaCriada")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Nome")
                        .HasColumnType("VARCHAR(100)");

                    b.Property<Guid>("ResponsavelCriacao")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("ResponsavelEdicao")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("IdPessoaCriada");

                    b.ToTable("Convites");
                });

            modelBuilder.Entity("Leega.Entity.ConviteHistorico", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("DataCriacao")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DataEdicao")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DataEnvio")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DataExpiracao")
                        .HasColumnType("datetime2");

                    b.Property<bool>("FoiEnviado")
                        .HasColumnType("bit");

                    b.Property<Guid>("IdConvite")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("IdOrganizacao")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("IdPessoaRequisita")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("MensagemNotificacao")
                        .HasColumnType("VARCHAR(1000)");

                    b.Property<string>("MensagemResultadoNotificacao")
                        .HasColumnType("VARCHAR(1000)");

                    b.Property<Guid>("ResponsavelCriacao")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("ResponsavelEdicao")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Token")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("IdConvite");

                    b.HasIndex("IdPessoaRequisita");

                    b.ToTable("ConvitesHistorico");
                });

            modelBuilder.Entity("Leega.Entity.Notificacao", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("ConfirmacaoLeitura")
                        .HasColumnType("bit");

                    b.Property<DateTime>("DataCriacao")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DataEdicao")
                        .HasColumnType("datetime2");

                    b.Property<bool>("EnviadoPorEmail")
                        .HasColumnType("bit");

                    b.Property<Guid>("IdOrganizacao")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Mensagem")
                        .HasColumnType("VARCHAR(1000)");

                    b.Property<Guid>("ResponsavelCriacao")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("ResponsavelEdicao")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Tipo")
                        .HasColumnType("VARCHAR(30)");

                    b.Property<string>("Titulo")
                        .HasColumnType("VARCHAR(50)");

                    b.HasKey("Id");

                    b.ToTable("Notificacoes");
                });

            modelBuilder.Entity("Leega.Entity.NotificacaoUsuario", b =>
                {
                    b.Property<Guid>("IdNotificacao")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("IdUsuario")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("DataCriacao")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DataEdicao")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("IdOrganizacao")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("ResponsavelCriacao")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("ResponsavelEdicao")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("IdNotificacao", "IdUsuario");

                    b.HasIndex("IdUsuario");

                    b.ToTable("NotificacaoUsuarios");
                });

            modelBuilder.Entity("Leega.Entity.Pessoa", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("DataCriacao")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DataEdicao")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .HasColumnType("VARCHAR(100)");

                    b.Property<string>("Foto")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FuncaoPrincipal")
                        .HasColumnType("VARCHAR(50)");

                    b.Property<Guid>("IdOrganizacao")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Nome")
                        .HasColumnType("VARCHAR(100)");

                    b.Property<Guid>("ResponsavelCriacao")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("ResponsavelEdicao")
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("Status")
                        .HasColumnType("bit");

                    b.Property<string>("Telefone")
                        .HasColumnType("VARCHAR(20)");

                    b.HasKey("Id");

                    b.ToTable("Pessoas");
                });

            modelBuilder.Entity("Leega.Entity.RecuperarSenha", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("Ativo")
                        .HasColumnType("bit");

                    b.Property<DateTime>("DataCriacao")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DataEdicao")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DataExpiracao")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DataSolicitacao")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("IdOrganizacao")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("IdPessoa")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("MensagemResultadoNotificacao")
                        .HasColumnType("VARCHAR(1000)");

                    b.Property<bool>("NotificacaoFoiEnviada")
                        .HasColumnType("bit");

                    b.Property<Guid>("ResponsavelCriacao")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("ResponsavelEdicao")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Token")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("IdPessoa");

                    b.ToTable("RecuperarSenhas");
                });

            modelBuilder.Entity("Leega.Entity.Seguidor", b =>
                {
                    b.Property<Guid>("IdTime")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("IdUsuario")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("DataCriacao")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DataEdicao")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DataSeguir")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("IdOrganizacao")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("ResponsavelCriacao")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("ResponsavelEdicao")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("IdTime", "IdUsuario");

                    b.HasIndex("IdUsuario");

                    b.ToTable("Seguidores");
                });

            modelBuilder.Entity("Leega.Entity.Time", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("DataCriacao")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DataEdicao")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("IdOrganizacao")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Localizacao")
                        .HasColumnType("VARCHAR(100)");

                    b.Property<string>("Logo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nome")
                        .HasColumnType("VARCHAR(100)");

                    b.Property<string>("Proposito")
                        .HasColumnType("VARCHAR(1000)");

                    b.Property<Guid>("ResponsavelCriacao")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("ResponsavelEdicao")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Valores")
                        .HasColumnType("VARCHAR(1000)");

                    b.HasKey("Id");

                    b.ToTable("Times");
                });

            modelBuilder.Entity("Leega.Entity.TimeUsuario", b =>
                {
                    b.Property<Guid>("IdTime")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("IdUsuario")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("DataCriacao")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DataEdicao")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("IdOrganizacao")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Papel")
                        .HasColumnType("VARCHAR(50)");

                    b.Property<Guid>("ResponsavelCriacao")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("ResponsavelEdicao")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("IdTime", "IdUsuario");

                    b.HasIndex("IdUsuario");

                    b.ToTable("TimeUsuarios");
                });

            modelBuilder.Entity("Leega.Entity.Usuario", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("DataCriacao")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DataEdicao")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("IdOrganizacao")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("IdPessoa")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Login")
                        .HasColumnType("VARCHAR(100)");

                    b.Property<Guid>("ResponsavelCriacao")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("ResponsavelEdicao")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Senha")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("IdPessoa")
                        .IsUnique();

                    b.ToTable("Usuarios");
                });

            modelBuilder.Entity("Leega.Entity.Configuracao", b =>
                {
                    b.HasOne("Leega.Entity.Time", "Time")
                        .WithMany("Configuracoes")
                        .HasForeignKey("IdTime")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Leega.Entity.Convite", b =>
                {
                    b.HasOne("Leega.Entity.Pessoa", "PessoaCriada")
                        .WithMany("Convites")
                        .HasForeignKey("IdPessoaCriada")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Leega.Entity.ConviteHistorico", b =>
                {
                    b.HasOne("Leega.Entity.Convite", "Convite")
                        .WithMany("ConvitesHistorico")
                        .HasForeignKey("IdConvite")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("Leega.Entity.Pessoa", "PessoaRequisita")
                        .WithMany("ConvitesHistorico")
                        .HasForeignKey("IdPessoaRequisita")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Leega.Entity.NotificacaoUsuario", b =>
                {
                    b.HasOne("Leega.Entity.Notificacao", "Notificacao")
                        .WithMany("NotificacaoUsuarios")
                        .HasForeignKey("IdNotificacao")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Leega.Entity.Usuario", "Usuario")
                        .WithMany("NotificacaoUsuarios")
                        .HasForeignKey("IdUsuario")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Leega.Entity.RecuperarSenha", b =>
                {
                    b.HasOne("Leega.Entity.Pessoa", "Pessoa")
                        .WithMany("RecuperarSenhas")
                        .HasForeignKey("IdPessoa")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Leega.Entity.Seguidor", b =>
                {
                    b.HasOne("Leega.Entity.Time", "Time")
                        .WithMany("Seguidores")
                        .HasForeignKey("IdTime")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Leega.Entity.Usuario", "Usuario")
                        .WithMany("Seguidores")
                        .HasForeignKey("IdUsuario")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Leega.Entity.TimeUsuario", b =>
                {
                    b.HasOne("Leega.Entity.Time", "Time")
                        .WithMany("TimeUsuarios")
                        .HasForeignKey("IdTime")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Leega.Entity.Usuario", "Usuario")
                        .WithMany("TimeUsuarios")
                        .HasForeignKey("IdUsuario")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Leega.Entity.Usuario", b =>
                {
                    b.HasOne("Leega.Entity.Pessoa", "Pessoa")
                        .WithOne("Usuario")
                        .HasForeignKey("Leega.Entity.Usuario", "IdPessoa")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
