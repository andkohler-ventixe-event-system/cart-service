using System.ComponentModel.DataAnnotations;

namespace CartService.Models;

public class CartItem
{
    public int Id { get; set; }

    [Required]
    public string EventTitle { get; set; } = null!;

    [Required]
    public string PackageName { get; set; } = null!;

    [Required]
    public decimal Price { get; set; }

    [Required]
    public int Quantity { get; set; }
}
