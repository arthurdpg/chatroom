using ChatRoom.Domain.Models;

namespace ChatRoom.Domain.Interfaces.Queries
{
    public interface IRoomQueries : IQueries<Room>
    {
        Task<List<Room>> FindAll();
        Task<Room> FindById(Guid id);
    }
}
