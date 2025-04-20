using System.ComponentModel.DataAnnotations;
namespace PBL3WebAPI.Models;
public class Account {
    [Key]
    public int Id { get; set; }
    [Required]
    [MaxLength(50)]
    public string Username { get; set; } = string.Empty;
    [Required]
    [MaxLength(50)]
    public string Password { get; set; } = string.Empty;
    [MaxLength(20)]
    public string Role { get; set; } = string.Empty;

    public Account () {}
    public Account (string username, string password, string role) {
        Username = username;
        Password = password;
        Role = role;
    }
}