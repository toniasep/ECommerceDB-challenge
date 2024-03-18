using System.Diagnostics;
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
        public IActionResult IndexOrder([FromQuery] OrderListRequest request)
        {
            Stopwatch stopwatch = Stopwatch.StartNew();
            var result = _orderService.GetIncome(request);
            stopwatch.Stop();
            double executionTime = stopwatch.Elapsed.TotalSeconds;
            return Ok(new {executionTime, result});
            
        }

        [HttpGet("/orders/income-with-loop")]
        public IActionResult IndexOrderWithLoop([FromQuery] OrderListRequest request)
        {
            Stopwatch stopwatch = Stopwatch.StartNew();
            var result = _orderService.GetIncomeLoop(request);
            stopwatch.Stop();
            double executionTime = stopwatch.Elapsed.TotalSeconds;
            return Ok(new {executionTime, result});
        }
    }
}