namespace DigitalOwl.Service.Dto
{
    /// <summary>
    /// Dto for GroupMember.
    /// </summary>
    public class DtoGroupMember
    {
        /// <summary>
        /// Id of a GroupMember.
        /// </summary>
        public int Id { get; set; }


        /// <summary>
        /// Foreign key of One-to-One relation with <class>Group</class>.
        /// </summary>
        public int GroupId { get; set; }

        /// <summary>
        /// Foreign key of Many-to-One relation with <class>User</class>.
        /// </summary>
        public int UserId { get; set; }

        /// <summary>
        /// Foreign key of Many-to-One relation with <class>GroupRole</class>
        /// </summary>
        public int GroupRoleId { get; set; }
    }
}