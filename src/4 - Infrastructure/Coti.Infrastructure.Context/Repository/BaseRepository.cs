using Coti.Domain.Interface.Repository;
using Coti.Infrastructure.Context.Base;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Coti.Infrastructure.Context.Repository
{
    public class BaseRepository<TEntity> : IBaseRepository<TEntity>
        where TEntity : class
    {
        private readonly CotiContext CotiContext;
        protected readonly DbSet<TEntity> EntitySet;

        protected BaseRepository(CotiContext cotiContext)
        {
            this.CotiContext = cotiContext;
            EntitySet = cotiContext.Set<TEntity>();
        }

        public virtual TEntity Get(object id)
        {
            // return CotiContext.Set<TEntity>().Find(id);
            return EntitySet.Find(id);
        }

        public virtual TEntity Get(Expression<Func<TEntity, bool>> filter)
        {
            // return CotiContext.Set<TEntity>().FirstOrDefault(filter);
            return EntitySet.Where(filter).FirstOrDefault();
        }

        public virtual TEntity Post(TEntity entity)
        {
            CotiContext.Entry(entity).State = EntityState.Added;
            CotiContext.SaveChanges();

            return entity;
        }

        public virtual void Put(TEntity entity)
        {
            CotiContext.Entry(entity).State = EntityState.Modified;
            CotiContext.SaveChanges();
        }

        public virtual void Delete(TEntity entity)
        {
            CotiContext.Entry(entity).State = EntityState.Deleted;
            CotiContext.SaveChanges();
        }

        public virtual IQueryable<TEntity> Query(Expression<Func<TEntity, bool>> filter = null)
        {
            if (filter == null)
            {
                // return CotiContext.Set<TEntity>().Where(filter);
                return EntitySet.AsNoTracking();
            }
            else
            {
                // return CotiContext.Set<TEntity>();
                return EntitySet.Where(filter).AsNoTracking();
            }
        }

        public virtual int Count()
        {
            // return CotiContext.Set<TEntity>().Count();
            return EntitySet.Count();
        }

        public virtual int Count(Expression<Func<TEntity, bool>> filter)
        {
            // return CotiContext.Set<TEntity>().Count(filter);
            return EntitySet.Count(filter);
        }

        public virtual void Dispose()
        {
            CotiContext.Dispose();
        }
    }
}
