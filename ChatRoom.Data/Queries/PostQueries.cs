using ChatRoom.Data.Contexts;
using ChatRoom.Domain.Interfaces.Queries;
using ChatRoom.Domain.Models;

namespace ChatRoom.Data.Queries
{
    public class PostQueries : BaseQuery<Post>, IPostQueries
    {
        public PostQueries(ChatRoomContext db) : base(db) { }
    }
}
