using DigitalOwl.Repository.Entity;
using DigitalOwl.Repository.Interface;
using DigitalOwl.Repository.Interface.Base;
using DigitalOwl.Repository.Repositories.Base;

namespace DigitalOwl.Repository.Repositories
{
    /// <summary>
    /// repo to GropRole
    /// </summary>
    public class GroupRoleRepository : GenericRepository<GroupRole>, IGroupRoleRepository
    {
        /// <summary>
        /// ctor
        /// </summary>
        /// <param name="dbContext"></param>
        public GroupRoleRepository(IDbContext dbContext) : base(dbContext)
        {
        }
    }
}