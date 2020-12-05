using Leega.Entity.Context;
using Leega.Entity.Repositories.Interfaces;
using System.Linq;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Leega.Entity.Enums;

namespace Leega.Entity.Repositories
{
    public class TimeRepository : Repository<Time>, ITimeRepository
    {
        private goobeeteamsContext _appContext => (goobeeteamsContext)_context;

        public TimeRepository(goobeeteamsContext context) : base(context)
        { }

        public IEnumerable<Time> PegarTodosTimes(Guid idOrganizacao)
        {
            _appContext.ChangeTracker.LazyLoadingEnabled = false;

            var times = (from t in _appContext.Times
                         join tp in _appContext.TimePessoas on t.Id equals tp.IdPessoa into _tp
                         from tp in _tp.DefaultIfEmpty()
                         join p in _appContext.Pessoas on tp.IdPessoa equals p.Id into _p
                         from p in _p.DefaultIfEmpty()
                         where t.IdOrganizacao == idOrganizacao
                         select t).Include(x => x.TimePessoas).ToList();

            _appContext.ChangeTracker.LazyLoadingEnabled = true;
            return times;
        }

        public async Task<IEnumerable<Time>> PegarTodosTimesPB(Expression<Func<Time, bool>> predicate)
        {
            return await _appContext.Times
                .Include(x => x.TimePessoas)
                .Where(predicate)
                .ToListAsync();
        }

        //public IEnumerable<Time> PegarTodosTimes(Expression<Func<Time, bool>> predicate)
        //{
        //    return _appContext.Times
        //        .Include(x => x.TimePessoas)
        //            .ThenInclude(x => x.Pessoa)
        //                .ThenInclude(x => x.Organizacoes)
        //                    .ThenInclude(x => x.Pessoa)
        //        .Include(x => x.TimePessoas)
        //            .ThenInclude(x => x.Pessoa)
        //                .ThenInclude(x => x.Organizacoes)
        //                    .ThenInclude(x => x.Usuario)
        //        .Include(x => x.TimeProjetos)
        //        .Where(predicate);
        //}

        public IEnumerable<Time> PegarTodosTimesComMembros()
        {
            return _appContext.Times
                .Include(x => x.TimePessoas)
                .ThenInclude(x => x.Pessoa)
                .ThenInclude(x => x.Organizacoes)
                .ThenInclude(x => x.Usuario);
        }

        public IEnumerable<Time> PegarTimesComMembros(Expression<Func<Time, bool>> predicate)
        {
            return _appContext.Times
                .Include(x => x.TimePessoas)
                .ThenInclude(x => x.Pessoa)
                .ThenInclude(x => x.Organizacoes)
                .Where(predicate);
        }

        public Time PegarUmTimeComMembros(Expression<Func<Time, bool>> predicate)
        {
            return _appContext.Times
                .Include(x => x.TimePessoas)
                .ThenInclude(x => x.Pessoa)
                .ThenInclude(x => x.Organizacoes)
                .SingleOrDefault(predicate);
        }

        public Time PegarUmTimeApenasComMembros(Expression<Func<Time, bool>> predicate)
        {
            return _appContext.Times
                .Include(x => x.TimePessoas)
                    .ThenInclude(x => x.Pessoa)
                .SingleOrDefault(predicate);
        }

        public Time PegarUmTimeComTimePessoas(Expression<Func<Time, bool>> predicate)
        {
            return _appContext.Times
                .Include(x => x.TimePessoas)
                .SingleOrDefault(predicate);
        }

        public List<Time> PegarTimesPessoaComFotoComboBox(Expression<Func<Time, bool>> predicate)
        {
            return _appContext.Times
                .Include(x => x.TimePessoas)
                .Where(predicate)
                .ToList();
        }

        public IEnumerable<Time> PegarTodosTimesComTimePessoas()
        {
            return _appContext.Times
                .Include(x => x.TimePessoas);
        }

        public IEnumerable<Time> GetTimeAtributos(Expression<Func<Time, bool>> predicate)
        {
            return _appContext.Times
                .Include(x => x.TimeGrupos)
                .Where(predicate);
        }

