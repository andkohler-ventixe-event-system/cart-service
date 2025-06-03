using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CartService.Data;
using CartService.Models;

namespace CartService.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CartController(AppDbContext context) : ControllerBase
{
    [HttpGet]
    public async Task<ActionResult<IEnumerable<CartItem>>> GetItems()
        => await context.CartItems.ToListAsync();

    [HttpPost]
    public async Task<ActionResult<CartItem>> AddItem(CartItem item)
    {
        context.CartItems.Add(item);
        await context.SaveChangesAsync();
        return CreatedAtAction(nameof(GetItems), new { id = item.Id }, item);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteItem(int id)
    {
        var item = await context.CartItems.FindAsync(id);
        if (item == null) return NotFound();

        context.CartItems.Remove(item);
        await context.SaveChangesAsync();
        return NoContent();
    }
}
