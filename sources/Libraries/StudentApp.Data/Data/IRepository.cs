using StudentApp.Data.Data.Entities;
using System;
using System.Linq;
using System.Linq.Expressions;

namespace StudentApp.Data.Data
{
    public interface IRepository<TEntity, TKey>
         : IDisposable
         where TEntity : EntityBase<TKey>
    {
        void Create(TEntity entity);
        IQueryable<TEntity> Read(Expression<Func<TEntity, bool>> filter = null);
        void Update(TEntity entity);
        void Delete(TEntity entity);
    }
}