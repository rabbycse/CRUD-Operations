using Microsoft.EntityFrameworkCore;
using StudentApp.Data.Data;
using StudentApp.Data.Data.Entities;
using StudentApp.Data.Extensions;
using StudentApp.Data.Services;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace StudentApp.Data.ViewModels
{
    public abstract class ViewModelBase<TService, TUnitOfWork, TEntity, TKey, TContext, TRepository>
        where TEntity : EntityBase<TKey>
        where TContext : DbContext
        where TRepository : RepositoryBase<TEntity, TKey, TContext>, IRepository<TEntity, TKey>
        where TUnitOfWork : UnitOfWorkBase<TEntity, TKey, TContext, TRepository>
        where TService : DataServiceBase<TUnitOfWork, TEntity, TKey, TContext, TRepository>
    {
        protected TService _Service;

        public void SetService(TService service)
        {
            _Service = service;
        }

        public abstract void Read(Expression<Func<TEntity, bool>> filter = null);
    }
}
