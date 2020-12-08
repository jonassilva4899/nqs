using Leega.Application.Interfaces;
using Leega.Application.ViewModels;
using Leega.DataMySql.Entity;
using Leega.DataMySql.Repositories.Interfaces;
using Leega.Util;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leega.Application.Services
{
    public class PacienteMySqlService : BaseMySqlService, IPacienteMySqlService
    {
        private readonly IPacienteMySqlRepository _PacienteMySqlRepository;
        private IConfiguration _config;

        public PacienteMySqlService(IConfiguration config,
          IPacienteMySqlRepository pacienteMySqlRepository)
        {
            _config = config;
            _PacienteMySqlRepository = pacienteMySqlRepository;
        }


        public void Adicionar(PacienteMySql obj)
        {
            //obj.Senha = string.IsNullOrWhiteSpace(obj.Senha) ? Guid.NewGuid().ToString().Substring(0, 5) : obj.Senha;

            _PacienteMySqlRepository.Adicionar(obj);
        }

        public void Atualizar(PacienteMySql obj)
        {
            _PacienteMySqlRepository.Atualizar(obj);
        }

        public async Task<List<PacienteMySqlViewModel>> ListarTodos()
        {
            // pesquisar pessoas por organização
            IEnumerable<PacienteMySql> busca = _PacienteMySqlRepository.ListarTodos();

            // objeto view model para retorno
            List<PacienteMySqlViewModel> retorno = busca.Select(item => new PacienteMySqlViewModel
            {
                Id = item.Id,
                NomeCompleto = item.NomeCompleto,
                Apelido = item.Apelido,
                AtendimentoPrioritario = item.AtendimentoPrioritario,
                Email = item.Email,
                CartaoSus = item.CartaoSus,
                Celular = item.Celular,
                Convenio = item.Convenio,
                DataNascimento = item.DataNascimento,
                DesfechoAtendimento = item.DesfechoAtendimento,
                DocumentoIdentificacao = item.DocumentoIdentificacao,
                Endereco = item.Endereco,
                Escolaridade = item.Escolaridade,
                Especialidade = item.Especialidade,
                Impressao = item.Impressao,
                MotivoAtendimento = item.MotivoAtendimento,
                Nacionalidade = item.Nacionalidade,
                Naturalidade = item.Naturalidade,
                NomeContatoEmergencia = item.NomeContatoEmergencia,
                NomeGenitor = item.NomeGenitor,
                NomeGenitor2 = item.NomeGenitor2,
                OrigemAtendimento = item.OrigemAtendimento,
                Procedencia = item.Procedencia,
                Profissao = item.Profissao,
                Raca = item.Raca,
                Rg = item.Rg,
                Sexo = item.Sexo,
                SituacaoFamiliar = item.SituacaoFamiliar,
                TelefoneEmergencia = item.TelefoneEmergencia
            }).ToList();

            return retorno;
        }

        public async Task<PacienteMySqlViewModel> Obter(Guid id)
        {
            
            PacienteMySql busca = _PacienteMySqlRepository.ListarTodos().Where(x => x.Id == id.ToString("D")).FirstOrDefault();
            
            PacienteMySqlViewModel retorno = new PacienteMySqlViewModel();

            retorno.Id = busca.Id;
            retorno.NomeCompleto = busca.NomeCompleto;
            retorno.Apelido = busca.Apelido;
            retorno.AtendimentoPrioritario = busca.AtendimentoPrioritario;
            retorno.Email = busca.Email;
            retorno.CartaoSus = busca.CartaoSus;
            retorno.Celular = busca.Celular;
            retorno.Convenio = busca.Convenio;
            retorno.DataNascimento = busca.DataNascimento;
            retorno.DesfechoAtendimento = busca.DesfechoAtendimento;
            retorno.DocumentoIdentificacao = busca.DocumentoIdentificacao;
            retorno.Endereco = busca.Endereco;
            retorno.Escolaridade = busca.Escolaridade;
            retorno.Especialidade = busca.Especialidade;
            retorno.Impressao = busca.Impressao;
            retorno.MotivoAtendimento = busca.MotivoAtendimento;
            retorno.Nacionalidade = busca.Nacionalidade;
            retorno.Naturalidade = busca.Naturalidade;
            retorno.NomeContatoEmergencia = busca.NomeContatoEmergencia;
            retorno.NomeGenitor = busca.NomeGenitor;
            retorno.NomeGenitor2 = busca.NomeGenitor2;
            retorno.OrigemAtendimento = busca.OrigemAtendimento;
            retorno.Procedencia = busca.Procedencia;
            retorno.Profissao = busca.Profissao;
            retorno.Raca = busca.Raca;
            retorno.Rg = busca.Rg;
            retorno.Sexo = busca.Sexo;
            retorno.SituacaoFamiliar = busca.SituacaoFamiliar;
            retorno.TelefoneEmergencia = busca.TelefoneEmergencia;


            return retorno;
        }
    }
}
