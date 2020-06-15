using DigitalOwl.Repository.Entity;
using DigitalOwl.Repository.Interface;
using DigitalOwl.Repository.Interface.Base;
using DigitalOwl.Repository.Repositories.Base;

namespace DigitalOwl.Repository.Repositories
{
    /// <summary>
    /// Group access point
    /// </summary>
    public class GroupRepository : GenericRepository<Group>, IGroupRepository
    {
        /// <summary>
        /// Ctor 
        /// </summary>
        /// <param name="dbContext"></param>
        public GroupRepository(IDbContext dbContext) : base(dbContext)
        {
        }
    }
}