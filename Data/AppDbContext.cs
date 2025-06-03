using Microsoft.EntityFrameworkCore;
using CartService.Models;

namespace CartService.Data;

public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
{
    public DbSet<CartItem> CartItems { get; set; } = null!;
}
