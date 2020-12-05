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
    [Migration("20200123180217_RemoveCamposBaseEntity")]
    partial class RemoveCamposBaseEntity
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
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DataEdicao")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("IdOrganizacao")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("IdTime")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Nome")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Status")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.HasIndex("IdTime");

                    b.ToTable("Configuracoes");
                });

            modelBuilder.Entity("Leega.Entity.Notificacao", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("DataCriacao")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("IdOrganizacao")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Mensagem")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Tipo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Titulo")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Notificacoes");
                });

            modelBuilder.Entity("Leega.Entity.NotificacaoUsuario", b =>
                {
                    b.Property<Guid>("IdUsuario")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("IdNotificacao")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("IdOrganizacao")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("IdUsuario", "IdNotificacao");

                    b.HasIndex("IdNotificacao");

                    b.ToTable("NotificacaoUsuarios");
                });

            modelBuilder.Entity("Leega.Entity.Seguidor", b =>
                {
                    b.Property<Guid>("IdTime")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("IdUsuario")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("DataSeguir")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("IdOrganizacao")
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
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Logo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nome")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Proposito")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("ResponsavelCriacao")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("ResponsavelEdicao")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Valores")
                        .HasColumnType("nvarchar(max)");

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

                    b.Property<Guid>("IdOrganizacao")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Papel")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("ResponsavelCriacao")
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

                    b.Property<string>("Cargo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DataCriacao")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DataEdicao")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Foto")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("IdOrganizacao")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Login")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nome")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("ResponsavelCriacao")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("ResponsavelEdicao")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Senha")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Status")
                        .HasColumnType("bit");

                    b.HasKey("Id");

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
#pragma warning restore 612, 618
        }
    }
}
