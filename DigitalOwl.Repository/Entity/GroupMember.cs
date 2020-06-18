using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using DigitalOwl.Repository.Entity.Identity;
using DigitalOwl.Repository.Interface.Entity;

namespace DigitalOwl.Repository.Entity
{
    /// <summary>
    ///  Entity of GroupMember
    /// </summary>
    public class GroupMember : IEntity, ITimestamp
    {
        /// <summary>
        /// Id of GroupMember
        /// </summary>
        [Key] public int Id { get; set; }

        #region ForeignKey

        #region Group
        /// <summary>
        /// Foreign key of Many-to-One relation with <class>Group</class>
        /// </summary>
        public int GroupId { get; set; }
        
        /// <summary>
        /// Reference to <class>Group</class> as Many-to-One relation
        /// </summary>
        [ForeignKey("GroupId")]
        public Group Group { get; set; }
        
        #endregion
        
        
        #region User
        /// <summary>
        /// Foreign key of Many-to-One relation with <class>User</class>
        /// </summary>
        public int UserId { get; set; }

        /// <summary>
        /// Reference to <class>User</class> as Many-to-One relation
        /// </summary>
        [ForeignKey("UserId")]
        public User User { get; set; }
        
        #endregion
        
        #endregion
        
        #region Timestamp

        /// <summary>
        /// 
        /// </summary>
        public int CreatedById { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [ForeignKey("CreatedById")]
        public User CreatedBy { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public DateTime CreatedDate { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int? UpdatedById { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [ForeignKey("UpdatetedById")]
        public User UpdatedBy { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public DateTime? UpdatedDate { get; set; }

        #endregion
    }
}