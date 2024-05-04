using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using FinalProject.Services;
using FinalProject.Models;


namespace FinalProject.Controllers
{
    public class AdminController : Controller
    {
        private readonly ITodoItemService _todoItemService;
        public AdminController(ITodoItemService todoItemService)
        {
            _todoItemService = todoItemService;
        }
        public async Task<IActionResult> Index()
        {
            var products = await _todoItemService.GetPaidProductsAsync();
            // Get products from database where IsPaid is true
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
        public async Task<IActionResult> confirm(int[] productIds)
        {
            if (productIds == null || productIds.Length == 0)
            {
                // Handle case when no products are selected
                return RedirectToAction("Index");
            }
            //sets isPAid to false to indicate they are paid and the admin confirm the order
            var successful = await _todoItemService.SetShipToTrueAsync(productIds);

            return RedirectToAction("Index");
        }
    }

}