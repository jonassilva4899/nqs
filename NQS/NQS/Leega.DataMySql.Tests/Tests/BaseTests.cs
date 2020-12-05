using Leega.Application.Interfaces;
using Leega.DataMySql.Repositories.Interfaces;
using Leega.DataMySql.Tests.Tests;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace Leega.DataMySql.Tests.Tests
{
    public class BaseTests
    {
        protected static IClienteMySqlRepository _clienteMySqlRepository;
        protected static IUsuarioMySqlService _usuarioMySqlService;
        protected static IPessoaMySqlService _pessoaMySqlService;

        static BaseTests()
        {
            // injeção do MySql
            IoC.BootStrapper.RegisterServices(new ServiceCollection());

            _clienteMySqlRepository = IoC.BootStrapper.Resolve<IClienteMySqlRepository>();
            _usuarioMySqlService = IoC.BootStrapper.Resolve<IUsuarioMySqlService>();
            _pessoaMySqlService = IoC.BootStrapper.Resolve<IPessoaMySqlService>();
        }
    }
}
