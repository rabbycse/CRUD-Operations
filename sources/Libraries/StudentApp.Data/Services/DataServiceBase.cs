using Microsoft.EntityFrameworkCore;
using StudentApp.Data.Data;
using StudentApp.Data.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace StudentApp.Data.Services 
{
    public abstract class DataServiceBase<TUnitOfWork, TEntity, TKey, TContext, TRepository>
         where TEntity : EntityBase<TKey>
         where TContext : DbContext
         where TRepository : RepositoryBase<TEntity, TKey, TContext>, IRepository<TEntity, TKey>
         where TUnitOfWork : UnitOfWorkBase<TEntity, TKey, TContext, TRepository>

    {
        protected TUnitOfWork _Uow;
        protected DataServiceBase(TUnitOfWork uow)
        {
            _Uow = uow;
        }

        public abstract IQueryable<TEntity> Read(Expression<Func<TEntity, bool>> filter = null);
    }
}
