using Leega.DataMySql.Tests.Tests;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace Leega.DataMySql.Tests.IoC
{
    public static class BootStrapper
    {
        public static void RegisterServices(IServiceCollection services)
        {
            Leega.IoC.BootStrapper.RegisterServices(services);

            services.AddSingleton<ClienteTest>();
            services.AddSingleton<UsuarioTests>();
        }

        public static T Resolve<T>()
        {
            var serviceCollection = new ServiceCollection();
            RegisterServices(serviceCollection);

            var serviceProvider = serviceCollection.BuildServiceProvider();
            return serviceProvider.GetService<T>();
        }
    }
}
