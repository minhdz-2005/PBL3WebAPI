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
    [Required]
    public string Username { get; set; } = string.Empty;
    public Customer () {}
    public Customer (string name, string phoneNumber, string username) {
        Name = name;
        PhoneNumber = phoneNumber;
        Username = username;
    }
}