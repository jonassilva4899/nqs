using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Leega.Entity.Context;
using Leega.Entity.Entity;
using Leega.Entity.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Leega.Entity.Repositories
{
    public class OrganizacaoRepository : Repository<Organizacao>, IOrganizacaoRepository
    {
        private goobeeteamsContext _appContext => (goobeeteamsContext)_context;

        public OrganizacaoRepository(goobeeteamsContext context) : base(context)
        {
        }

        public async Task<List<Organizacao>> Listar(Guid idUsuario)
        {
            var organizacoes = await _appContext.OrganizacaoUsuarios
                .Where(x => x.IdUsuario == idUsuario && x.UsuarioPlataforma)
                .Select(x => x.Organizacao)
                .ToListAsync();
            return organizacoes;
        }

        public async Task<List<Organizacao>> ListarGoobeeAdmin()
        {
            var organizacoes = await _appContext.Organizacoes
                .ToListAsync();
            return organizacoes;
        }

        public async Task<List<Organizacao>> ListarApiPublica()
        {
            var organizacoes = await _appContext.Organizacoes
                .Include(x => x.Pessoas)
                .ToListAsync();
            return organizacoes;
        }
        public Task<OrganizacaoUsuario> BuscaOrganizacaoPorPessoa(Guid idOrganizacao, Guid idPessoa)
        {
            var organizacaoPessoa = _appContext.OrganizacaoUsuarios.Where(x => x.IdOrganizacao == idOrganizacao && x.IdPessoa == idPessoa).FirstOrDefaultAsync();
            return organizacaoPessoa;

        }
        public Task<Organizacao> Selecionar(Guid idOrganizacao)
        {
            return _appContext.Organizacoes
                .Include(x => x.Pessoas).ThenInclude(x => x.Pessoa)
                .FirstOrDefaultAsync(x => x.Id == idOrganizacao);
        }


    }
}