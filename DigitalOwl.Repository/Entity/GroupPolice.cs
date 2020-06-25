using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using DigitalOwl.Repository.Entity.Identity;
using DigitalOwl.Repository.Interface.Entity;

namespace DigitalOwl.Repository.Entity
{
    /// <summary>
    /// That tell user what can and cannot do in group
    /// </summary>
    public class GroupPolice  : IEntity, ITimestamp
    {
        /// <summary>
        /// ID
        /// </summary>
        [Key]
        public int Id { get; set; }

        /// <summary>
        /// Name of Police
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// One-to-Many relations
        /// </summary>
        public IEnumerable<GroupRole> GroupRoles { get; set; }

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