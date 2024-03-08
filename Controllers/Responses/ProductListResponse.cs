namespace ECommerceDB.Controllers.Responses
{
    public class ProductListResponse
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int InventoryQuantity { get; set; }
        public List<string> Categories { get; set; }
    }
}