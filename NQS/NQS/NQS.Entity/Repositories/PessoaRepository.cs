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
    public class PessoaRepository : Repository<Pessoa>, IPessoaRepository
    {
        private goobeeteamsContext _appContext => (goobeeteamsContext)_context;

        public PessoaRepository(goobeeteamsContext context) : base(context)
        { }

        public IEnumerable<Pessoa> GetTopPessoas(Expression<Func<Pessoa, bool>> predicate, int count)
        {
            return _appContext.Pessoas
                .Include(c => c.PessoaClientes)
                .ThenInclude(o => o.Cliente)
                //.Include(c => c.PessoaCheckpoints)
                .Include(x => x.Organizacoes)
                .Include(x => x.TimePessoas)
                .Where(predicate)
                .OrderBy(x => x.Nome)
                .Take(count);
        }

        public IEnumerable<Pessoa> PegarTodasPessoas(Guid idOrganizacao)
        {
            return _appContext.Pessoas
                .Where(x => x.Organizacoes.Any(x => x.IdOrganizacao == idOrganizacao)).OrderBy(x => x.Nome);
        }

        public IEnumerable<Pessoa> PegarTodasPessoasNaoInclusivoSemUsuario(Guid? idPessoa, Guid idOrganizacao)
        {
            if (idPessoa.HasValue)
            {
                return _appContext.Pessoas
                    .Where(x => x.Organizacoes.Any(x => x.IdOrganizacao == idOrganizacao && x.Ativo) && x.Id != idPessoa.Value).OrderBy(x => x.Nome);
            }
            else
            {
                return _appContext.Pessoas
                    .Where(x => x.Organizacoes.Any(x => x.IdOrganizacao == idOrganizacao && x.Ativo)).OrderBy(x => x.Nome);
            }
        }

        public IEnumerable<Pessoa> PegarTodasPessoasNaoInclusivo(Guid idPessoa, Guid idOrganizacao)
        {
            return _appContext.Pessoas
                .Where(x => x.Organizacoes.Any(x => x.IdOrganizacao == idOrganizacao && x.UsuarioPlataforma && x.Ativo) && x.Id != idPessoa).OrderBy(x => x.Nome);
        }

        public Pessoa PegarPessoaComTimePessoasTime(Expression<Func<Pessoa, bool>> predicate)
        {
            return _appContext.Pessoas
                .Include(x => x.TimePessoas)
                    .ThenInclude(x => x.Time)
                .SingleOrDefault(predicate);
        }

        public Pessoa PegarPessoaComTimePessoas(Expression<Func<Pessoa, bool>> predicate)
        {
            return _appContext.Pessoas
                .Include(x => x.TimePessoas)
                .SingleOrDefault(predicate);
        }

        //public Pessoa PegarPerfilPessoa(Expression<Func<Pessoa, bool>> predicate)
        //{
        //    return _appContext.Pessoas
        //        .Include(x => x.PessoaClientes)
        //            .ThenInclude(x => x.Cliente)
        //        .Include(x => x.PessoaCheckpoints)
        //        .Include(x => x.Convites)
        //        .Include(x => x.Organizacoes)
        //        .SingleOrDefault(predicate);
        //}

        public Task<Pessoa> BuscarPessoaPorId(Guid idPessoa)
        {
            return _appContext.Pessoas
                .Include(x => x.Organizacoes)
                .FirstOrDefaultAsync(x=>x.Id == idPessoa);
        }

        public Task<Pessoa> GetPorId(Guid id, Guid idOrganizacao)
        {
            return _appContext.Pessoas
                .Where(x => x.Id == id && x.Organizacoes.Any(x => x.IdOrganizacao == idOrganizacao))
                .Include(x => x.PessoaClientes)
                .FirstOrDefaultAsync();
        }

        public Task<Pessoa> GetPorIdComUsuario(Guid idPessoa, Guid idOrganizacao)
        {
            return _appContext.Pessoas
                .Where(x => x.Id == idPessoa && x.Organizacoes.Any(x => x.IdOrganizacao == idOrganizacao))
                .FirstOrDefaultAsync();
        }

        public async Task<List<OrganizacaoUsuario>> BuscarOrganizacoes(string pessoaEmail)
        {
            var pessoa = await _appContext.Pessoas
                .Include(x => x.Organizacoes)
                .FirstOrDefaultAsync(x => x.Email == pessoaEmail);
            
            return  pessoa.Organizacoes.ToList();
        }

        public async Task<Pessoa> BuscarPorEmail(string email)
        {
            try
            {
                var pessoa = await _appContext.Pessoas
                    .Include(x => x.Organizacoes)
                    .FirstOrDefaultAsync(x => x.Email == email);
                return pessoa;
            }
            catch (Exception e)
            {
                return null;
            }
        }
    }
}
