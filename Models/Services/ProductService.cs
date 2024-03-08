using ECommerceDB.Controllers.Requests;
using ECommerceDB.Controllers.Responses;
using ECommerceDB.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace ECommerceDB.Models.Services
{
    public class ProductService
    {
        private readonly ECommerceDbContext _context;

        public ProductService(ECommerceDbContext context)
        {
            _context = context;
        }

        public List<ProductListResponse> GetAllProducts(ProductListRequest request)
        {
            var query = _context.Products
                        .Include(x => x.ProductCategories)
                        .ThenInclude(x => x.Category)
                        .AsQueryable();

            if (!string.IsNullOrEmpty(request.Category))
            {
                query = query
                    .Where(x => x.ProductCategories.Any(pc => pc.Category.Name == request.Category));
            }

            return query
                .Select(x => new ProductListResponse
                {
                    Name = x.Name,
                    Price = x.Price,
                    InventoryQuantity = x.InventoryQuantity,
                    Categories = x.ProductCategories.Select(pc => pc.Category.Name).ToList()
                })
                .ToList();
        }
    }
}