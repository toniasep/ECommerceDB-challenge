namespace ECommerceDB.Models.Paginations;

public class PagedList<T>
{
    public PagedList(IQueryable<T> source, int pageNumber, int pageSize)
    {
        this.TotalItems = source.Count();
        this.PageNumber = pageNumber;
        this.PageSize = pageSize;
        this.Items = source
                .Skip(pageSize * (pageNumber - 1))
                .Take(pageSize)
                .ToList();
    }

    public int TotalItems { get; }
    public int PageNumber { get; }
    public int PageSize { get; }
    public List<T> Items { get; }
    public int TotalPages => (int)Math.Ceiling(this.TotalItems / (double)this.PageSize);

    public PagingHeader GetHeader()
    {
        return new PagingHeader(this.TotalItems, this.PageNumber, this.PageSize, this.TotalPages);
    }
}