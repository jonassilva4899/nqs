using Leega.Entity.Context;
using Leega.Entity.Entity;
using Leega.Entity.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Leega.Entity.Repositories
{
    public class OrganizacaoPessoaRepository : Repository<OrganizacaoUsuario>, IOrganizacaoPessoaRepository
    {
        public OrganizacaoPessoaRepository(goobeeteamsContext context) : base(context)
        { }

        private goobeeteamsContext _appContext => (goobeeteamsContext)_context;

        //public async Task<List<Pessoa>> BuscarPessoasPorOrganizacao(Guid idOrganizacao)
        //{
        //    var pessoasOrganizacao = await _appContext.OrganizacaoUsuarios
        //        .Where(x => x.IdOrganizacao == idOrganizacao)
        //        .Include(x => x.Pessoa).ThenInclude(x => x.SentimentosPessoa)
        //        .Select(x => x.Pessoa)
        //        .ToListAsync();

        //    return pessoasOrganizacao;
        //}

        public async Task<OrganizacaoUsuario> BuscarPorEmailUsuario(string email, Guid idOrganizacao)
        {
            var organizacaoUsuario = await (from org in _appContext.OrganizacaoUsuarios
                                            join u in _appContext.Usuarios on org.IdUsuario equals u.Id
                                            where u.Login.Equals(email) && org.IdOrganizacao == idOrganizacao
                                            select org
                ).FirstOrDefaultAsync();

            return organizacaoUsuario;
        }

        public async Task<OrganizacaoUsuario> BuscarPorEmailPessoa(string email, Guid idOrganizacao)
        {
            var organizacaoUsuario = await (from org in _appContext.OrganizacaoUsuarios
                                            join p in _appContext.Pessoas on org.IdPessoa equals p.Id
                                            where p.Email.Equals(email) && org.IdOrganizacao == idOrganizacao
                                            select org
                ).FirstOrDefaultAsync();

            return organizacaoUsuario;
        }

        public async Task<OrganizacaoUsuario> BuscarPorOrganizacao(Guid idOrganizacao, string email)
        {
            var organizacaoUsuario = await (from org in _appContext.OrganizacaoUsuarios
                                            join p in _appContext.Pessoas on org.IdPessoa equals p.Id
                                            where p.Email.Equals(email) && org.IdOrganizacao == idOrganizacao
                                            select org
                ).FirstOrDefaultAsync();

            return organizacaoUsuario;
        }

    }
}
