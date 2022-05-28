namespace ChatRoom.Web.Models
{
    public class PostViewModel
    {
        public Guid Id { get; set; }
        public Guid RoomId { get; set; }
        public string FromUser { get; set; }
        public string FromUserName { get; set; }
        public string Created { get; set; }
        public string Content { get; set; }
        public bool IsCommand { get; set; }
    }
}
