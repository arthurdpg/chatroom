namespace ChatRoom.Domain.Models
{
    public class Post : IDomainModel
    {
        public Post(Guid id, string userId, Guid roomId, DateTime created, string content)
        {
            Id = id;
            UserId = userId;
            RoomId = roomId;
            Created = created;
            Content = content;
        }

        public Guid Id { get; private set; }
        public string UserId { get; private set; }
        public Guid RoomId { get; private set; }
        public Room Room { get; private set; }
        public DateTime Created { get; private set; }
        public string Content { get; private set; }

        public bool IsCommand()
        {
            return !string.IsNullOrEmpty(Content) && Content.StartsWith("/");
        }
    }
}
