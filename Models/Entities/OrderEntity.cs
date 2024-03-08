using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ECommerceDB.Models.Entities
{
    [Table("orders")]
    public class OrderEntity
    {
            
        [Column(name: "id")]
        [Key]
        public Guid Id { get; set; }
        
        [Column(name: "customer_id")]
        public Guid CustomerId { get; set; }
        
        [ForeignKey("CustomerId")]
        public CustomerEntity Customer { get; set; }
        
        [Column(name: "order_date")]
        public DateTime OrderDate { get; set; }
        
        [Column(name: "shipping_address")]
        public string ShippingAddress { get; set; }
        
        [Column(name: "payment_method")]
        public string PaymentMethod { get; set; }
        
        [Column(name: "status")]
        public string Status { get; set; }

        public ICollection<OrderItemEntity> OrderItems { get; set; }
        
    }
}