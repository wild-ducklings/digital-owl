using System;
using System.Threading.Tasks;

namespace DigitalOwl.Repository.Interface.Base
{
    public interface IUnitOfWork : IDisposable
    {
        public void SaveChanges();
        public Task<int> SaveChangesAsync();

        public IGroupRepository GroupRepository { get; }
    }
}