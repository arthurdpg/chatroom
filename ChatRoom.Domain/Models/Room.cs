namespace ChatRoom.Domain.Models
{
    public class Room : IDomainModel
    {
        public Room(Guid id, string userId, DateTime created, string name, string description)
        {
            Id = id;
            UserId = userId;
            Created = created;
            Name = name;
            Description = description;
        }

        public Guid Id { get; private set; }
        public string UserId { get; private set; }
        public DateTime Created { get; private set; }
        public string Name { get; private set; }
        public string Description { get; private set; }
        public IList<Post> Posts { get; set; }
    }
}
