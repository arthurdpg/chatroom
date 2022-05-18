using ChatRoom.Data.Contexts;
using ChatRoom.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace ChatRoom.Data.Queries
{
    public class BaseQuery<TEntity> : IQuery<TEntity> where TEntity : class, IDomainModel
    {
        protected readonly ChatRoomContext Db;
        protected readonly DbSet<TEntity> DbSet;

        public BaseQuery(ChatRoomContext db)
        {
            Db = db;
            DbSet = Db.Set<TEntity>();
        }

        public virtual async Task<TEntity> FindById(object id)
        {
            return await DbSet.FindAsync(id);
        }
    }
}
