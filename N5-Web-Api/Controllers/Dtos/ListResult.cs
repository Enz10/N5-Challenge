namespace N5_Web_Api.Controllers.Dtos;

public class ListResult<T>
{
    public IEnumerable<T> Results { get; set; }

    public long PageSize { get; set; }

    public int PageNumber { get; set; }

    public long Total { get; set; }

}
