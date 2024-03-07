using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ECommerceDB.Models.Entities
{
    
    [Table("categories")]
    public class CategoryEntity
    {

        [Column(name: "id")]
        [Key]
        public Guid Id { get; set; }

        [Column(name: "name")]
        public string Name { get; set; }
        
        [Column(name: "parent_category_id")]
        public Guid? ParentCategoryId { get; set; }

        [ForeignKey("ParentCategoryId")]
        public CategoryEntity ParentCategory { get; set; }

    }
}