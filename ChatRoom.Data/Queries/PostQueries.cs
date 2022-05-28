using ChatRoom.Data.Contexts;
using ChatRoom.Domain.Interfaces.Queries;
using ChatRoom.Domain.Models;
using ChatRoom.Domain.Queries;

namespace ChatRoom.Data.Queries
{
    public class PostQueries : BaseQuery<Post>, IPostQueries
    {
        public PostQueries(ChatRoomContext db) : base(db) { }

        public Task<PagingQueryResult<Post>> FindByRoom(PostsParams parameters)
        {
            var query = DbSet
                .Where(p => p.RoomId == parameters.RoomId)
                .Where(p => (!p.IsCommand && p.To == null) || (p.IsCommand && p.From == parameters.UserId) || (p.To == parameters.UserId))
                .OrderByDescending(r => r.Created);

            return Paginate(query, parameters);
        }
    }
}
