using System.ComponentModel.DataAnnotations;

namespace PBL3WebAPI.Models;
public class Customer {
    [Key]
    public int Id { get; set;}
    [Required]
    [MaxLength(100)]
    public string Name { get; set; } = string.Empty;
    [Required]
    [MaxLength(20)]
    public string PhoneNumber { get; set; } = string.Empty;
    public Customer () {}
    public Customer (string name, string phoneNumber) {
        Name = name;
        PhoneNumber = phoneNumber;
    }
}