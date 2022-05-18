namespace ChatRoom.Web.Models
{
    public class PostViewModel
    {
        public Guid Id { get; set; }
        public Guid RoomId { get; set; }
        public string UserId { get; set; }
        public string UserName { get; set; }
        public DateTime Created { get; set; }
        public string Content { get; set; }
    }
}
