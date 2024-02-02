namespace Common.Utils
{
    public class CollectionResult<T>
    {
        public IEnumerable<T> Results { get; }
        public int PageSize { get; }
        public int PageNumber { get; }
        public int Total { get; }

        public CollectionResult(IEnumerable<T> results, int pageSize, int pageNumber, int total)
        {
            Results = results;
            PageSize = pageSize;
            PageNumber = pageNumber;
            Total = total;
        }
    }

}
