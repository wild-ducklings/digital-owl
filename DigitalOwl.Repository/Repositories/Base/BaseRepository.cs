using System;
using DigitalOwl.Repository.Interface.Base;

namespace DigitalOwl.Repository.Repositories.Base
{
    /// <summary>
    /// Obsolete base repository.
    /// </summary>
    [Obsolete("Use Generic")]
    public class BaseRepository
    {
        /// <summary>
        /// Database access.
        /// </summary>
        protected readonly IDbContext _dbContext;

        /// <summary>
        /// Base repository constructor.
        /// </summary>
        /// <param name="dbContext"></param>
        public BaseRepository(IDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        
        
    }
}