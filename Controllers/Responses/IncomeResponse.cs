namespace ECommerceDB.Controllers.Responses
{
    public class IncomeResponse
    {
        public decimal TotalIncome { get; set; }
        public int TotalSold { get; set; }
        public List<ProductSoldResponse> ProductSolds { get; set; }
    }

    public class ProductSoldResponse
    {
        public string Product { get; set; }
        public int Quantity { get; set; }
    }
}