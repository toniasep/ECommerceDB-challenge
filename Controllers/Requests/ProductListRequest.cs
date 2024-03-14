using ECommerceDB.Models.Paginations;
using Microsoft.AspNetCore.Mvc;

namespace ECommerceDB.Controllers.Requests
{
    public class ProductListRequest : BasePagination
    {
        
        [FromQuery(Name = "category")]
        public string Category { get; set; }
    }
}