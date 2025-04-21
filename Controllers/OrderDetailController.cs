using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PBL3WebAPI.Models;
using PBL3WebAPI.Data;

namespace PBL3WebAPI.Controllers;
[ApiController]
[Route("api/[controller]")]
public class OrderDetailController : ControllerBase
{
    private readonly PBL3WebAPIContext _context;

    public OrderDetailController(PBL3WebAPIContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<OrderDetail>>> GetAllOrderDetail()
    {
        return await _context.OrderDetail.ToListAsync();
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<OrderDetail>> GetOrderDetail(int id)
    {
        var a = await _context.OrderDetail.FindAsync(id);

        if (a == null)
        {
            return NotFound();
        }

        return a;
    }

    [HttpPost]
    public async Task<ActionResult<OrderDetail>> CreateOrderDetail(OrderDetail a)
    {
        _context.OrderDetail.Add(a);
        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(GetOrderDetail), new { id = a.Id }, a);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateOrderDetail(int id, OrderDetail a)
    {
        if (id != a.Id)
        {
            return BadRequest();
        }

        _context.Entry(a).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!OrderDetailExists(id))
            {
                return NotFound();
            }
            else
            {
                throw;
            }
        }

        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteOrderDetail(int id)
    {
        var existing = await _context.OrderDetail.FindAsync(id);
        if (existing == null)
        {
            return NotFound();
        }

        _context.OrderDetail.Remove(existing);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    private bool OrderDetailExists(int id)
    {
        return _context.OrderDetail.Any(e => e.Id == id);
    }
}