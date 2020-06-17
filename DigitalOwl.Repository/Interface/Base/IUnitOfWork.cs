using System;
using System.Threading.Tasks;

namespace DigitalOwl.Repository.Interface.Base
{
    /// <summary>
    /// Class wrap up all Repositories make easier to use in Services
    /// </summary>
    public interface IUnitOfWork : IDisposable
    {
        /// <summary>
        /// Sync save method
        /// </summary>
        public void SaveChanges();
        /// <summary>
        /// Async save method
        /// </summary>
        /// <returns></returns>
        public Task<int> SaveChangesAsync();
        
        /// <summary>
        /// Poll repository access point.
        /// </summary>
        public IPollRepository PollRepository { get; }

        /// <summary>
        /// Group repository access point.
        /// </summary>
        public IGroupRepository GroupRepository { get; }
        
        /// <summary>
        /// GroupMember repository access point.
        /// </summary>
        public IGroupMemberRepository GroupMemberRepository { get; }
    }
}