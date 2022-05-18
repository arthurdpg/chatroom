namespace ChatRoom.Web.Models
{
    public class ChatRoomDetailsViewModel : ChatRoomViewModel
    {
        public List<PostViewModel> Posts { get; set; }
        public bool PostsNotFound => Posts == null || Posts.Count == 0;
    }
}
