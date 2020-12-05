using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Leega.Entity.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Newtonsoft.Json;

namespace Leega.Entity.Context
{
    public static class DbContextExtension
    {

        public static bool AllMigrationsApplied(this DbContext context)
        {
            var applied = context.GetService<IHistoryRepository>()
                .GetAppliedMigrations()
                .Select(m => m.MigrationId);

            var total = context.GetService<IMigrationsAssembly>()
                .Migrations
                .Select(m => m.Key);

            return !total.Except(applied).Any();
            //return false;
        }

        public static void EnsureSeeded(this goobeeteamsContext context)
        {
            if (!context.Pessoas.Any())
            {
                var pessoa = JsonConvert.DeserializeObject<Pessoa>(File.ReadAllText("seed" + Path.DirectorySeparatorChar + "pessoa.json"));
                context.AddRange(pessoa);
                context.SaveChanges();
            }

            if (!context.Usuarios.Any())
            {
                var usuario = JsonConvert.DeserializeObject<Usuario>(File.ReadAllText("seed" + Path.DirectorySeparatorChar + "usuario.json"));
                context.AddRange(usuario);
                context.SaveChanges();
            }

            if (!context.NotificacaoUsuarios.Any())
            {
                var notificacaoUsuario = JsonConvert.DeserializeObject<NotificacaoUsuario>(File.ReadAllText("seed" + Path.DirectorySeparatorChar + "notificacaoUsuario.json"));
                context.AddRange(notificacaoUsuario);
                context.SaveChanges();
            }

            if (!context.OrganizacaoUsuarioRoles.Any())
            {
                var organizacaoRoles = JsonConvert.DeserializeObject<List<OrganizacaoUsuarioRole>>(File.ReadAllText("seed" + Path.DirectorySeparatorChar + "organizacaoUsuarioRoles.json"));
                context.AddRange(organizacaoRoles);
                context.SaveChanges();
            }
        }

    }
}
