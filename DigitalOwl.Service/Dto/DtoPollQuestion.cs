using System;
using System.Collections.Generic;

namespace DigitalOwl.Service.Dto
{
    /// <summary>
    /// Dto for poll question.
    /// </summary>
    public class DtoPollQuestion
    {
        /// <summary>
        /// Question Id in database.
        /// </summary>
        public int Id { get; set; }
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
        public IEnumerable<DtoPollAnswer> QuestionAnswers { get; set; }
        /// <summary>
        /// Optional question time limit.
        /// </summary>
        public DateTime? TimeLimit { get; set; }
        /// <summary>
        /// Optional points available for 
        /// </summary>
        public int? Points { get; set; }
    }
}