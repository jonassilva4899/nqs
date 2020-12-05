using System;
using System.Threading.Tasks;
using System.Linq;
using System.Configuration;
using Leega.Entity.Entity;
using Leega.Entity.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace Leega.Entity.Context
{
    public partial class goobeeteamsContext : DbContext
    {

        public goobeeteamsContext(DbContextOptions<goobeeteamsContext> options)
            : base(options)
        {
            //Database.SetCommandTimeout(1800);
        }

        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Configuracao> Configuracoes { get; set; }
        public DbSet<TimePessoa> TimePessoas { get; set; }
        public DbSet<Time> Times { get; set; }
        public DbSet<NotificacaoUsuario> NotificacaoUsuarios { get; set; }
        public DbSet<Pessoa> Pessoas { get; set; }
        public DbSet<Convite> Convites { get; set; }
        public DbSet<ConviteHistorico> ConvitesHistorico { get; set; }
        public DbSet<RecuperarSenha> RecuperarSenhas { get; set; }
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<PessoaCliente> PessoaClientes { get; set; }
        public DbSet<PersonalMappingTitulo> PersonalMappingTitulos { get; set; }
        public DbSet<PersonalMappingItem> PersonalMappingItens { get; set; }
        public DbSet<PessoaHabilidade> PessoaHabilidades { get; set; }
        public DbSet<Organizacao> Organizacoes { get; set; }
        public DbSet<OrganizacaoUsuario> OrganizacaoUsuarios { get; set; }
        public DbSet<OrganizacaoUsuarioRole> OrganizacaoUsuarioRoles { get; set; }
        public DbSet<Grupo> Grupos { get; set; }
        public DbSet<TimeGrupo> TimeGrupos { get; set; }

        public static readonly ILoggerFactory MyLoggerFactory
    = LoggerFactory.Create(builder => { builder.AddConsole(); });

        //lazy-loading
        //https://entityframeworkcore.com/querying-data-loading-eager-lazy
        //https://docs.microsoft.com/en-us/ef/core/querying/related-data
        //EF Core will enable lazy-loading for any navigation property that is virtual and in an entity class that can be inherited
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder
        .UseLazyLoadingProxies()
        .UseLoggerFactory(MyLoggerFactory);

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            //Cliente
            modelBuilder.Entity<Cliente>()
                .HasKey(x => x.Id);


            //Configuração
            modelBuilder.Entity<Configuracao>()
                .HasKey(x => x.Id);

            modelBuilder.Entity<Configuracao>()
               .HasOne(x => x.Time)
               .WithMany(x => x.Configuracoes)
               .HasForeignKey(x => x.IdTime);

            //ConviteHistorico
            modelBuilder.Entity<ConviteHistorico>()
                .HasKey(x => x.Id);


            //Grupo
            modelBuilder.Entity<Grupo>()
                .HasKey(x => x.Id);


            //NotificacaoUsuario
            modelBuilder.Entity<NotificacaoUsuario>()
                .HasKey(x => new { x.IdNotificacao, x.IdUsuario });

            modelBuilder.Entity<NotificacaoUsuario>()
                .HasOne(x => x.Usuario)
                .WithMany(x => x.NotificacaoUsuarios)
                .HasForeignKey(x => x.IdUsuario);


            //OrganizacaoUsuarioRole
            modelBuilder.Entity<OrganizacaoUsuarioRole>()
                .HasKey(x => x.Id);

            //PersonalMappingTitulo
            modelBuilder.Entity<PersonalMappingItem>()
                .HasKey(x => x.Id);

            modelBuilder.Entity<PersonalMappingItem>()
               .HasOne(x => x.PersonalMappingTitulo)
               .WithMany(x => x.PersonalMappingItens)
               .HasForeignKey(x => x.IdPersonalMappingTitulo);

            //PersonalMappingTitulo
            modelBuilder.Entity<PersonalMappingTitulo>()
                .HasKey(x => x.Id);

            modelBuilder.Entity<PersonalMappingTitulo>()
               .HasOne(x => x.Pessoa)
               .WithMany(x => x.PersonalMappingTitulos)
               .HasForeignKey(x => x.IdPessoa);

            //Pessoa
            modelBuilder.Entity<Pessoa>()
                .HasKey(x => x.Id);

            modelBuilder.Entity<Pessoa>()
                .HasOne(x => x.UltimaOrgAcessada)
                .WithMany(x => x.UltimosAcessos)
                .HasForeignKey(x => x.IdUltimaOrgAcessada);

            //PessoaCliente
            modelBuilder.Entity<PessoaCliente>()
                .HasKey(x => new { x.IdPessoa, x.IdCliente });

            modelBuilder.Entity<PessoaCliente>()
            .HasOne(x => x.Pessoa)
            .WithMany(x => x.PessoaClientes)
            .HasForeignKey(x => x.IdPessoa);

            modelBuilder.Entity<PessoaCliente>()
            .HasOne(x => x.Cliente)
            .WithMany(x => x.PessoaClientes)
            .HasForeignKey(x => x.IdCliente);

            //PessoaHabilidade
            modelBuilder.Entity<PessoaHabilidade>()
                .HasKey(x => new { x.IdPessoa, x.IdHabilidade });

            modelBuilder.Entity<PessoaHabilidade>()
            .HasOne(x => x.Pessoa)
            .WithMany(x => x.PessoaHabilidades)
            .HasForeignKey(x => x.IdPessoa);


            //RecuperarSenha
            modelBuilder.Entity<RecuperarSenha>()
                .HasKey(x => x.Id);

            modelBuilder.Entity<RecuperarSenha>()
               .HasOne(x => x.Pessoa)
               .WithMany(x => x.RecuperarSenhas)
               .HasForeignKey(x => x.IdPessoa);


            //Time
            modelBuilder.Entity<Time>()
               .HasKey(x => x.Id);

            modelBuilder.Entity<Time>()
                .Property(x => x.PraticaAgilEmFalta)
                .HasDefaultValue(false);


            //TimeGrupo
            modelBuilder.Entity<TimeGrupo>()
                .HasKey(x => new { x.IdTime, x.IdGrupo });

            modelBuilder.Entity<TimeGrupo>()
            .HasOne(x => x.Time)
            .WithMany(x => x.TimeGrupos)
            .HasForeignKey(x => x.IdTime);

            modelBuilder.Entity<TimeGrupo>()
            .HasOne(x => x.Grupo)
            .WithMany(x => x.TimeGrupos)
            .HasForeignKey(x => x.IdGrupo);

            //TimePessoa
            modelBuilder.Entity<TimePessoa>()
                .HasKey(x => new { x.IdTime, x.IdPessoa });

            modelBuilder.Entity<TimePessoa>()
            .HasOne(x => x.Pessoa)
            .WithMany(x => x.TimePessoas)
            .HasForeignKey(x => x.IdPessoa);

            modelBuilder.Entity<TimePessoa>()
            .HasOne(x => x.Time)
            .WithMany(x => x.TimePessoas)
            .HasForeignKey(x => x.IdTime);

            //Usuario
            modelBuilder.Entity<Usuario>()
                .HasKey(x => x.Id);

            //UsuarioOrganizacao
            modelBuilder.Entity<OrganizacaoUsuario>()
                .HasKey(x => new { x.IdPessoa, x.IdOrganizacao });

            modelBuilder.Entity<OrganizacaoUsuario>()
                .HasIndex(x => new { x.IdOrganizacao, x.IdPessoa, x.IdUsuario })
                .IsUnique();

            modelBuilder.Entity<OrganizacaoUsuario>()
                .HasOne(x => x.Pessoa)
                .WithMany(x => x.Organizacoes)
                .HasForeignKey(x => x.IdPessoa);

            modelBuilder.Entity<OrganizacaoUsuario>()
                .HasOne(x => x.Usuario)
                .WithMany(x => x.Organizacoes)
                .HasForeignKey(x => x.IdUsuario);

            modelBuilder.Entity<OrganizacaoUsuario>()
                .HasOne(x => x.Organizacao)
                .WithMany(x => x.Pessoas)
                .HasForeignKey(x => x.IdOrganizacao);

            modelBuilder.Entity<OrganizacaoUsuario>()
                .HasOne(x => x.OrganizacaoUsuarioRole)
                .WithMany(x => x.OrganizacaoUsuarios)
                .HasForeignKey(x => x.IdOrganizacaoUsuarioRole);

        }

        public override int SaveChanges()
        {
            return base.SaveChanges();
        }

        public async Task<int> SaveChangesAsync()
        {
            return await base.SaveChangesAsync();
        }
    }
}
