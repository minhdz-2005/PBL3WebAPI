using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PBL3WebAPI.Models;
using PBL3WebAPI.Data;

namespace PBL3WebAPI.Controllers;
[ApiController]
[Route("api/[controller]")]
public class OrderController : ControllerBase
{
    private readonly PBL3WebAPIContext _context;

    public OrderController(PBL3WebAPIContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Order>>> GetAllOrder()
    {
        return await _context.Order.ToListAsync();
    }


    [HttpGet("{id}")]
    public async Task<ActionResult<Order>> GetOrder(int id)
    {
        var a = await _context.Order.FindAsync(id);

        if (a == null)
        {
            return NotFound();
        }

        return a;
    }
    [HttpGet("Date/{date}")]
    public async Task<IActionResult> GetOrdersByDate(DateTime date)
    {
        var orders = await _context.Order
            .Where(o => o.TimeAndDate.Date == date.Date)
            .ToListAsync();

        return Ok(orders);
    }


    [HttpPost]
    public async Task<ActionResult<Order>> CreateOrder(Order a)
    {
        _context.Order.Add(a);
        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(GetOrder), new { id = a.Id }, a);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateOrder(int id, Order a)
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
            if (!OrderExists(id))
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
    public async Task<IActionResult> DeleteOrder(int id)
    {
        var existing = await _context.Order.FindAsync(id);
        if (existing == null)
        {
            return NotFound();
        }

        _context.Order.Remove(existing);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    private bool OrderExists(int id)
    {
        return _context.Order.Any(e => e.Id == id);
    }
}