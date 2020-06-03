using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using DigitalOwl.Repository.Interface.Entity;

namespace DigitalOwl.Repository.Interface.Base
{
    public interface IGenericRepository<TEntity> where TEntity : class, IEntity
    {
        TEntity Create(TEntity entity);
        Task<IEnumerable<TEntity>> GetAllAsync();
        Task<IEnumerable<TEntity>> FindAllAsync(Expression<Func<TEntity, bool>> predicate);
        Task<TEntity> FindAsync(Expression<Func<TEntity, bool>> match);
        TEntity Update(TEntity entity, object key);
        void Delete(TEntity entity);
        public void DeleteRange(IEnumerable<TEntity> entities);
    }
}