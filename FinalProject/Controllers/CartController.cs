using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using FinalProject.Services;
using FinalProject.Models;


namespace FinalProject.Controllers
{
    public class CartController : Controller
    {
        private readonly ITodoItemService _todoItemService;
        public CartController(ITodoItemService todoItemService)
        {
            _todoItemService = todoItemService;
        }
        public async Task<IActionResult> Index()
        {
            var products = await _todoItemService.GetCartProductsAsync();
            var paidproducts = await _todoItemService.GetPaidProductsAsync();
            // Get products from database where IsInCart is true
            // Put products into a model
            // Render view using the model
            var model = new ProductViewModel()
            {
                Products = products,
                PaidProducts= paidproducts
            };

            
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> RemoveFromCart(int[] productIds)
        {
            if (productIds == null || productIds.Length == 0)
            {
                // Handle case when no products are selected
                return RedirectToAction("Index");
            }
            //sets isInCart to false to indicate they are removed from cart
            var successful = await _todoItemService.SetToCartFalseAsync(productIds);
        
            // if (!successful)
            // {
            //     return BadRequest("Could not remove items to cart.");
            // }

            return RedirectToAction("Index");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> PayTheCat(int[] productIds)
        {
            if (productIds == null || productIds.Length == 0)
            {
                // Handle case when no products are selected
                return RedirectToAction("Index");
            }
            //sets isPAid to true to indicate they are paid
            var successful = await _todoItemService.SetPaidToTrueAsync(productIds);
        
            // if (!successful)
            // {
            //     return BadRequest("Could not add items to cart.");
            // }

            return RedirectToAction("Index");
        }
    }

}