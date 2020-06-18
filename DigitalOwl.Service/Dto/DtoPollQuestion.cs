using System;
using System.Collections.Generic;
using DigitalOwl.Repository.Entity;

namespace DigitalOwl.Service.Dto
{
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
        public IEnumerable<PollAnswer> QuestionAnswers { get; set; }
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