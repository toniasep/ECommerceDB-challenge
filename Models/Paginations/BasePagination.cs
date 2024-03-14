using Microsoft.AspNetCore.Mvc;

namespace ECommerceDB.Models.Paginations;

public class BasePagination
{

    [FromQuery(Name = "page_number")]
    public int PageNumber { set; get; } = 1;

    [FromQuery(Name = "page_size")]
    public int PageSize { set; get; } = 5;
}