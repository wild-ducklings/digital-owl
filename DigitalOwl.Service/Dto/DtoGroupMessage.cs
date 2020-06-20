namespace DigitalOwl.Service.Dto
{
    public class DtoGroupMessage
    {
        public int Id { get; set; }

        public string Content { get; set; }

        public int GroupId { get; set; }
        
        public int UserId { get; set; }
    }
}