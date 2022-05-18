using ChatRoom.Domain.Models;

namespace ChatRoom.Domain.Interfaces.Queries
{
    public interface IQueries<TEntity> where TEntity : IDomainModel
    {
        Task<TEntity> FindById(object id);
    }
}
