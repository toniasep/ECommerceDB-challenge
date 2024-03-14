namespace ECommerceDB.Models.Paginations;

public class PagingOutput<T>
{
    public PagingHeader Paging { get; set; }
    public List<T> Items { get; set; }
}