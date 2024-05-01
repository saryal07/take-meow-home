using System;
using System.ComponentModel.DataAnnotations;
namespace FinalProject.Models
{
    public class Product {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsInCart { get; set; }
        public string Description { get; set; }
        public string ImagePath { get; set; }
    }
}