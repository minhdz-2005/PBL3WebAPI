using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PBL3WebAPI.Models;
using PBL3WebAPI.Data;

namespace PBL3WebAPI.Controllers;
[ApiController]
[Route("api/[controller]")]
public class CustomerController : ControllerBase
{
    private readonly PBL3WebAPIContext _context;

    public CustomerController(PBL3WebAPIContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Customer>>> GetAllCustomer()
    {
        return await _context.Customer.ToListAsync();
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Customer>> GetCustomer(int id)
    {
        var a = await _context.Customer.FindAsync(id);

        if (a == null)
        {
            return NotFound();
        }

        return a;
    }

    [HttpPost]
    public async Task<ActionResult<Customer>> CreateCustomer(Customer a)
    {
        _context.Customer.Add(a);
        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(GetCustomer), new { id = a.Id }, a);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateCustomer(int id, Customer a)
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
            if (!CustomerExists(id))
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
    public async Task<IActionResult> DeleteCustomer(int id)
    {
        var existing = await _context.Customer.FindAsync(id);
        if (existing == null)
        {
            return NotFound();
        }

        _context.Customer.Remove(existing);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    private bool CustomerExists(int id)
    {
        return _context.Customer.Any(e => e.Id == id);
    }
}