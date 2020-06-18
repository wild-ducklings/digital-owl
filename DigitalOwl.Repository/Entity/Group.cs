using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using DigitalOwl.Repository.Entity.Identity;
using DigitalOwl.Repository.Interface.Entity;

namespace DigitalOwl.Repository.Entity
{
    public class Group : IEntity, ITimestamp
    {
        /// <summary>
        ///  Id group
        /// </summary>
        [Key]
        public int Id { get; set; }

        /// <summary>
        /// Name of group
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// One-to-Many relation With <class>GroupMember</class>
        /// </summary>
        public IEnumerable<GroupMember> GroupMembers { get; set; }

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