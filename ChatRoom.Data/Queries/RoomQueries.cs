using ChatRoom.Data.Contexts;
using ChatRoom.Domain.Interfaces.Queries;
using ChatRoom.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace ChatRoom.Data.Queries
{
    public class RoomQueries : BaseQuery<Room>, IRoomQueries
    {
        public RoomQueries(ChatRoomContext db) : base(db) { }

        public Task<List<Room>> FindAll()
        {
            return DbSet.OrderBy(r => r.Created).ToListAsync();
        }

        public Task<Room> FindById(Guid id)
        {
            return DbSet
                .Include(r => r.Posts)
                .FirstOrDefaultAsync(r => r.Id == id);
        }
    }
}
