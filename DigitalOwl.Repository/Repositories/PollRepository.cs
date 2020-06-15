using DigitalOwl.Repository.Entity;
using DigitalOwl.Repository.Interface;
using DigitalOwl.Repository.Interface.Base;
using DigitalOwl.Repository.Repositories.Base;

namespace DigitalOwl.Repository.Repositories
{
    /// <summary>
    /// Handling poll repository in database.
    /// </summary>
    public class PollRepository : GenericRepository<Poll>, IPollRepository
    {
        /// <summary>
        /// Poll repository ctor.
        /// </summary>
        /// <param name="dbContext"></param>
        public PollRepository(IDbContext dbContext) : base(dbContext)
        {
        }
    }
}