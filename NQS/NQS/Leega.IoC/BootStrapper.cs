using Leega.Application.Interfaces;
using Leega.Application.Services;
using Leega.DataMySql.Repositories;
using Leega.DataMySql.Repositories.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace Leega.IoC
{
    public static class BootStrapper
    {
        public static void RegisterServices(IServiceCollection services)
        {
            // Repositorio MySQL
            services.AddTransient<IClienteMySqlRepository, ClienteMySqlRepository>();
            services.AddTransient<IUsuarioMySqlRepository, UsuarioMySqlRepository>();
            services.AddTransient<IOrganizacaoMySqlRepository, OrganizacaoMySqlRepository>();
            services.AddTransient<IPessoaMySqlRepository, PessoaMySqlRepository>();

            // Aplication
            services.AddTransient<IUsuarioMySqlService, UsuarioMySqlService>();
            services.AddTransient<ILoginMySqlService, LoginMySqlService>();
            services.AddTransient<IPessoaMySqlService, PessoaMySqlService>();
        }

        public static T GetService<T>()
        {
            var serviceCollection = new ServiceCollection();
            RegisterServices(serviceCollection);

            var serviceProvider = serviceCollection.BuildServiceProvider();
            return serviceProvider.GetService<T>();
        }
    }
}
