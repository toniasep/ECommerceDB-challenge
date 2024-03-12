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

        // public IncomeResponse GetIncome()
        // {
        //     var data = 
        // }
    }
}