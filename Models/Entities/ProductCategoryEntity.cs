using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ECommerceDB.Models.Entities
{
    
    [Table("products_categories")]
    public class ProductCategoryEntity
    {
         
        [Column(name: "product_id")]
        [Key]
        public Guid ProductId { get; set; }
        
        [Column(name: "category_id")]
        [Key]
        public Guid CategoryId { get; set; }

        [ForeignKey("ProductId")]
        public ProductEntity Product { get; set; }

        [ForeignKey("CategoryId")]
        public CategoryEntity Category { get; set; }


    }
}