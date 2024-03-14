using ECommerceDB.Controllers.Requests;
using ECommerceDB.Controllers.Responses;
using ECommerceDB.Models.Entities;
using ECommerceDB.Models.Paginations;
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

        public PagedList<ProductEntity> GetAllProducts(ProductListRequest request)
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

            return new PagedList<ProductEntity>(query.AsQueryable(), request.PageNumber, request.PageSize);
        }



        public List<BestSellerListResponse> GetBestSellers()
        {
            var data = _context.Products
                .Include(p => p.OrderItems)
                .Select(p => new BestSellerListResponse
                {
                    Name = p.Name,
                    Sold = p.OrderItems.Sum(oi => oi.Quantity)
                })
                .OrderByDescending(x => x.Sold)
                .ToList();
            
            return data;
        }
    }
}