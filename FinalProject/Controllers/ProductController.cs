using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using FinalProject.Services;
using FinalProject.Models;


namespace FinalProject.Controllers
{
    public class ProductController : Controller
    {
        private readonly ITodoItemService _todoItemService;
        public ProductController(ITodoItemService todoItemService)
        {
            _todoItemService = todoItemService;
        }
        public async Task<IActionResult> Index()
        {
            var products = await _todoItemService.GetProductsAsync();
            // Get products from database
            // Put products into a model
            // Render view using the model
            var model = new ProductViewModel()
            {
                Products = products
            };
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddToCart(int[] productIds)
        {
            if (productIds == null || productIds.Length == 0)
            {
                // Handle case when no products are selected
                return RedirectToAction("Index");
            }
            //sets isInCart to true to indicate they are added to cart
            var successful = await _todoItemService.SetToCartTrueAsync(productIds);
        
            // if (!successful)
            // {
            //     return BadRequest("Could not add items to cart.");
            // }

            return RedirectToAction("Index");
        }
    }

}
