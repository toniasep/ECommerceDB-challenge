using Microsoft.AspNetCore.Mvc;

namespace ECommerceDB.Controllers.Requests
{
    public class ProductListRequest
    {
        
        [FromQuery(Name = "category")]
        public string Category { get; set; }
    }
}