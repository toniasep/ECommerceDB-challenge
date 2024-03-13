using ECommerceDB.Controllers.Requests;
using ECommerceDB.Models.Services;
using Microsoft.AspNetCore.Mvc;

namespace ECommerceDB.Controllers.Views
{
    public class CustomerController : Controller
    {
        private readonly CustomerService _customerService;
        public CustomerController(
            CustomerService customerService
        )
        {
            _customerService = customerService;
        }

        [HttpGet("/customers")]
        public IActionResult IndexProduct()
        {
            return Ok(_customerService.Index());
        }
    }
}