using System;
using System.Collections.Generic;
using DigitalOwl.Repository.Entity;

namespace DigitalOwl.Service.Dto
{
    /// <summary>
    /// Dto for poll.
    /// </summary>
    public class DtoPoll
    {

        /// <summary>
        /// Poll ID.
        /// </summary>
        public int Id { get; set; }
        
        /// <summary>
        /// Poll title.
        /// </summary>
        public string Title { get; set; }
        
        /// <summary>
        /// Set of poll questions.
        /// </summary>
        public IEnumerable<DtoPollQuestion> PollQuestions { get; set; }
        
        /// <summary>
        /// Optional poll time limit.
        /// </summary>
        public DateTime? TimeLimit { get; set; }
        
        /// <summary>
        /// Optional points available for poll.
        /// </summary>
        public int? Points { get; set; }

    }
}