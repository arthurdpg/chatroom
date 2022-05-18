using ChatRoom.Domain.Models;

namespace ChatRoom.Domain.Interfaces
{
    public interface IRepository<in TEntity> where TEntity : IDomainModel
    {
        Task InsertAsync(TEntity entity);
    }
}
