using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using DigitalOwl.Repository.Interface.Entity;
using Microsoft.AspNetCore.Identity;

namespace DigitalOwl.Repository.Entity.Identity
{
    /// <summary>
    ///  Decorator for IdentityUser
    /// </summary>
    public class User : IdentityUser<int>, IEntity
    {
        /// <summary>
        ///  Temporary Role which allow user to do certain things 
        /// </summary>
        public string Role { get; set; }

        /// <summary>
        /// One-to-Many relation With <class>GroupMember</class>
        /// </summary>
        public virtual IEnumerable<GroupMember> GroupMembers { get; set; }

        public virtual IEnumerable<GroupMessage> GroupMessages { get; set; }

        #region TimeStamps

        #region PollQuestion

        /// <summary>
        /// 
        /// </summary>
        [InverseProperty(("CreatedBy"))]
        public virtual IEnumerable<PollQuestion> QuestionsCreated { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [InverseProperty(("UpdatedBy"))]
        public virtual IEnumerable<PollQuestion> QuestionsUpdated { get; set; }

        #endregion

        #region Poll

        /// <summary>
        /// 
        /// </summary>
        [InverseProperty(("CreatedBy"))]
        public virtual IEnumerable<Poll> PollsCreated { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [InverseProperty(("UpdatedBy"))]
        public virtual IEnumerable<Poll> PollsUpdated { get; set; }

        #endregion

        #region Group

        /// <summary>
        /// Inverse prop of TimeStamps
        /// </summary>
        [InverseProperty("CreatedBy")]
        public virtual IEnumerable<Group> GroupsCreated { get; set; }

        /// <summary>
        /// Inverse prop of TimeStamps
        /// </summary>
        [InverseProperty("UpdatedBy")]
        public virtual IEnumerable<Group> GroupsUpdated { get; set; }

        #endregion

        #region GroupMembers

        /// <summary>
        /// Inverse prop of TimeStamps
        /// </summary>
        [InverseProperty("CreatedBy")]
        public virtual IEnumerable<GroupMember> GroupMembersCreated { get; set; }

        /// <summary>
        /// Inverse prop of TimeStamps
        /// </summary>
        [InverseProperty("UpdatedBy")]
        public virtual IEnumerable<GroupMember> GroupMembersUpdated { get; set; }

        #endregion

        #region GroupMessage

        /// <summary>
        /// Inverse prop of TimeStamps
        /// </summary>
        [InverseProperty("CreatedBy")]
        public virtual IEnumerable<GroupMessage> GroupMessagesCreated { get; set; }

        /// <summary>
        /// Inverse prop of TimeStamps
        /// </summary>
        [InverseProperty("UpdatedBy")]
        public virtual IEnumerable<GroupMessage> GroupMessagesUpdated { get; set; }

        #endregion

        #endregion
    }
}