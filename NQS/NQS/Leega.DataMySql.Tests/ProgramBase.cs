using Leega.DataMySql.Repositories.Interfaces;
using Leega.DataMySql.Tests.Tests;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace Leega.DataMySql.Tests.Tests
{
    public class ProgramBase
    {
        protected static ClienteTest _clienteTest;
        protected static UsuarioTests _usuarioTests;

        static ProgramBase()
        {
            // injeção do MySql
            IoC.BootStrapper.RegisterServices(new ServiceCollection());

            _clienteTest = IoC.BootStrapper.Resolve<ClienteTest>();
            _usuarioTests = IoC.BootStrapper.Resolve<UsuarioTests>();
        }
    }
}
