using ECommerceDB.Controllers.Requests;
using ECommerceDB.Models.Services;
using Microsoft.AspNetCore.Mvc;

namespace ECommerceDB.Controllers.Views
{
    public class OrderController : Controller
    {
        private readonly OrderService _orderService;
        public OrderController(
            OrderService orderService
        )
        {
            _orderService = orderService;
        }

        [HttpGet("/orders/income")]
        public IActionResult IndexOrder()
        {
            return Ok(_orderService.GetIncome());
        }
    }
}