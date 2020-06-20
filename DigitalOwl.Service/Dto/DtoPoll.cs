using System;
using System.Collections.Generic;
using DigitalOwl.Repository.Entity;

namespace DigitalOwl.Service.Dto
{
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
        public IEnumerable<PollQuestion> PollQuestions { get; set; }
        /// TODO Found it  ^ here 
        /// <summary>
        /// Optional poll time limit.
        /// </summary>
        public DateTime? TimeLimit { get; set; }

    }
}