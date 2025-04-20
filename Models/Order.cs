using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace PBL3WebAPI.Models;
public class Order {
    [Key]
    public int Id { get; set; }
    [ForeignKey("Staff")]
    public int StaffId { get; set; }
    [ForeignKey("Customer")]
    public int CustomerId { get; set; }
    [ForeignKey("Shift")]
    public int ShiftId { get; set; }
    [ForeignKey("Voucher")]
    public int VoucherId { get; set; }
    public DateTime TimeAndDate = DateTime.Now;
    [Precision(18,2)]
    public decimal Amount { get; set; }
    [Precision(18,2)]
    public decimal DiscountValue { get; set; }
    [Precision(18,2)]
    public decimal FinalAmount  {get; set; }
    public bool Status { get; set; }

    public Order () {}
    public Order (int staffId, int customerId, int shiftId, int voucherId, DateTime timeAndDate, decimal amount, decimal discountValue, bool status) {
        StaffId = staffId;
        CustomerId = customerId;
        ShiftId = shiftId;
        VoucherId = voucherId;
        TimeAndDate = timeAndDate;
        Amount = amount;
        DiscountValue = discountValue;
        FinalAmount = Amount - DiscountValue;
        Status = status;
    }
}