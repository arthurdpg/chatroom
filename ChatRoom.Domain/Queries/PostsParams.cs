namespace ChatRoom.Domain.Queries
{
    public class PostsParams : PagingQueryParams
    {
        public Guid RoomId { get; set; }
        public string UserId { get; set; }
    }
}
