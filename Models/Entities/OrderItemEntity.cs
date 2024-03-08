using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ECommerceDB.Models.Entities
{
    [Table("order_items")]
    public class OrderItemEntity
    {
            
        [Column(name: "id")]
        [Key]
        public Guid Id { get; set; }
        
        [Column(name: "order_id")]
        public Guid OrderId { get; set; }
        
        [ForeignKey("OrderId")]
        public OrderEntity Order { get; set; }
        
        [Column(name: "product_id")]
        public Guid ProductId { get; set; }
        
        [ForeignKey("ProductId")]
        public ProductEntity Product { get; set; }
        
        [Column(name: "quantity")]
        public int Quantity { get; set; }
        
    }
}