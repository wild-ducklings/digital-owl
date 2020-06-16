using System;
using System.Threading.Tasks;

namespace DigitalOwl.Repository.Interface.Base
{
    public interface IUnitOfWork : IDisposable
    {
        public void SaveChanges();
        public Task<int> SaveChangesAsync();
        
        /// <summary>
        /// Poll repository access point.
        /// </summary>
        public IPollRepository PollRepository { get; }

        public IGroupRepository GroupRepository { get; }
    }
}