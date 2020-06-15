using System.Threading.Tasks;
using DigitalOwl.Repository.Interface;
using DigitalOwl.Repository.Interface.Base;

namespace DigitalOwl.Repository.Repositories.Base
{
    public class UnitOfWork : IUnitOfWork
    {
        # region .Ctor

        private readonly IDbContext _dbContext;

        public UnitOfWork(IDbContext ctx)
        {
            _dbContext = ctx;
        }

        #endregion

        #region DisposeMethods

        private bool _disposed;

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    _dbContext.Dispose();
                }
            }

            _disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
        }

        #endregion

        #region SaveMethods

        public void SaveChanges()
        {
            _dbContext.SaveChanges();
        }

        public Task<int> SaveChangesAsync()
        {
            return _dbContext.SaveChangesAsync();
        }

        #endregion

        private IGroupRepository _groupRepository;

        public IGroupRepository GroupRepository
        {
            get { return _groupRepository ??= new GroupRepository(_dbContext); }
        }
    }
}