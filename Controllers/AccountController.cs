using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PBL3WebAPI.Models;
using PBL3WebAPI.Data;

namespace PBL3WebAPI.Controllers;
[ApiController]
[Route("api/[controller]")]
public class AccountController : ControllerBase
{
    private readonly PBL3WebAPIContext _context;

    public AccountController (PBL3WebAPIContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Account>>> GetAllAccount()
    {
        return await _context.Account.ToListAsync();
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Account>> GetAccount(int id)
    {
        var a = await _context.Account.FindAsync(id);

        if (a == null)
        {
            return NotFound();
        }

        return a;
    }
    [HttpGet("Username/{username}")]
    public async Task<ActionResult<Account>> GetAccountByUsername(string username) {
        var a = await _context.Account.FirstOrDefaultAsync(x => x.Username == username);

        if(a == null) {
            return NotFound();
        }

        return a;
    }

    [HttpPost]
    public async Task<ActionResult<Account>> CreateAccount(Account a)
    {
        _context.Account.Add(a);
        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(GetAccount), new { id = a.Id }, a);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateAccount(int id, Account a)
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
            if (!AccountExists(id))
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
    public async Task<IActionResult> DeleteAccount(int id)
    {
        var existing = await _context.Account.FindAsync(id);
        if (existing == null)
        {
            return NotFound();
        }

        _context.Account.Remove(existing);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    private bool AccountExists(int id)
    {
        return _context.Account.Any(e => e.Id == id);
    }
}