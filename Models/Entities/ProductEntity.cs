using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ECommerceDB.Models.Entities
{
    
    [Table("products")]
    public class ProductEntity
    {
        [Column(name: "id")]
        [Key]
        public Guid Id { get; set; }

        [Column(name: "name")]
        public string Name { get; set; }

        [Column(name: "description")]
        public string Description { get; set; }

        [Column(name: "price")]
        public decimal Price { get; set; }

        [Column(name: "inventory_quantity")]
        public int InventoryQuantity { get; set; }

        public ICollection<ProductCategoryEntity> ProductCategories { get; set; }


    }
}