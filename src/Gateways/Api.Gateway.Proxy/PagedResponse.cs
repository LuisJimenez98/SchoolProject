namespace Api.Gateway.Proxy;
public class PagedResponse<T> : Response<T>
{
    public int PageNumber { get; set; }
    public int PageSize { get; set; }
 
    public PagedResponse(T data, int pageNumber, int pageSize)
    {
        Data = data;
        PageNumber = pageNumber;
        PageSize = pageSize;
        Message = null!;
        Succeded = true;
        Errors = null!;
    }
}
