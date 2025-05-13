using Microsoft.EntityFrameworkCore;
using PBL3WebAPI.Models;

namespace PBL3WebAPI.Data;
public class PBL3WebAPIContext : DbContext {
    public PBL3WebAPIContext(DbContextOptions<PBL3WebAPIContext> option) : base (option) { }

    public DbSet<Account> Account { get; set; }
    public DbSet<Order> Order { get; set; }
    public DbSet<OrderDetail> OrderDetail { get; set; }
    public DbSet<Product> Product { get; set; }
    public DbSet<Shift> Shift { get; set; }
    public DbSet<ShiftStaffs> ShiftStaffs { get; set; }
    public DbSet<Staff> Staff { get; set; }
    public DbSet<Voucher> Voucher { get; set; }

    protected override void OnModelCreating (ModelBuilder model) {
        model.Entity<Account>().HasIndex(a => a.Username).IsUnique();
        model.Entity<Staff>().HasIndex(a => a.PhoneNumber).IsUnique();
    }
}