        public Task<Time> PegarPorId(Guid id, Guid idOrganizacao)
        {
            return _appContext.Times.Where(x => x.Id == id && x.IdOrganizacao == idOrganizacao)
                .Include(x => x.TimePessoas)
                .ThenInclude(x => x.Pessoa)
                .Include(x => x.TimeGrupos)
                    .ThenInclude(x => x.Grupo)
                .FirstOrDefaultAsync();
        }

        public IEnumerable<Time> PegarTodosTimes(Expression<Func<Time, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public Task<Time> PegarUmTimeComDaily(Guid idTime, Guid idOrganizacao)
        {
            throw new NotImplementedException();
        }

        public Task<Time> PegarUmTimeComPlanning(Guid idTime, Guid idOrganizacao)
        {
            throw new NotImplementedException();
        }

        public Task<Time> PegarUmTimeComRetrospectiva(Guid idTime, Guid idOrganizacao)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Time> PegarTimesComProjetos(Expression<Func<Time, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Time> PegarTimesComPraticasPessoas(Expression<Func<Time, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Time> PegarTimesComMelhoriaContinua(Expression<Func<Time, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        //public Task<Time> PegarUmTimeComDaily(Guid idTime, Guid idOrganizacao)
        //{
        //    return _appContext.Times
        //            .Include(x => x.Dailies)
        //            .Include(x => x.DailyConfiguracao)
        //            .Include(x => x.PraticaAgilTimes)
        //            .Where(x => x.Id == idTime && x.IdOrganizacao == idOrganizacao && x.DailyConfiguracao != null
        //                    && x.PraticaAgilTimes.Any(x => x.IdTime == idTime && x.Status == true && x.PraticaAgil.Chave == ChavePraticasAgeis.Daily.Value)).SingleOrDefaultAsync();
        //}

        //public Task<Time> PegarUmTimeComPlanning(Guid idTime, Guid idOrganizacao)
        //{
        //    return _appContext.Times
        //            .Include(x => x.Plannings)
        //            .Include(x => x.PlanningConfiguracao)
        //            .Include(x => x.PraticaAgilTimes)
        //            .Where(x => x.Id == idTime && x.IdOrganizacao == idOrganizacao && x.PlanningConfiguracao != null
        //                    && x.PraticaAgilTimes.Any(x => x.IdTime == idTime && x.Status == true && x.PraticaAgil.Chave == ChavePraticasAgeis.Planning.Value)).SingleOrDefaultAsync();
        //}

        ////public Task<Time> PegarUmTimeComRetrospectiva(Guid idTime, Guid idOrganizacao)
        ////{
        ////    return _appContext.Times
        ////               .Include(x => x.Retrospectivas)
        ////               .Include(x => x.RetrospectivaConfiguracao)
        ////               .Include(x => x.PraticaAgilTimes)
        ////               .Where(x => x.Id == idTime && x.IdOrganizacao == idOrganizacao && x.RetrospectivaConfiguracao != null
        ////                    && x.PraticaAgilTimes.Any(x => x.IdTime == idTime && x.Status == true && x.PraticaAgil.Chave == ChavePraticasAgeis.Retrospectiva.Value)).SingleOrDefaultAsync();
        ////}

        //public IEnumerable<Time> PegarTimesComProjetos(Expression<Func<Time, bool>> predicate)
        //{
        //    return _appContext.Times
        //        .Include(x => x.TimeProjetos)
        //            .ThenInclude(x => x.Projeto)
        //        .Where(predicate);
        //}

        //public IEnumerable<Time> PegarTimesComPraticasPessoas(Expression<Func<Time, bool>> predicate)
        //{
        //    return _appContext.Times
        //        .Include(x => x.PraticaAgilTimes)
        //            .ThenInclude(x => x.PraticaAgil)
        //        .Include(x => x.TimePessoas)
        //            .ThenInclude(x => x.Pessoa)
        //                .ThenInclude(x => x.Organizacoes)
        //        .Where(predicate);
        //}

        //public IEnumerable<Time> PegarTimesComMelhoriaContinua(Expression<Func<Time, bool>> predicate)
        //{
        //    return _appContext.Times
        //        .Include(x => x.PraticaAgilTimes)
        //            .ThenInclude(x => x.PraticaAgil)
        //        .Include(x => x.TimePessoas)
        //            .ThenInclude(x => x.Pessoa)
        //                .ThenInclude(x => x.Organizacoes)
        //        .Where(predicate);
        //}
    }
}
