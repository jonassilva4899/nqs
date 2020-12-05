using Leega.Entity.Context;
using Leega.Entity.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Leega.Entity.Repositories
{
    public class TimePessoaRepository : Repository<TimePessoa>, ITimePessoaRepository
    {
        private goobeeteamsContext _appContext => (goobeeteamsContext)_context;

        public TimePessoaRepository(goobeeteamsContext context) : base(context)
        { }

        //public IEnumerable<TimePessoa> PegarTimePessoasSentimentos(Expression<Func<TimePessoa, bool>> predicate)
        //{
        //    return _appContext.TimePessoas
        //        .Include(x => x.Pessoa)
        //            .ThenInclude(x => x.SentimentosPessoa)
        //        .Where(predicate);

        //}

        public IEnumerable<TimePessoa> PegarPessoasEnvioEmail(Guid idTime, Guid idOrganizacao)
        {
            return _appContext.TimePessoas
                .Include(x => x.Pessoa)
                .ThenInclude(x => x.Organizacoes)
                .Where(x => x.IdTime.Equals(idTime)
                && x.IdOrganizacao.Equals(idOrganizacao)
                && x.Status).Distinct();
        }

        public IEnumerable<TimePessoa> PegarTimePessoasSentimentos(Expression<Func<TimePessoa, bool>> predicate)
        {
            throw new NotImplementedException();
        }

     
    }


}
