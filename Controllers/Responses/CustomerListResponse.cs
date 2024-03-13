namespace ECommerceDB.Controllers.Responses
{
    public class CustomerListResponse
    {
        public string Username { get; set; }
        public string Email { get; set; }
        public string ShippingAddress { get; set; }
        public List<OrderListResponse> Orders { get; set; }
    }

    public class OrderListResponse
    {
        public Guid Id { get; set; }
        public DateTime OrderDate { get; set; }
        public string ShippingAddress { get; set; }
        public string PaymentMethod { get; set; }
        public string Status { get; set; }
        public List<OrderItemResponse> OrderItems { get; set; }
    }

    public class OrderItemResponse
    {
        public Guid Id { get; set; }
        public int Quantity { get; set; }
        public string Product { get; set; }
        public decimal Price { get; set; }
    }
}