using ChatRoom.Data.Contexts;
using ChatRoom.Domain.Interfaces;
using ChatRoom.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace ChatRoom.Data.Repositories
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class, IDomainModel
    {
        protected readonly ChatRoomContext Db;
        protected readonly DbSet<TEntity> DbSet;

        public Repository(ChatRoomContext db)
        {
            Db = db;
            DbSet = Db.Set<TEntity>();
        }

        public async Task InsertAsync(TEntity entity)
        {
            await DbSet.AddAsync(entity);
        }
    }
}
