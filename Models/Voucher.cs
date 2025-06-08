using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace PBL3WebAPI.Models;
public class Voucher {
    [Key]
    public int Id { get; set; }
    [Required]
    [MaxLength(100)]
    public string Name { get; set; } = string.Empty;
    public string Code { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public bool Status { get; set; }
    [Precision(18,2)]
    public decimal DiscountValue { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }

    public Voucher () {}
    public Voucher(string name, string description, string code, bool status, decimal discountValue, DateTime startDate, DateTime endDate)
    {
        Name = name;
        Status = status;
        DiscountValue = discountValue;
        StartDate = startDate;
        EndDate = endDate;
        Description = description;
        Code = code;
    }
}