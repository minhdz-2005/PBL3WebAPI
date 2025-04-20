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
        var account = await _context.Account.FindAsync(id);

        if (account == null)
        {
            return NotFound();
        }

        return account;
    }

    [HttpPost]
    public async Task<ActionResult<Account>> CreateAccount(Account account)
    {
        _context.Account.Add(account);
        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(GetAccount), new { id = account.Id }, account);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateAccount(int id, Account account)
    {
        if (id != account.Id)
        {
            return BadRequest();
        }

        _context.Entry(account).State = EntityState.Modified;

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
        var account = await _context.Account.FindAsync(id);
        if (account == null)
        {
            return NotFound();
        }

        _context.Account.Remove(account);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    private bool AccountExists(int id)
    {
        return _context.Account.Any(e => e.Id == id);
    }
}