using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PBL3WebAPI.Models;
using PBL3WebAPI.Data;

namespace PBL3WebAPI.Controllers;
[ApiController]
[Route("api/[controller]")]
public class ProductController : ControllerBase
{
    private readonly PBL3WebAPIContext _context;

    public ProductController(PBL3WebAPIContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Product>>> GetAllProduct()
    {
        return await _context.Product.ToListAsync();
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Product>> GetProduct(int id)
    {
        var a = await _context.Product.FindAsync(id);

        if (a == null)
        {
            return NotFound();
        }

        return a;
    }

    [HttpPost]
    public async Task<ActionResult<Product>> CreateProduct(Product a)
    {
        _context.Product.Add(a);
        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(GetProduct), new { id = a.Id }, a);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateProduct(int id, Product a)
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
            if (!ProductExists(id))
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
    public async Task<IActionResult> DeleteProduct(int id)
    {
        var existing = await _context.Product.FindAsync(id);
        if (existing == null)
        {
            return NotFound();
        }

        _context.Product.Remove(existing);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    private bool ProductExists(int id)
    {
        return _context.Product.Any(e => e.Id == id);
    }
}