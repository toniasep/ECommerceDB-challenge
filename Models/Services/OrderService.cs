using ECommerceDB.Controllers.Requests;
using ECommerceDB.Controllers.Responses;
using ECommerceDB.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace ECommerceDB.Models.Services
{
    public class OrderService
    {
        private readonly ECommerceDbContext _context;

        public OrderService(ECommerceDbContext context)
        {
            _context = context;
        }

        public IncomeResponse GetIncome(OrderListRequest request)
        {
            var data = _context.Orders
                .Include(o => o.OrderItems)
                    .ThenInclude(oi => oi.Product)
                .ToList();

            if (request.StartDate != null && request.EndDate != null)
            {
                data = data.Where(x => x.OrderDate >= request.StartDate && x.OrderDate <= request.EndDate).ToList();
            }

            if (request.StartDate != null)
            {
                data = data.Where(x => x.OrderDate >= request.StartDate).ToList();
            }

            if (request.EndDate != null)
            {
                data = data.Where(x => x.OrderDate <= request.EndDate).ToList();
            }
            var response = new IncomeResponse
            {
                TotalIncome = data.Sum(x => x.OrderItems.Sum(oi => oi.Quantity * oi.Product.Price)),
                TotalSold = data.Sum(x => x.OrderItems.Sum(oi => oi.Quantity)),
                Orders = null
            };
            if (!request.WithoutOrderData)
            {
                response.Orders = data.Select(x => new OrderListResponse
                {
                    Id = x.Id,
                    OrderDate = x.OrderDate,
                    ShippingAddress = x.ShippingAddress,
                    PaymentMethod = x.PaymentMethod,
                    Status = x.Status,
                    OrderItems = x.OrderItems.Select(oi => new OrderItemResponse
                    {
                        Id = oi.Id,
                        Quantity = oi.Quantity,
                        Product = oi.Product.Name,
                        Price = oi.Product.Price
                    }).ToList()
                }).ToList();
            }

            return response;
        }
        public IncomeResponse GetIncomeLoop(OrderListRequest request)
        {
            var data = _context.Orders
                .Include(o => o.OrderItems)
                    .ThenInclude(oi => oi.Product)
                .ToList();

            if (request.StartDate != null && request.EndDate != null)
            {
                data = data.Where(x => x.OrderDate >= request.StartDate && x.OrderDate <= request.EndDate).ToList();
            }

            if (request.StartDate != null)
            {
                data = data.Where(x => x.OrderDate >= request.StartDate).ToList();
            }

            if (request.EndDate != null)
            {
                data = data.Where(x => x.OrderDate <= request.EndDate).ToList();
            }

            //loop
            decimal totalIncome = 0;
            var totalSold = 0;
            var orders = new List<OrderListResponse>();
            foreach (var order in data)
            {
                totalIncome += order.OrderItems.Sum(oi => oi.Quantity * oi.Product.Price);
                totalSold += order.OrderItems.Sum(oi => oi.Quantity);
                if (!request.WithoutOrderData)
                {
                    orders.Add(new OrderListResponse
                    {
                        Id = order.Id,
                        OrderDate = order.OrderDate,
                        ShippingAddress = order.ShippingAddress,
                        PaymentMethod = order.PaymentMethod,
                        Status = order.Status,
                        OrderItems = order.OrderItems.Select(oi => new OrderItemResponse
                        {
                            Id = oi.Id,
                            Quantity = oi.Quantity,
                            Product = oi.Product.Name,
                            Price = oi.Product.Price
                        }).ToList()
                    });
                }
            }

            var response = new IncomeResponse
            {
                TotalIncome = totalIncome,
                TotalSold = totalSold,
                Orders = orders
            };

            return response;
        }
    }
}