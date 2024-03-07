using Microsoft.EntityFrameworkCore;
using ECommerceDB.Models;
using ECommerceDB.Models.Entities;

namespace ECommerceDB.Models
{
    public class ECommerceDbContext : DbContext
    {
        public ECommerceDbContext(DbContextOptions options) : base(options)
        {
        }
        
        public DbSet<ProductEntity> Products { get; set; }
        public DbSet<CategoryEntity> Categories { get; set; }
        public DbSet<ProductCategoryEntity> ProductCategories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ProductCategoryEntity>()
                .HasKey(pc => new { pc.ProductId, pc.CategoryId });
            
        }
    }
}
