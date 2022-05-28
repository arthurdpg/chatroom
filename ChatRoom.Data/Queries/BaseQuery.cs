using ChatRoom.Data.Contexts;
using ChatRoom.Domain.Models;
using ChatRoom.Domain.Queries;
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

        protected async Task<PagingQueryResult<TEntity>> Paginate(IQueryable<TEntity> query, PagingQueryParams parameters)
        {
            var count = query.Count();
            var initPage = parameters.CurrentPage > 0 ? parameters.CurrentPage - 1 : 0;
            var result = await query.Skip(initPage * parameters.PageSize).Take(parameters.PageSize).ToListAsync();

            return new PagingQueryResult<TEntity>(result, count, parameters.PageSize);
        }
    }
}
