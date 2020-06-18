using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using DigitalOwl.Repository.Entity.Identity;
using DigitalOwl.Repository.Interface.Entity;

namespace DigitalOwl.Repository.Entity
{
    /// <summary>
    /// Poll question.
    /// </summary>
    public class PollQuestion : IEntity, ITimestamp
    {
        /// <summary>
        /// Question Id in database.
        /// </summary>
        [Key] public int Id { get; set; }
        /// <summary>
        /// Poll that question belongs to.
        /// </summary>
        [ForeignKey("PollId")] public Poll Poll { get; set; }
        /// <summary>
        /// Id of a poll that question belongs to.
        /// </summary>
        public int PollId { get; set; }
        /// <summary>
        /// Question itself.
        /// </summary>
        public string QuestionContent { get; set; }
        /// <summary>
        /// Available answers for particular question.
        /// </summary>
        public IEnumerable<PollAnswer> QuestionAnswers { get; set; }
        /// <summary>
        /// Optional question time limit.
        /// </summary>
        public DateTime? TimeLimit { get; set; }
        /// <summary>
        /// Optional points available for 
        /// </summary>
        public int? Points { get; set; }
        #region TimeStamps
        
        /// <summary>
        /// ID of a user that created the question.
        /// </summary>
        public int CreatedById { get; set; }
        /// <summary>
        /// User that created the question.
        /// </summary>
        [ForeignKey("CreatedById")] 
        public User CreatedBy { get; set; }
        /// <summary>
        /// Date of question creation time.
        /// </summary>
        public DateTime CreatedDate { get; set; }
        /// <summary>
        /// ID of a user that updated the question (optional).
        /// </summary>
        public int? UpdatedById { get; set; }
        /// <summary>
        /// User that updated the question (optional).
        /// </summary>
        [ForeignKey("UpdatedById")]
        public User UpdatedBy { get; set; }
        /// <summary>
        /// Question update time (optional).
        /// </summary>
        public DateTime? UpdatedDate { get; set; }
        
        #endregion
    }
}