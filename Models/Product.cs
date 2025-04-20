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

    public Product () {}
    public Product (string name, decimal price) {
        Name = name;
        Price = price;
    }
}