using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using FinalProject.Models;

namespace FinalProject.Services
{
    public interface ITodoItemService
    {
        //Task<bool> AddItemAsync(TodoItem newItem);
        Task<Product[]> GetProductsAsync();
        Task<bool> SetToCartTrueAsync(int[] productIds);
        Task<Product[]> GetCartProductsAsync();
        Task<bool> SetToCartFalseAsync(int[] productIds);
    }
}