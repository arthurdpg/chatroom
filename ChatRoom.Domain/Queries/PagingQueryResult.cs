namespace ChatRoom.Domain.Queries
{
    public class PagingQueryResult<T>
    {
        public IReadOnlyCollection<T> Content { get; }
        public int ContentLength { get; set; }
        public int PageSize { get; } = 50;
        public int TotalElements { get; }
        public int TotalPages => PageSize.Equals(0) ? 1 : (int)Math.Ceiling((decimal)TotalElements / PageSize);
        public PagingQueryResult(List<T> content, int numberOfElements, int pageSize)
        {
            Content = content;
            ContentLength = content.Count;
            TotalElements = numberOfElements;
            PageSize = pageSize;
        }

        public PagingQueryResult(List<T> content)
        {
            Content = content;
            ContentLength = content.Count;
            TotalElements = content.Count;
        }
    }
}
