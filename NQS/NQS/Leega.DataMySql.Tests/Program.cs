using Leega.DataMySql.Entity;
using Leega.DataMySql.Tests.Tests;
using System;

namespace Leega.DataMySql.Tests
{
    class Program : ProgramBase
    {
        static void Main(string[] args)
        {
            //_usuarioTests.Executar();
            //Console.WriteLine("_usuarioTests.Executar()");

            //_clienteTest.Executar();
            //Console.WriteLine("_clienteTest.Executar()");
            _pacienteTests.Executar();            
            Console.WriteLine("_pacienteTests.Executar()");
            Console.ReadKey();
        }
    }
}
