using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PBL3WebAPI.Models;
using PBL3WebAPI.Data;

namespace PBL3WebAPI.Controllers;
[ApiController]
[Route("api/[controller]")]
public class ShiftStaffsController : ControllerBase
{
    private readonly PBL3WebAPIContext _context;

    public ShiftStaffsController(PBL3WebAPIContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<ShiftStaffs>>> GetAllShiftStaffs()
    {
        return await _context.ShiftStaffs.ToListAsync();
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<ShiftStaffs>> GetShiftStaffs(int id)
    {
        var a = await _context.ShiftStaffs.FindAsync(id);

        if (a == null)
        {
            return NotFound();
        }

        return a;
    }
    [HttpGet("idShift/{id}")]
    public async Task<ActionResult<IEnumerable<ShiftStaffs>>> GetByIdShift(int id)
    {
        var list = await _context.ShiftStaffs
        .Where(x => x.ShiftId == id)
        .ToListAsync();

        if (list == null) return NotFound();

        return Ok(list);
    }
    [HttpGet("idShiftAndIdStaff/{idShift}/{idStaff}")]
    public async Task<ActionResult<ShiftStaffs>> GetByIdShiftAndIdStaff(int idShift, int idStaff)
    {
        var shiftStaffs = await _context.ShiftStaffs
        .FirstOrDefaultAsync(x => x.ShiftId == idShift && x.StaffId == idStaff);

        if (shiftStaffs == null) return NotFound();

        return shiftStaffs;
    }

    [HttpPost]
    public async Task<ActionResult<ShiftStaffs>> CreateShiftStaffs(ShiftStaffs a)
    {
        _context.ShiftStaffs.Add(a);
        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(GetShiftStaffs), new { id = a.Id }, a);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateShiftStaffs(int id, ShiftStaffs a)
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
            if (!ShiftStaffsExists(id))
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
    public async Task<IActionResult> DeleteShiftStaffs(int id)
    {
        var existing = await _context.ShiftStaffs.FindAsync(id);
        if (existing == null)
        {
            return NotFound();
        }

        _context.ShiftStaffs.Remove(existing);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    private bool ShiftStaffsExists(int id)
    {
        return _context.ShiftStaffs.Any(e => e.Id == id);
    }
}