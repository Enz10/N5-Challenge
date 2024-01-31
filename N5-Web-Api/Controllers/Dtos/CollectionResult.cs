namespace N5_Web_Api.Controllers.Dtos
{
    public class CollectionResult<T>
    {
        public IEnumerable<T> Items { get; }
        public int PageSize { get; }
        public int PageNumber { get; }
        public int TotalCount { get; }

        public CollectionResult(IEnumerable<T> items, int pageSize, int pageNumber, int totalCount)
        {
            Items = items;
            PageSize = pageSize;
            PageNumber = pageNumber;
            TotalCount = totalCount;
        }
    }

}
