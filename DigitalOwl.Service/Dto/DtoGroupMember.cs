namespace DigitalOwl.Service.Dto
{
    public class DtoGroupMember
    {
        /// <summary>
        /// Id of GroupMember
        /// </summary>
        public int Id { get; set; }


        /// <summary>
        /// Foreign key of One-to-One relation with <class>Group</class>
        /// </summary>
        public int GroupId { get; set; }

        /// <summary>
        /// Foreign key of Many-to-One relation with <class>User</class>
        /// </summary>
        public int UserId { get; set; }
    }
}