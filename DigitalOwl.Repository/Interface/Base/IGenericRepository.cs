using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using DigitalOwl.Repository.Interface.Entity;

namespace DigitalOwl.Repository.Interface.Base
{
    public interface IGenericRepository<TEntity> where TEntity : class
    {
        TEntity Create(TEntity t);
        IEnumerable<TEntity> Create(IEnumerable<TEntity> t);
        int Count();
        Task<int> CountAsync();
        void Delete(TEntity entity);
        void DeleteRange(IEnumerable<TEntity> entities);
        void Dispose();
        TEntity Find(Expression<Func<TEntity, bool>> match);
        IEnumerable<TEntity> FindAll(Expression<Func<TEntity, bool>> predicate);
        IEnumerable<TEntity> FindAll(List<Expression<Func<TEntity, bool>>> predicate);
        Task<IEnumerable<TEntity>> FindAllAsync(Expression<Func<TEntity, bool>> predicate);
        Task<IEnumerable<TEntity>> FindAllAsync(List<Expression<Func<TEntity, bool>>> predicate);
        Task<TEntity> FindAsync(Expression<Func<TEntity, bool>> predicate);
        IQueryable<TEntity> FindBy(Expression<Func<TEntity, bool>> predicate);
        IQueryable<TEntity> FindBy(List<Expression<Func<TEntity, bool>>> predicate);
        TEntity Get(int id);
        IQueryable<TEntity> GetAll();
        IQueryable<TEntity> GetAll(Expression<Func<TEntity, bool>> predicate);
        Task<IEnumerable<TEntity>> GetAllAsync();
        IQueryable<TEntity> GetAllIncluding(params Expression<Func<TEntity, object>>[] includeProperties);
        Task<TEntity> GetAsync(int id);
        TEntity Update(TEntity t, object key);
    }
}