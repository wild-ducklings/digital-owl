using DigitalOwl.Repository.Entity;
using DigitalOwl.Repository.Interface;
using DigitalOwl.Repository.Interface.Base;
using DigitalOwl.Repository.Repositories.Base;

namespace DigitalOwl.Repository.Repositories
{
    /// <summary>
    /// Poll question repository.
    /// </summary>
    public class PollQuestionRepository : GenericRepository<PollQuestion>, IPollQuestionRepository
    {
        /// <summary>
        /// Poll question ctor.
        /// </summary>
        /// <param name="dbContext"></param>
        public PollQuestionRepository(IDbContext dbContext) : base(dbContext)
        {
        }
    }
}