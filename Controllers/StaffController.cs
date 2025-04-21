using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PBL3WebAPI.Models;
using PBL3WebAPI.Data;

namespace PBL3WebAPI.Controllers;
[ApiController]
[Route("api/[controller]")]
public class StaffController : ControllerBase
{
    private readonly PBL3WebAPIContext _context;

    public StaffController(PBL3WebAPIContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Staff>>> GetAllStaff()
    {
        return await _context.Staff.ToListAsync();
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Staff>> GetStaff(int id)
    {
        var a = await _context.Staff.FindAsync(id);

        if (a == null)
        {
            return NotFound();
        }

        return a;
    }

    [HttpPost]
    public async Task<ActionResult<Staff>> CreateStaff(Staff a)
    {
        _context.Staff.Add(a);
        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(GetStaff), new { id = a.Id }, a);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateStaff(int id, Staff a)
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
            if (!StaffExists(id))
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
    public async Task<IActionResult> DeleteStaff(int id)
    {
        var existing = await _context.Staff.FindAsync(id);
        if (existing == null)
        {
            return NotFound();
        }

        _context.Staff.Remove(existing);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    private bool StaffExists(int id)
    {
        return _context.Staff.Any(e => e.Id == id);
    }
}