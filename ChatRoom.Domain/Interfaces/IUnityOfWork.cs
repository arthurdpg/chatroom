namespace ChatRoom.Domain.Interfaces
{
    public interface IUnitOfWork
    {
        Task<int> CommitAsync();
    }
}
