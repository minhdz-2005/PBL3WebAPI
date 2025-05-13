using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace PBL3WebAPI.Models;
public class Order {
    [Key]
    public int Id { get; set; }
    [ForeignKey("Staff")]
    public int StaffId { get; set; }

    [ForeignKey("Shift")]
    public int ShiftId { get; set; }
    [ForeignKey("Voucher")]
    public int VoucherId { get; set; }
    public DateTime TimeAndDate { get; set; } = DateTime.Now;
    [Precision(18,2)]
    public decimal Amount { get; set; }
    [Precision(18,2)]
    public decimal DiscountValue { get; set; }
    [Precision(18,2)]
    public decimal FinalAmount  {get; set; }
    public bool Status { get; set; }

    public Order () {}
    public Order (int staffId, int shiftId, int voucherId, decimal amount, decimal discountValue, bool status) {
        StaffId = staffId;
        ShiftId = shiftId;
        VoucherId = voucherId;
        Amount = amount;
        DiscountValue = discountValue;
        FinalAmount = Amount - DiscountValue;
        Status = status;
    }
}