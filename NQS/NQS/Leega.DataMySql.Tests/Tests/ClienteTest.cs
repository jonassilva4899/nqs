using Leega.DataMySql.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace Leega.DataMySql.Tests.Tests
{
    public class ClienteTest : BaseTests
    {
        public void Executar()
        {
            Adicionar();
            Console.WriteLine("Adicionado");

            Atualizar();
            Console.WriteLine("Atualizado");

            Listar();
            Console.WriteLine("Listado");

            Obter();
            Console.WriteLine("Pesquisado");

            Remover();
            Console.WriteLine("Removido");
        }

        private void Adicionar()
        {
            try
            {
                _clienteMySqlRepository.Adicionar(new ClienteMySql
                {
                    DataCriacao = DateTime.Now,
                    DataEdicao = DateTime.Now,
                    IdOrganizacao = Guid.NewGuid().ToString(),
                    Nome = "Teste",
                    ResponsavelCriacao = Guid.NewGuid().ToString(),
                    ResponsavelEdicao = Guid.NewGuid().ToString()
                });
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
            }
        }

        private void Atualizar()
        {
            try
            {
                _clienteMySqlRepository.Atualizar(new ClienteMySql
                {
                    Id = "b513b3fa-0a99-4c40-a51f-c102c8ae918e",
                    DataCriacao = DateTime.Now,
                    DataEdicao = DateTime.Now,
                    IdOrganizacao = Guid.NewGuid().ToString(),
                    Nome = "Teste atualizado",
                    ResponsavelCriacao = Guid.NewGuid().ToString(),
                    ResponsavelEdicao = Guid.NewGuid().ToString()
                });
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
            }
        }

        private void Listar()
        {
            try
            {
                IList<ClienteMySql> clienteMySqls = _clienteMySqlRepository.ListarTodos().ToList();
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
            }
        }

        private void Obter()
        {
            try
            {
                ClienteMySql clienteMySq = _clienteMySqlRepository.Obter(new ClienteMySql { Id = "b513b3fa-0a99-4c40-a51f-c102c8ae918e" });
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
            }
        }

        private void Remover()
        {
            try
            {
                _clienteMySqlRepository.Remover(new ClienteMySql { Id = "b513b3fa-0a99-4c40-a51f-c102c8ae918e" });
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
            }
        }
    }
}
