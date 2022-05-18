using ChatRoom.Domain.Models;

namespace ChatRoom.Data.Queries
{
    public interface IQuery<TEntity> where TEntity : IDomainModel
    {
        Task<TEntity> FindById(object id);
    }
}
