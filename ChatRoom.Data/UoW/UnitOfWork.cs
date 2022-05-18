using ChatRoom.Data.Contexts;
using ChatRoom.Domain.Interfaces;

namespace ChatRoom.Data.UoW
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ChatRoomContext _context;

        public UnitOfWork(ChatRoomContext context)
        {
            _context = context;
        }

        public Task<int> CommitAsync()
        {
            return _context.SaveChangesAsync();
        }
    }
}
