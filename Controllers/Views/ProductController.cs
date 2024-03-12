using ECommerceDB.Controllers.Requests;
using ECommerceDB.Models.Services;
using Microsoft.AspNetCore.Mvc;

namespace ECommerceDB.Controllers.Views
{
    public class ProductController : Controller
    {
        private readonly ProductService _productService;
        public ProductController(
            ProductService productService
        )
        {
            _productService = productService;
        }

        [HttpGet("/product")]
        public IActionResult IndexProduct([FromQuery] ProductListRequest request)
        {
            return Ok(_productService.GetAllProducts(request));
        }

        [HttpGet("/product/best-sellers")]
        public IActionResult BestSellers()
        {
            return Ok(_productService.GetBestSellers());
        }
    }
}