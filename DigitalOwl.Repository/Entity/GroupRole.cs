using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using DigitalOwl.Repository.Entity.Identity;
using DigitalOwl.Repository.Interface.Entity;

namespace DigitalOwl.Repository.Entity
{
    /// <summary>
    /// Group Role
    /// </summary>
    public class GroupRole : IEntity, ITimestamp
    {
        /// <summary>
        /// ID
        /// </summary>
        [Key]
        public int Id { get; set; }

        /// <summary>
        /// Name of Role
        /// </summary>
        public string Name { get; set; }


        /// <summary>
        /// Id of Police that User Can
        /// </summary>
        public int GroupPoliceId { get; set; }

        /// <summary>
        /// Police that User Can
        /// </summary>
        [ForeignKey("GroupPoliceId")]
        public GroupPolice GroupPolice { get; set; }

        /// <summary>
        /// One-to-many relation
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
        [ForeignKey("UpdatedById")]
        public User UpdatedBy { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public DateTime? UpdatedDate { get; set; }

        #endregion
    }
}