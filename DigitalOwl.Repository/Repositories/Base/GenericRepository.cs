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
    /// <summary>
    /// Generic repository. 
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class, IEntity
    {
        /// <summary>
        /// Access to database.
        /// </summary>
        protected readonly IDbContext _dbContext;

        /// <summary>
        /// Generic repository constructor.
        /// </summary>
        /// <param name="dbContext"></param>
        public GenericRepository(IDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        /// <summary>
        /// Method for getting all instances of an entity from database.
        /// </summary>
        /// <returns> List of queryable entities. </returns>
        public IQueryable<TEntity> GetAll()
        {
            return _dbContext.Set<TEntity>();
        }
        
        /// <summary>
        /// Method for getting all instances of an entity on certain condition.
        /// </summary>
        /// <param name="predicate"> Condition which specifies request. </param>
        /// <returns> List of queryable entities fulfilling the predicate. </returns>
        public IQueryable<TEntity> GetAll(Expression<Func<TEntity, bool>> predicate)
        {
            return _dbContext.Set<TEntity>().Where(predicate);
        }

        /// <summary>
        /// Asynchronous method for getting all instances of an entity from database.
        /// </summary>
        /// <returns> List of queryable entities. </returns>
        public virtual async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            return await _dbContext.Set<TEntity>().ToListAsync();
        }

        /// <summary>
        /// Method for getting entity of given id from database.
        /// </summary>
        /// <param name="id"> Id of requested entity. </param>
        /// <returns> Requested entity. </returns>
        public virtual TEntity Get(int id)
        {
            return _dbContext.Set<TEntity>().Find(id);
        }

        /// <summary>
        /// Asynchronous method for getting entity of given id from database.
        /// </summary>
        /// <param name="id"> Id of requested entity. </param>
        /// <returns> Requested entity. </returns>
        public virtual async Task<TEntity> GetAsync(int id)
        {
            return await _dbContext.Set<TEntity>().FindAsync(id);
        }

        /// <summary>
        /// Method for creating instance of the entity in database.
        /// </summary>
        /// <param name="t"> Entity to be created. </param>
        /// <returns> Created entity. </returns>
        public virtual TEntity Create(TEntity t)
        {
            _dbContext.Set<TEntity>().Add(t);
            return t;
        }

        /// <summary>
        /// Method for creating IEnumerable of instances of the entity in database.
        /// </summary>
        /// <param name="t"> IEnumerable of entities to be created. </param>
        /// <returns> Created entities. </returns>
        public virtual IEnumerable<TEntity> Create(IEnumerable<TEntity> t)
        {
            _dbContext.Set<TEntity>().AddRange(t);
            return t;
        }

        /// <summary>
        /// Method for finding element in database fulfilling predicate.
        /// </summary>
        /// <param name="match"> Predicate to be fulfilled. </param>
        /// <returns> One object fulfilling predicate. </returns>
        public virtual TEntity Find(Expression<Func<TEntity, bool>> match)
        {
            return _dbContext.Set<TEntity>().SingleOrDefault(match);
        }

        /// <summary>
        /// Asynchronous method for finding element in database fulfilling predicate.
        /// </summary>
        /// <param name="match"> Predicate to be fulfilled. </param>
        /// <returns> One object fulfilling predicate. </returns>
        public virtual async Task<TEntity> FindAsync(Expression<Func<TEntity, bool>> match)
        {
            return await _dbContext.Set<TEntity>().SingleOrDefaultAsync(match);
        }

        /// <summary>
        /// Method for finding all elements in database fulfilling predicate.
        /// </summary>
        /// <param name="match"> Predicate to be fulfilled. </param>
        /// <returns> Objects fulfilling predicate. </returns>
        public IEnumerable<TEntity> FindAll(Expression<Func<TEntity, bool>> match)
        {
            return _dbContext.Set<TEntity>().Where(match).ToList();
        }

        /// <summary>
        /// Asynchronous method for finding all elements in database fulfilling predicate.
        /// </summary>
        /// <param name="match"> Predicate to be fulfilled. </param>
        /// <returns> Objects fulfilling predicate. </returns>
        public async Task<IEnumerable<TEntity>> FindAllAsync(Expression<Func<TEntity, bool>> match)
        {
            return await _dbContext.Set<TEntity>().Where(match).ToListAsync();
        }

        /// <summary>
        /// Method for deleting instance of an object in database.
        /// </summary>
        /// <param name="entity"> Object to be deleted. </param>
        public virtual void Delete(TEntity entity)
        {
            _dbContext.Set<TEntity>().Remove(entity);
        }

        /// <summary>
        /// Method for deleting objects in database.
        /// </summary>
        /// <param name="entities"> Objects to be deleted. </param>
        public void DeleteRange(IEnumerable<TEntity> entities)
        {
            _dbContext.Set<TEntity>().RemoveRange(entities);
        }

        /// <summary>
        /// Method for updating an object in database.
        /// </summary>
        /// <param name="t"> Updated version of an object. </param>
        /// <param name="key"> Key of an object to be updated. </param>
        /// <returns> Updated object. </returns>
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

        /// <summary>
        /// Method counting number of object in database.
        /// </summary>
        /// <returns> Number of objects in database. </returns>
        public int Count()
        {
            return _dbContext.Set<TEntity>().Count();
        }

        /// <summary>
        /// Asynchronous method counting number of object in database.
        /// </summary>
        /// <returns> Number of objects in database. </returns>
        public async Task<int> CountAsync()
        {
            return await _dbContext.Set<TEntity>().CountAsync();
        }

        /// <summary>
        /// Find an object in database fulfilling the predicate.
        /// </summary>
        /// <param name="predicate"> Predicate for an object to be fulfilled. </param>
        /// <returns> List of queryable objects that fulfill the predicate. </returns>
        public virtual IQueryable<TEntity> FindBy(Expression<Func<TEntity, bool>> predicate)
        {
            IQueryable<TEntity> query = _dbContext.Set<TEntity>().Where(predicate);
            return query;
        }

        /// <summary>
        /// Get all objects from database including.
        /// </summary>
        /// <param name="includeProperties"> Properties to be included. </param>
        /// <returns> All objects from database including includeProperties.  </returns>
        public IQueryable<TEntity> GetAllIncluding(params Expression<Func<TEntity, object>>[] includeProperties)
        {
            IQueryable<TEntity> queryable = GetAll();
            foreach (Expression<Func<TEntity, object>> includeProperty in includeProperties)
            {
                queryable = queryable.Include<TEntity, object>(includeProperty);
            }

            return queryable;
        }

        /// <summary>
        /// 
        /// </summary>
        private bool disposed = false;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="disposing"></param>
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

        /// <summary>
        /// 
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// Find all objects filtered.
        /// </summary>
        /// <param name="filters"></param>
        /// <returns> List of requested objects. </returns>
        public IEnumerable<TEntity> FindAll(List<Expression<Func<TEntity, bool>>> filters)
        {
            var queryable = _dbContext.Set<TEntity>().AsQueryable();
            queryable = filters.Aggregate(queryable, (current, filter) => current.Where(filter));

            return queryable.ToList();
        }

        /// <summary>
        /// Asynchronous method Find all objects filtered.
        /// </summary>
        /// <param name="filters"></param>
        /// <returns> List of requested objects. </returns>
        public async Task<IEnumerable<TEntity>> FindAllAsync(List<Expression<Func<TEntity, bool>>> filters)
        {
            var queryable = _dbContext.Set<TEntity>().AsQueryable();
            queryable = filters.Aggregate(queryable, (current, filter) => current.Where(filter));

            return await queryable.ToListAsync();
        }

        /// <summary>
        /// Find objects fulfilling predicate.
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns> List of queryable objects. </returns>
        public IQueryable<TEntity> FindBy(List<Expression<Func<TEntity, bool>>> predicate)
        {
            var queryable = _dbContext.Set<TEntity>().AsQueryable();
            queryable = predicate.Aggregate(queryable, (current, filter) => current.Where(filter));
            return queryable;
        }
    }
}