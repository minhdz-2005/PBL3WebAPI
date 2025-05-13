using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace PBL3WebAPI.Models;
public class OrderDetail {
    [Key]
    public int Id { get; set; }
    [ForeignKey("Order")]
     public int OrderId { get; set; }
    [ForeignKey("Product")]
    public int ProductId { get; set; }
    [Required]
    public int Quantity { get; set; }
    [Precision(18,2)]
    public decimal TotalPrice { get; set; }
    public string Note { get; set; } = string.Empty;

    public OrderDetail () {}
    public OrderDetail (int productId, int quantity, decimal totalPrice, string note) {
        ProductId = productId;
        Quantity = quantity;
        TotalPrice = totalPrice;
        Note = note;
    }
}