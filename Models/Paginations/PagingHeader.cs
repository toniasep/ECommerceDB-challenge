namespace ECommerceDB.Models.Paginations;

public class PagingHeader
{
    public PagingHeader(int totalItems, int pageNumber, int pageSize, int totalPages)
    {
        this.TotalItems = totalItems;
        this.PageNumber = pageNumber;
        this.PageSize = pageSize;
        this.TotalPages = totalPages;
    }

    public int TotalItems { get; }
    public int PageNumber { get; }
    public int PageSize { get; }
    public int TotalPages { get; }

}