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

        #region PollAndRelated

        #region IPollRepository
        /// <summary>
        /// Poll repository access point.
        /// </summary>
        public IPollRepository PollRepository { get; }
        #endregion

        #region IPollQuestionRepository
        /// <summary>
        /// Poll question access point.
        /// </summary>
        public IPollQuestionRepository PollQuestionRepository { get; }
        #endregion
        #endregion


        #region GroupAndRelated

        #region IGroupRepository
        /// <summary>
        /// Group repository access point.
        /// </summary>
        public IGroupRepository GroupRepository { get; }
        #endregion
        
        #region IGroupMemberRepository
        /// <summary>
        /// GroupMember repository access point.
        /// </summary>
        public IGroupMemberRepository GroupMemberRepository { get; }
        #endregion

        #region IGroupMessageRepository
        /// <summary>
        /// GroupMember repository access point.
        /// </summary>
        public IGroupMessageRepository GroupMessageRepository { get; }
        #endregion
        #endregion
    }
}