namespace ChatRoom.Domain.Queries
{
    public abstract class PagingQueryParams
    {
        public PagingQueryParams()
        {
            PageSize = 10;
        }

        public int CurrentPage { get; set; }
        public int PageSize { get; set; }
    }
}
