using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Coti.Domain.Interface.Repository
{
    public interface IBaseRepository<TEntity> : IDisposable
        where TEntity : class
    {
        IQueryable<TEntity> Query(Expression<Func<TEntity, bool>> filter = null);
        TEntity Post(TEntity entity);
        void Put(TEntity entity);
        void Delete(TEntity entity);
        TEntity Get(object id);
        TEntity Get(Expression<Func<TEntity, bool>> filter);
        int Count();
        int Count(Expression<Func<TEntity, bool>> filter);
    }
}
