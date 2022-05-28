namespace ChatRoom.Domain.Models
{
    public class Post : IDomainModel
    {
        public Post(Guid id, string from, string to, Guid roomId, DateTime created, string content)
        {
            Id = id;
            From = from;
            To = to;
            RoomId = roomId;
            Created = created;
            Content = content;
            IsCommand = IsCommandPost();
        }

        public Guid Id { get; private set; }
        public string From { get; private set; }
        public string To { get; private set; }
        public Guid RoomId { get; private set; }
        public Room Room { get; private set; }
        public DateTime Created { get; private set; }
        public string Content { get; private set; }
        public bool IsCommand { get; private set; }

        private bool IsCommandPost()
        {
            return !string.IsNullOrEmpty(Content) && Content.StartsWith("/");
        }
    }
}
