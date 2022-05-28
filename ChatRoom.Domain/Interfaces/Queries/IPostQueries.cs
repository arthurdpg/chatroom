using ChatRoom.Domain.Models;
using ChatRoom.Domain.Queries;

namespace ChatRoom.Domain.Interfaces.Queries
{
    public interface IPostQueries : IQueries<Post>
    {
        Task<PagingQueryResult<Post>> FindByRoom(PostsParams parameters);
    }
}
