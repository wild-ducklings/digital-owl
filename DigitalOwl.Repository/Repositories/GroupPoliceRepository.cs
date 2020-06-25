using DigitalOwl.Repository.Entity;
using DigitalOwl.Repository.Interface;
using DigitalOwl.Repository.Interface.Base;
using DigitalOwl.Repository.Repositories.Base;

namespace DigitalOwl.Repository.Repositories
{
    /// <summary>
    /// Repo to GroupPolice
    /// </summary>
    public class GroupPoliceRepository:GenericRepository<GroupPolice>,IGroupPoliceRepository
    {
        /// <summary>
        /// ctor
        /// </summary>
        /// <param name="dbContext"></param>
        public GroupPoliceRepository(IDbContext dbContext) : base(dbContext)
        {
        }
    }
}