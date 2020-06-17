using DigitalOwl.Repository.Entity;
using DigitalOwl.Repository.Interface;
using DigitalOwl.Repository.Interface.Base;
using DigitalOwl.Repository.Repositories.Base;

namespace DigitalOwl.Repository.Repositories
{
    /// <summary>
    /// GroupMember access point
    /// </summary>
    public class GroupMemberRepository : GenericRepository<GroupMember>, IGroupMemberRepository
    {
        /// <summary>
        /// ctor
        /// </summary>
        /// <param name="dbContext">DI - inject ef connection with db</param>
        public GroupMemberRepository(IDbContext dbContext) : base(dbContext)
        {
        }
    }
}