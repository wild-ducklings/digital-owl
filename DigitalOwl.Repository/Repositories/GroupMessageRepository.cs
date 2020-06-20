using DigitalOwl.Repository.Entity;
using DigitalOwl.Repository.Interface;
using DigitalOwl.Repository.Interface.Base;
using DigitalOwl.Repository.Repositories.Base;

namespace DigitalOwl.Repository.Repositories
{
    public class GroupMessageRepository : GenericRepository<GroupMessage>, IGroupMessageRepository
    {
        public GroupMessageRepository(IDbContext dbContext) : base(dbContext)
        {
        }
    }
}