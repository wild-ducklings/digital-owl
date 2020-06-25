namespace DigitalOwl.Service.Dto
{
    /// <summary>
    /// Dto for GroupMessage.
    /// </summary>
    public class DtoGroupMessage
    {
        /// <summary>
        /// Id of a GroupMessage.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Content of a GroupMessage.
        /// </summary>
        public string Content { get; set; }

        /// <summary>
        /// Id of a group which GroupMessage belongs to.
        /// </summary>
        public int GroupId { get; set; }
        
        /// <summary>
        /// Id of the user that created the GroupMessage.
        /// </summary>
        public int UserId { get; set; }
    }
}