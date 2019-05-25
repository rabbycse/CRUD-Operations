using System;
using System.Linq;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using StudentApp.Data.Data.Entities;

namespace StudentApp.Data.Data
{
    public abstract class RepositoryBase<TEntity, TKey, TContext>
        : IRepository<TEntity, TKey>
        where TEntity : EntityBase<TKey>
        where TContext : DbContext
    {
        protected TContext _Context;
        protected DbSet<TEntity> _DbSet;

        protected RepositoryBase(TContext context)
        {
            _Context = context;
            _DbSet = context.Set<TEntity>();
        }

        public void Create(TEntity entity)
        {
            _DbSet.Add(entity);
        }

        public void Delete(TEntity entity)
        {
            _DbSet.Remove(entity);
        }

        public void Dispose()
        {
            if (_Context != null)
            {
                _Context.Dispose();
            }
        }

        public IQueryable<TEntity> Read(Expression<Func<TEntity, bool>> filter = null)
        {
            IQueryable<TEntity> query;
            if (filter is null)
            {
                query = _DbSet;
            }
            else
            {
                query = _DbSet.Where(filter);
            }
            return query;
        }

        public void Update(TEntity entity)
        {
            _DbSet.Attach(entity);
            _Context.Entry(entity).State = EntityState.Modified;
        }
    }
}