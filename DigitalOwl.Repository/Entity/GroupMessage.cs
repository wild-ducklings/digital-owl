using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using DigitalOwl.Repository.Entity.Identity;
using DigitalOwl.Repository.Interface.Entity;

namespace DigitalOwl.Repository.Entity
{
    public class GroupMessage : IEntity, ITimestamp
    {
        /// <summary>
        /// Id of the group message.
        /// </summary>
        [Key]
        public int Id { get; set; }

        /// <summary>
        /// Message content.
        /// </summary>
        public string Content { get; set; }

        /// <summary>
        /// Id of a group associated with message.
        /// </summary>
        public int GroupId { get; set; }

        /// <summary>
        /// Group associated with message.
        /// </summary>
        [ForeignKey("GroupId")]
        public virtual Group Group { get; set; }

        /// <summary>
        /// Id of a user that created message.
        /// </summary>
        public int UserId { get; set; }

        /// <summary>
        /// User that created message.
        /// </summary>
        [ForeignKey("UserId")]
        public virtual User User { get; set; }
        
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
        [ForeignKey("UpdatedById")]
        public User UpdatedBy { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public DateTime? UpdatedDate { get; set; }

        #endregion
    }
}