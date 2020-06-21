namespace DigitalOwl.Service.Dto
{
    /// <summary>
    /// Dto for poll answer.
    /// </summary>
    public class DtoPollAnswer
    {
        /// <summary>
        /// Unique answer Id.
        /// </summary>
        public int Id { get; set; }

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
    }
}