using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace PBL3WebAPI.Models;
public class Staff {
    [Key]
    public int Id { get; set; }
    [Required]
    [ForeignKey("Account")]
    public string Username { get; set; } = string.Empty;
    [Required]
    [MaxLength(50)]
    public string Name { get; set; } = string.Empty;
    [Required]
    [MaxLength(20)]
    public string PhoneNumber { get; set; } = string.Empty;
    [Required]
    [MaxLength(50)]
    public string Role { get; set;} = string.Empty;
    [Precision(18,2)]
    public decimal Salary { get; set; }

    public Staff () {}
    public Staff (string username, string name, string phoneNumber, string role, decimal salary) {
        Username = username;
        Name = name;
        PhoneNumber = phoneNumber;
        Role = role;
        Salary = salary;
    }
}