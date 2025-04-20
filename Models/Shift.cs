using System.ComponentModel.DataAnnotations;

namespace PBL3WebAPI.Models;
public class Shift {
    [Key]
    public int Id { get; set; }
    [Required]
    public DateTime StartTime { get; set; }
    public DateTime EndTime { get; set; }

    public Shift () {}
    public Shift (DateTime start, DateTime end) {
        StartTime = start;
        EndTime = end;
    }
}