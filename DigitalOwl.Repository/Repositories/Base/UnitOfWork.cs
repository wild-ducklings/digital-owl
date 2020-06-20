using System.Threading.Tasks;
using DigitalOwl.Repository.Interface;
using DigitalOwl.Repository.Interface.Base;

namespace DigitalOwl.Repository.Repositories.Base
{
    /// <summary>
    /// Class wrap up all Repositories make easier to use in Services
    /// </summary>
    public class UnitOfWork : IUnitOfWork
    {
        # region .Ctor

        private readonly IDbContext _dbContext;

        /// <summary>
        /// ctor
        /// </summary>
        /// <param name="ctx">Database context ef stuff</param>
        public UnitOfWork(IDbContext ctx)
        {
            _dbContext = ctx;
        }

        #endregion

        #region DisposeMethods

        private bool _disposed;

        /// <summary>
        /// Dispose method
        /// </summary>
        /// <param name="disposing"></param>
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

        /// <summary>
        /// Dispose method
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
        }

        #endregion

        #region SaveMethods

        /// <summary>
        /// Sync save method
        /// </summary>
        public void SaveChanges()
        {
            _dbContext.SaveChanges();
        }

        /// <summary>
        /// Async save method
        /// </summary>
        /// <returns>number of state entries written to the underlying database.</returns>
        public Task<int> SaveChangesAsync()
        {
            return _dbContext.SaveChangesAsync();
        }

        #endregion

        #region PollAndRelated

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

        #region PollQuestionRepository

        private IPollQuestionRepository _pollQuestionRepository;

        /// <summary>
        /// Poll question repository access point.
        /// </summary>
        public IPollQuestionRepository PollQuestionRepository
        {
            get { return _pollQuestionRepository ??= new PollQuestionRepository(_dbContext); }
        }

        #endregion

        #endregion

        #region GroupAndRelated

        #region GroupRepository

        private IGroupRepository _groupRepository;

        /// <summary>
        /// Group repository access point.
        /// </summary>
        public IGroupRepository GroupRepository
        {
            get { return _groupRepository ??= new GroupRepository(_dbContext); }
        }

        #endregion

        #region GroupMemberRepository

        private IGroupMemberRepository _groupMemberRepository;

        /// <summary>
        /// GroupMember repository access point.
        /// </summary>
        public IGroupMemberRepository GroupMemberRepository
        {
            get { return _groupMemberRepository ??= new GroupMemberRepository(_dbContext); }
        }

        #endregion

        #region GroupMemberRepository

        private IGroupMessageRepository _groupMessageRepository;

        /// <summary>
        /// GroupMessage repository access point.
        /// </summary>
        public IGroupMessageRepository GroupMessageRepository
        {
            get { return _groupMessageRepository ??= new GroupMessageRepository(_dbContext); }
        }

        #endregion

        #endregion
    }
}