using Coti.Domain.Interface.Repository;
using Coti.Domain.Interface.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Coti.Domain.Services
{
    public abstract class BaseDomainService<TEntity> : IBaseDomainService<TEntity>
        where TEntity : class
    {
        private readonly IBaseRepository<TEntity> baseRepository;

        protected BaseDomainService(IBaseRepository<TEntity> baseRepository)
        {
            this.baseRepository = baseRepository;
        }

        public virtual TEntity Post(TEntity entity)
        {
            return baseRepository.Post(entity);
        }

        public virtual void Put(TEntity entity)
        {
            baseRepository.Put(entity);
        }

        public virtual void Delete(TEntity entity)
        {
            baseRepository.Delete(entity);
        }

        public virtual IQueryable<TEntity> Query(Expression<Func<TEntity, bool>> filter = null)
        {
            return baseRepository.Query(filter);
        }

        public virtual TEntity Get(object id)
        {
            return baseRepository.Get(id);
        }

        public virtual void Dispose()
        {
            baseRepository.Dispose();
        }
    }
}
