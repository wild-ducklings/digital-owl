using DigitalOwl.Repository.Entity;
using DigitalOwl.Repository.Interface;
using DigitalOwl.Repository.Interface.Base;
using DigitalOwl.Repository.Repositories.Base;

namespace DigitalOwl.Repository.Repositories
{
    /// <summary>
    /// Poll answer repository.
    /// </summary>
    public class PollAnswerRepository : GenericRepository<PollAnswer>, IPollAnswerRepository
    {
        /// <summary>
        /// Poll answer ctor.
        /// </summary>
        /// <param name="dbContext"></param>
        public PollAnswerRepository(IDbContext dbContext) : base(dbContext)
        {
        }
    }
}