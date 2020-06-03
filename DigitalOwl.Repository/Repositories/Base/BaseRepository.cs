using System;
using DigitalOwl.Repository.Interface.Base;

namespace DigitalOwl.Repository.Repositories.Base
{
    [Obsolete("Use Generic")]
    public class BaseRepository
    {
        protected readonly IDbContext _dbContext;

        public BaseRepository(IDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        
        
    }
}