namespace ChatRoom.Domain.Queries
{
    public class PagingQueryResult<T>
    {
        public IReadOnlyCollection<T> Records { get; }
        public int PageSize { get; } = 50;
        public int TotalRecords { get; }
        public int TotalPages => PageSize.Equals(0) ? 1 : (int)Math.Ceiling((decimal)TotalRecords / PageSize);
        public PagingQueryResult(List<T> records, int totalRecords, int pageSize)
        {
            Records = records;
            TotalRecords = totalRecords;
            PageSize = pageSize;
        }

        public PagingQueryResult(List<T> records)
        {
            Records = records;
            TotalRecords = records.Count;
        }
    }
}
