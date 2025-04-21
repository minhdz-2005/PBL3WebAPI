using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PBL3WebAPI.Models;
using PBL3WebAPI.Data;

namespace PBL3WebAPI.Controllers;
[ApiController]
[Route("api/[controller]")]
public class VoucherController : ControllerBase
{
    private readonly PBL3WebAPIContext _context;

    public VoucherController(PBL3WebAPIContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Voucher>>> GetAllVoucher()
    {
        return await _context.Voucher.ToListAsync();
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Voucher>> GetVoucher(int id)
    {
        var a = await _context.Voucher.FindAsync(id);

        if (a == null)
        {
            return NotFound();
        }

        return a;
    }

    [HttpPost]
    public async Task<ActionResult<Voucher>> CreateVoucher(Voucher a)
    {
        _context.Voucher.Add(a);
        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(GetVoucher), new { id = a.Id }, a);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateVoucher(int id, Voucher a)
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
            if (!VoucherExists(id))
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
    public async Task<IActionResult> DeleteVoucher(int id)
    {
        var existing = await _context.Voucher.FindAsync(id);
        if (existing == null)
        {
            return NotFound();
        }

        _context.Voucher.Remove(existing);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    private bool VoucherExists(int id)
    {
        return _context.Voucher.Any(e => e.Id == id);
    }
}