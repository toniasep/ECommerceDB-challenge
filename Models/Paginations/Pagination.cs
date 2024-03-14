namespace ECommerceDB.Models.Paginations;

public class Pagination
{

    public Pagination(
    )
    {
    }

    public PagingConfig Paging(dynamic model)
    {
        return new PagingConfig
        {
            Paging = model.GetHeader(),
        };
    }
}