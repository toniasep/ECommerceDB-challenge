using ECommerceDB.Controllers.Requests;
using ECommerceDB.Controllers.Responses;
using ECommerceDB.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace ECommerceDB.Models.Services
{
    public class CustomerService
    {
        private readonly ECommerceDbContext _context;

        public CustomerService(ECommerceDbContext context)
        {
            _context = context;
        }

        public List<CustomerListResponse> Index()
        {
            var data = _context.Customers
                .Include(x => x.Orders)
                    .ThenInclude(x => x.OrderItems)
                        .ThenInclude(x => x.Product)
                .AsQueryable();
            
            return data.Select(x => new CustomerListResponse
            {
                Username = x.Username,
                Email = x.Email,
                ShippingAddress = x.ShippingAddress,
                Orders = x.Orders.Select(o => new OrderListResponse
                {
                    Id = o.Id,
                    OrderDate = o.OrderDate,
                    ShippingAddress = o.ShippingAddress,
                    PaymentMethod = o.PaymentMethod,
                    Status = o.Status,
                    OrderItems = o.OrderItems.Select(oi => new OrderItemResponse
                    {
                        Id = oi.Id,
                        Quantity = oi.Quantity,
                        Product = oi.Product.Name,
                        Price = oi.Product.Price
                    }).Take(1).ToList()
                }).ToList()
            }).ToList();
        }
    }
}