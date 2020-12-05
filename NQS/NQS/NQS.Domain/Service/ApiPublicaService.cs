using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Leega.Domain.Domain;
using Leega.Entity.Repositories.Interfaces;
using OtpNet;
using Serilog;

namespace Leega.Domain.Service
{
    public class ApiPublicaService
    {
        private readonly string _secretKey = "uJSjxYTSUZVGn1CHBJaY";
        private readonly Totp _totp;
        private readonly IOrganizacaoRepository _organizacaoRepository;

        public ApiPublicaService(IOrganizacaoRepository organizacaoRepository)
        {
            _totp = new Totp(Encoding.ASCII.GetBytes(_secretKey));
            _organizacaoRepository = organizacaoRepository;
        }

        public async Task<bool> ValidarTokenOtp(string token)
        {
            try
            {
                Log.Debug($"Token recebido: {token}");

                var validadeToken = "inválido";

                long janelaDeTempoUtilizada;
                var validade = _totp.VerifyTotp(token, out janelaDeTempoUtilizada);

                if (validade)
                {
                    validadeToken = "válido";
                }

                Log.Debug($"O token recebido é {validadeToken}");
                Log.Debug($"Foi utilizada a janela de tempo {janelaDeTempoUtilizada}");

                return validade;
            }
            catch (Exception e)
            {
                Log.Error($"Ocorreu um erro ao tentar validar o token: {e.Message}");
                throw e;
            }
        }

        public async Task<List<OrganizacaoListagemViewModel>> ListarOrganizacoes()
        {
            try
            {
                Log.Debug("Listando as organizações");
                var organizacoes = await _organizacaoRepository.ListarApiPublica();

                return organizacoes.Select(x => new OrganizacaoListagemViewModel()
                {
                    Id = x.Id,
                    Nome = x.Nome,
                    QuantidadePessoas = x.Pessoas.Count()
                }).ToList();
            }
            catch (Exception e)
            {
                Log.Error($"Ocorreu um erro ao tentar listar as organizações: {e.Message}");
                throw e;
            }
        }
    }
}