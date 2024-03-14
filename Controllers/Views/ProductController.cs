using ECommerceDB.Controllers.Requests;
using ECommerceDB.Models.Factories;
using ECommerceDB.Models.Paginations;
using ECommerceDB.Models.Services;
using Microsoft.AspNetCore.Mvc;

namespace ECommerceDB.Controllers.Views
{
    public class ProductController : Controller
    {
        private readonly ProductService _productService;
        private readonly Pagination _paging;
        public ProductController(
            ProductService productService,
            Pagination paging
        )
        {
            _productService = productService;
            _paging = paging;
        }

        [HttpGet("/product")]
        public IActionResult IndexProduct([FromQuery] ProductListRequest request)
        {
            var products = _productService.GetAllProducts(request);
            var pagination = _paging.Paging(products);
            var response = ProductFactory.MakeWithPaginate(products, pagination);
            return Ok(response);

        }

        [HttpGet("/product/best-sellers")]
        public IActionResult BestSellers()
        {
            return Ok(_productService.GetBestSellers());
        }
    }
}