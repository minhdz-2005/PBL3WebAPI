using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace PBL3WebAPI.Models;
public class Product {
    [Key]
    public int Id { get; set; }
    [Required]
    public string Name { get; set; } = string.Empty;
    [Precision(18,2)]
    public decimal Price { get; set; }
    [Required]
    public string Category { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;

    public Product () {}
    public Product (string name, decimal price, string category, string description) {
        Name = name;
        Price = price;
        Category = category;
        Description = description;
    }
}