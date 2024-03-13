using Microsoft.AspNetCore.Mvc;

namespace ECommerceDB.Controllers.Requests
{
    public class OrderListRequest
    {
        
        [FromQuery(Name = "start_date")]
        public DateTime? StartDate { get; set; }

        [FromQuery(Name = "end_date")]
        public DateTime? EndDate { get; set; }
    }
}