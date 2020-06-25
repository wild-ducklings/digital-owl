using DigitalOwl.Repository.Entity;
using DigitalOwl.Repository.Interface;
using DigitalOwl.Repository.Interface.Base;
using DigitalOwl.Repository.Repositories.Base;

namespace DigitalOwl.Repository.Repositories
{
    /// <summary>
    /// GroupMessage access point.
    /// </summary>
    public class GroupMessageRepository : GenericRepository<GroupMessage>, IGroupMessageRepository
    {
        /// <summary>
        /// ctor.
        /// </summary>
        /// <param name="dbContext"></param>
        public GroupMessageRepository(IDbContext dbContext) : base(dbContext)
        {
        }
    }
}