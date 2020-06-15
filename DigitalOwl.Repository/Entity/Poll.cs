using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using DigitalOwl.Repository.Entity.Identity;
using DigitalOwl.Repository.Interface.Entity;

namespace DigitalOwl.Repository.Entity
{
    /// <summary>
    ///  Questionnaire/Poll structure.
    /// </summary>
    public class Poll : IEntity, ITimestamp
    {
        /// <summary>
        /// Poll ID.
        /// </summary>
        [Key]public int Id { get; set; }
        /// <summary>
        /// Poll title.
        /// </summary>
        public string Title { get; set; }
        /// <summary>
        /// Set of poll questions.
        /// </summary>
        public IEnumerable<PollQuestion> PollQuestions { get; set; }
        /// <summary>
        /// Optional poll time limit.
        /// </summary>
        public DateTime? TimeLimit { get; set; }

        #region TimeStamps
        
        /// <summary>
        /// ID of a user that created the poll.
        /// </summary>
        public int CreatedById { get; set; }
        /// <summary>
        /// User that created the poll.
        /// </summary>
        [ForeignKey("CreatedById")] 
        public User CreatedBy { get; set; }
        /// <summary>
        /// Date of poll creation time.
        /// </summary>
        public DateTime CreatedDate { get; set; }
        /// <summary>
        /// ID of a user that updated the poll (optional).
        /// </summary>
        public int? UpdatedById { get; set; }
        /// <summary>
        /// User that updated the poll (optional).
        /// </summary>
        [ForeignKey("UpdatedById")]
        public User UpdatedBy { get; set; }
        /// <summary>
        /// Poll update time (optional).
        /// </summary>
        public DateTime? UpdatedDate { get; set; }
        
        #endregion
    }
}