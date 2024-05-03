using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FinalProject.Data;
using FinalProject.Models;
using Microsoft.EntityFrameworkCore;

namespace FinalProject.Services
{
    public class TodoItemService : ITodoItemService
    {
        private readonly ApplicationDbContext _context;

        public TodoItemService(ApplicationDbContext context)
        {
            _context = context;
        }

        // public async Task<bool> AddItemAsync(TodoItem newItem)
        // {
        //     newItem.Id = Guid.NewGuid();
        //     newItem.IsDone = false;
        //     if(newItem.DueAt == null){
        //         newItem.DueAt = DateTimeOffset.Now.AddDays(3);
        //     }

        //     _context.Items.Add(newItem);

        //     var saveResult = await _context.SaveChangesAsync();
        //     return saveResult == 1;
        // }

        public async Task<Product[]> GetProductsAsync()
        {
            var products = await _context.Products
                //.Where(x => x.IsInCart == false)
                .ToArrayAsync();
            return products;
        }

        public async Task<bool> SetToCartTrueAsync(int[] productIds){

            foreach (var productId in productIds)
            {
                var product = _context.Products.FirstOrDefault(p => p.Id == productId);
                if (product != null)
                {
                    // Update the IsInCart property for the selected product
                    product.IsInCart = true;
                }
            }

            // Save changes to the database
            var saveResult = await _context.SaveChangesAsync();
            return saveResult == 1;

        }

        public async Task<Product[]> GetCartProductsAsync()
        {
            var products = await _context.Products
                .Where(x => x.IsInCart == true)
                .ToArrayAsync();
            return products;
        }

        public async Task<bool> SetToCartFalseAsync(int[] productIds){

            foreach (var productId in productIds)
            {
                var product = _context.Products.FirstOrDefault(p => p.Id == productId);
                if (product != null)
                {
                    // Update the IsInCart property for the selected product
                    product.IsInCart = false;
                }
            }

            // Save changes to the database
            var saveResult = await _context.SaveChangesAsync();
            return saveResult == 1;

        }

        public async Task<Product[]> GetPaidProductsAsync()
        {
            var products = await _context.Products
                .Where(x => x.IsPaid == true)
                .ToArrayAsync();
            return products;
        }

        public async Task<bool> SetPaidToTrueAsync(int[] productIds){

            foreach (var productId in productIds)
            {
                var product = _context.Products.FirstOrDefault(p => p.Id == productId);
                if (product != null)
                {
                    // Update the IsPaid property for the selected product
                    product.IsPaid = true;
                    // Also set IsInCart back to false since it is paid
                    product.IsInCart = false;
                }
            }

            // Save changes to the database
            var saveResult = await _context.SaveChangesAsync();
            return saveResult == 1;

        }
        
    }
}