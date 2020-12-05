using System;
using System.Collections.Generic;
using System.Text;

namespace Leega.DataMySql.Tests.Tests
{
    public class UsuarioTests : BaseTests
    {
        public void Executar()
        {
            Adicionar();
            Console.WriteLine("Adicionado");
        }

        private void Adicionar()
        {
            try
            {
                _usuarioMySqlService.Adicionar(new Application.ViewModels.UsuarioMySqlViewModel
                {
                    DataCriacao = DateTime.Now,
                    Ativo = true,
                    Login = "admin",
                    DataEdicao = DateTime.Now,
                    IdOrganizacao = Guid.NewGuid().ToString(),
                    ResponsavelCriacao = Guid.NewGuid().ToString(),
                    ResponsavelEdicao = Guid.NewGuid().ToString()
                }, false);

                _pessoaMySqlService.Adicionar(new Application.ViewModels.PessoaMySqlViewModel
                {
                    Id = Guid.NewGuid().ToString(),
                    Nome = "adicionarPessoa.Nome",
                    Foto = "adicionarPessoa.Foto",
                    Telefone = "adicionarPessoa.Telefone",
                    Email = "admin",
                    MiniBio = "adicionarPessoa.MiniBio",
                    Status = true,
                    DataCriacao = DateTime.Now,
                    ResponsavelCriacao = "adicionarPessoa.ResponsavelCriacao",
                    DataEdicao = DateTime.Now,
                    ResponsavelEdicao = "adicionarPessoa.ResponsavelEdicao",
                    GoobeeAdmin = false
                }, Guid.NewGuid().ToString());
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
            }
        }

    }
}
