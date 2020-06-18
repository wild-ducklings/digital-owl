namespace DigitalOwl.Api.Model.User
{
    public class ViewUser
    {
        // TODO make Id to optional for simplicity 'cause now i dont want to implement Repo and Service for User
        public int Id { get; set; }
        public string UserName { get; set; }
    }
}