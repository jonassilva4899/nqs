using Leega.Application.Interfaces;
using Leega.Application.ViewModels;
using Leega.DataMySql.Entity;
using Leega.DataMySql.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Leega.Application.Services
{
    public class PessoaMySqlService : BaseMySqlService, IPessoaMySqlService
    {
        private readonly IPessoaMySqlRepository _pessoaMySqlRepository;
        public PessoaMySqlService(IPessoaMySqlRepository pessoaMySqlRepository)
        {
            _pessoaMySqlRepository = pessoaMySqlRepository;
        }

        public void Adicionar(PessoaMySqlViewModel obj, string idOrganizacao)
        {
            // TODO: implementar o pesquisar time
            TimeMySql timeMySql = new TimeMySql { };

            PessoaMySql pessoaMySql = new PessoaMySql
            {
                Id = Guid.NewGuid().ToString(),
                Nome = obj.Nome,
                Foto = obj.Foto,
                Telefone = obj.Telefone,
                Email = obj.Email,
                MiniBio = obj.MiniBio,
                Status = obj.Status,
                DataCriacao = DateTime.Now,
                ResponsavelCriacao = obj.ResponsavelCriacao,
                DataEdicao = DateTime.Now,
                ResponsavelEdicao = obj.ResponsavelEdicao,
                GoobeeAdmin = false
            };
            pessoaMySql.TimePessoas = new List<TimePessoaMySql>(0);
            pessoaMySql.TimePessoas.Add(new TimePessoaMySql
            {
                IdPessoa = pessoaMySql.Id,
                IdTime = timeMySql.Id,
                Status = true,
                DataCriacao = DateTime.Now,
                ResponsavelCriacao = pessoaMySql.ResponsavelCriacao,
                DataEdicao = DateTime.Now,
                IdOrganizacao = idOrganizacao
            });

            _pessoaMySqlRepository.Adicionar(pessoaMySql);
        }
    }
}
