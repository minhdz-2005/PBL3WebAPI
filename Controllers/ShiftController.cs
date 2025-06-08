using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PBL3WebAPI.Models;
using PBL3WebAPI.Data;
using System.Collections;

namespace PBL3WebAPI.Controllers;
[ApiController]
[Route("api/[controller]")]
public class ShiftController : ControllerBase
{
    private readonly PBL3WebAPIContext _context;

    public ShiftController(PBL3WebAPIContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Shift>>> GetAllShift()
    {
        return await _context.Shift.ToListAsync();
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Shift>> GetShift(int id)
    {
        var a = await _context.Shift.FindAsync(id);

        if (a == null)
        {
            return NotFound();
        }

        return a;
    }
    [HttpGet("Date/{date}")]
    public async Task<ActionResult<IEnumerable<Shift>>> GetShiftByDate(DateTime date)
    {
        var list = await _context.Shift
        .Where(x => x.StartTime.Date == date.Date)
        .ToListAsync();

        if (list == null) return NotFound();

        return Ok(list);
    }

    [HttpPost]
    public async Task<ActionResult<Shift>> CreateShift(Shift a)
    {
        _context.Shift.Add(a);
        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(GetShift), new { id = a.Id }, a);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateShift(int id, Shift a)
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
            if (!ShiftExists(id))
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
    public async Task<IActionResult> DeleteShift(int id)
    {
        var existing = await _context.Shift.FindAsync(id);
        if (existing == null)
        {
            return NotFound();
        }

        _context.Shift.Remove(existing);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    private bool ShiftExists(int id)
    {
        return _context.Shift.Any(e => e.Id == id);
    }
}