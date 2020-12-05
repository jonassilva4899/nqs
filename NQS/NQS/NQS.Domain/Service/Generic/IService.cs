using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Leega.Domain.Service
{
    public interface IService<Tv, Te>
    {
        IEnumerable<Tv> GetAll();
        Guid Add(Tv obj);
        int Update(Tv obj);
        int Remove(Guid id);
        Tv GetOne(Guid id);
        IEnumerable<Tv> Get(Expression<Func<Te, bool>> predicate);
    }
}
