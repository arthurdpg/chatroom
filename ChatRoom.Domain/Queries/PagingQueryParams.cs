namespace ChatRoom.Domain.Queries
{
    public abstract class PagingQueryParams
    {
        public PagingQueryParams()
        {
            PageSize = 50;
        }

        public int CurrentPage { get; set; }
        public int PageSize { get; set; }
    }
}
