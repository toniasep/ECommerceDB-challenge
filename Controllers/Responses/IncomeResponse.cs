namespace ECommerceDB.Controllers.Responses
{
    public class IncomeResponse
    {
        public decimal TotalIncome { get; set; }
        public int TotalSold { get; set; }
        public List<OrderListResponse> Orders { get; set; }
    }
}