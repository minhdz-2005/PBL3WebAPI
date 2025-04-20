using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PBL3WebAPI.Models;
public class ShiftStaffs {
    [Key]
    public int Id { get; set; }
    [ForeignKey("Shift")]
    public int ShiftId { get; set; }
    [ForeignKey("Staff")]
    public int StaffId { get; set; }

    public ShiftStaffs () {}
    public ShiftStaffs (int shiftId, int staffId) {
        ShiftId = shiftId;
        StaffId = staffId;
    }
}