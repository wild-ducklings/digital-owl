namespace DigitalOwl.Service.Dto
{
    /// <summary>
    /// Dto of Group Entity
    /// </summary>
    public class DtoGroup
    {
        /// <summary>
        /// Id of Group
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Name of Group
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Reference to GroupMember
        /// </summary>
        public DtoGroupMember GroupMember { get; set; }
    }
}