using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Leega.Entity.Repository
{
    //public interface IRepository<TEntity> where TEntity : class
    //{
    //    void Add(TEntity entity);
    //    void AddRange(IEnumerable<TEntity> entities);

    //    void Update(TEntity entity);
    //    void UpdateRange(IEnumerable<TEntity> entities);

    //    void Remove(TEntity entity);
    //    void RemoveRange(IEnumerable<TEntity> entities);

    //    int Count();

    //    IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate);
    //    TEntity GetSingleOrDefault(Expression<Func<TEntity, bool>> predicate);
    //    TEntity Get(Guid id);
    //    IEnumerable<TEntity> GetAll();
    //    int Save();
    //}

    public interface IRepository<T> where T : class
    {
        IEnumerable<T> GetAll();
        IEnumerable<T> Get(Expression<Func<T, bool>> predicate);
        T GetOne(Expression<Func<T, bool>> predicate);
        void Insert(T entity);
        void Delete(T entity);
        void Delete(object id);
        void Update(object id, T entity);
    }
}
