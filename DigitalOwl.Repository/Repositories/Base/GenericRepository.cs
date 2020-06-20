using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using DigitalOwl.Repository.Interface.Base;
using DigitalOwl.Repository.Interface.Entity;
using Microsoft.EntityFrameworkCore;

namespace DigitalOwl.Repository.Repositories.Base
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class, IEntity
    {
        protected readonly IDbContext _dbContext;

        public GenericRepository(IDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IQueryable<TEntity> GetAll()
        {
            return _dbContext.Set<TEntity>();
        }
        
        public IQueryable<TEntity> GetAll(Expression<Func<TEntity, bool>> predicate)
        {
            return _dbContext.Set<TEntity>().Where(predicate);
        }

        public virtual async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            return await _dbContext.Set<TEntity>().ToListAsync();
        }

        public virtual TEntity Get(int id)
        {
            return _dbContext.Set<TEntity>().Find(id);
        }

        public virtual async Task<TEntity> GetAsync(int id)
        {
            return await _dbContext.Set<TEntity>().FindAsync(id);
        }

        public virtual TEntity Create(TEntity t)
        {
            _dbContext.Set<TEntity>().Add(t);
            return t;
        }

        public virtual IEnumerable<TEntity> Create(IEnumerable<TEntity> t)
        {
            _dbContext.Set<TEntity>().AddRange(t);
            return t;
        }

        public virtual TEntity Find(Expression<Func<TEntity, bool>> match)
        {
            return _dbContext.Set<TEntity>().SingleOrDefault(match);
        }

        public virtual async Task<TEntity> FindAsync(Expression<Func<TEntity, bool>> match)
        {
            return await _dbContext.Set<TEntity>().SingleOrDefaultAsync(match);
        }

        public IEnumerable<TEntity> FindAll(Expression<Func<TEntity, bool>> match)
        {
            return _dbContext.Set<TEntity>().Where(match).ToList();
        }

        public async Task<IEnumerable<TEntity>> FindAllAsync(Expression<Func<TEntity, bool>> match)
        {
            return await _dbContext.Set<TEntity>().Where(match).ToListAsync();
        }

        public virtual void Delete(TEntity entity)
        {
            _dbContext.Set<TEntity>().Remove(entity);
        }

        public void DeleteRange(IEnumerable<TEntity> entities)
        {
            _dbContext.Set<TEntity>().RemoveRange(entities);
        }

        public virtual TEntity Update(TEntity t, object key)
        {
            if (t == null)
                return null;
            TEntity exist = _dbContext.Set<TEntity>().Find(key);
            if (exist != null)
            {
                _dbContext.Entry(exist).CurrentValues.SetValues(t);
            }

            return exist;
        }

        public int Count()
        {
            return _dbContext.Set<TEntity>().Count();
        }

        public async Task<int> CountAsync()
        {
            return await _dbContext.Set<TEntity>().CountAsync();
        }

        public virtual IQueryable<TEntity> FindBy(Expression<Func<TEntity, bool>> predicate)
        {
            IQueryable<TEntity> query = _dbContext.Set<TEntity>().Where(predicate);
            return query;
        }

        public IQueryable<TEntity> GetAllIncluding(params Expression<Func<TEntity, object>>[] includeProperties)
        {
            IQueryable<TEntity> queryable = GetAll();
            foreach (Expression<Func<TEntity, object>> includeProperty in includeProperties)
            {
                queryable = queryable.Include<TEntity, object>(includeProperty);
            }

            return queryable;
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _dbContext.Dispose();
                }

                this.disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public IEnumerable<TEntity> FindAll(List<Expression<Func<TEntity, bool>>> filters)
        {
            var queryable = _dbContext.Set<TEntity>().AsQueryable();
            queryable = filters.Aggregate(queryable, (current, filter) => current.Where(filter));

            return queryable.ToList();
        }

        public async Task<IEnumerable<TEntity>> FindAllAsync(List<Expression<Func<TEntity, bool>>> filters)
        {
            var queryable = _dbContext.Set<TEntity>().AsQueryable();
            queryable = filters.Aggregate(queryable, (current, filter) => current.Where(filter));

            return await queryable.ToListAsync();
        }

        public IQueryable<TEntity> FindBy(List<Expression<Func<TEntity, bool>>> predicate)
        {
            var queryable = _dbContext.Set<TEntity>().AsQueryable();
            queryable = predicate.Aggregate(queryable, (current, filter) => current.Where(filter));
            return queryable;
        }
    }
}