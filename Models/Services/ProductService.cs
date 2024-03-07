using ECommerceDB.Models.Entities;

namespace ECommerceDB.Models.Services
{
    public class ProductService
    {
        private readonly ECommerceDbContext _context;

        public ProductService(ECommerceDbContext context)
        {
            _context = context;
        }

        public List<ProductEntity> GetAllProducts()
        {
            return _context.Products.ToList();
        }
    }
}