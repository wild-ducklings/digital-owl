using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using DigitalOwl.Repository.Entity.Identity;
using DigitalOwl.Repository.Interface.Entity;

namespace DigitalOwl.Repository.Entity
{
    public class PollAnswer : IEntity, ITimestamp
    {
        /// <summary>
        /// Unique answer Id.
        /// </summary>
        [Key]
        public int Id { get; set; }
        
        /// <summary>
        /// Poll question that question belongs to.
        /// </summary>
        [ForeignKey("PollQuestionId")]
        public virtual PollQuestion PollQuestion { get; set; }

        /// <summary>
        /// Id of a poll question that answer belongs to.
        /// </summary>
        public int PollQuestionId { get; set; }
        
        /// <summary>
        /// Answer itself.
        /// </summary>
        public string AnswerContent { get; set; }
        
        /// <summary>
        /// Indicator whether the answer is a correct one (optional).
        /// </summary>
        public bool? Correctness { get; set; }
        
        #region TimeStamps

        /// <summary>
        /// ID of a user that created the answer.
        /// </summary>
        public int CreatedById { get; set; }

        /// <summary>
        /// User that created the answer.
        /// </summary>
        [ForeignKey("CreatedById")]
        public User CreatedBy { get; set; }

        /// <summary>
        /// Date of answer creation time.
        /// </summary>
        public DateTime CreatedDate { get; set; }

        /// <summary>
        /// ID of a user that updated the answer (optional).
        /// </summary>
        public int? UpdatedById { get; set; }

        /// <summary>
        /// User that updated the answer (optional).
        /// </summary>
        [ForeignKey("UpdatedById")]
        public User UpdatedBy { get; set; }

        /// <summary>
        /// Answer update time (optional).
        /// </summary>
        public DateTime? UpdatedDate { get; set; }

        #endregion
    }
}