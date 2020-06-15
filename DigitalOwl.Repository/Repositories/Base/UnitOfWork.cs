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

        #region PollRepository

        private IPollRepository _pollRepository;
        /// <summary>
        /// Poll repository access point.
        /// </summary>
        public IPollRepository PollRepository
        {
            get { return _pollRepository ??= new PollRepository(_dbContext); }
        }

        #endregion
    }
}