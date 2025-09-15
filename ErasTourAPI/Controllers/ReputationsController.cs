using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ErasTourAPI.Models;
using ErasTourAPI.Data; 

namespace ErasTourAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ReputationsController : ControllerBase
{
    private readonly AppDbContext _context;

    public ReputationsController(AppDbContext context)
    {
        _context = context;
    }

    // GET: api/reputations
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Reputation>>> GetReputations()
    {
        return await _context.Reputations.AsNoTracking().ToListAsync();
    }

    // GET: api/reputations/5
    [HttpGet("{id}")]
    public async Task<ActionResult<Reputation>> GetReputation(int id)
    {
        var rep = await _context.Reputations.FindAsync(id);

        if (rep == null)
            return NotFound();

        return rep;
    }

    // POST: api/reputations
    [HttpPost]
    public async Task<ActionResult<Reputation>> PostReputation(Reputation reputation)
    {
        _context.Reputations.Add(reputation);
        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(GetReputation), new { id = reputation.Id }, reputation);
    }

    // PUT: api/reputations/5
    [HttpPut("{id}")]
    public async Task<IActionResult> PutReputation(int id, Reputation reputation)
    {
        if (id != reputation.Id)
            return BadRequest();

        _context.Entry(reputation).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!ReputationExists(id))
                return NotFound();
            else
                throw;
        }

        return NoContent();
    }

    // DELETE: api/reputations/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteReputation(int id)
    {
        var rep = await _context.Reputations.FindAsync(id);
        if (rep == null)
            return NotFound();

        _context.Reputations.Remove(rep);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    private bool ReputationExists(int id)
    {
        return _context.Reputations.Any(e => e.Id == id);
    }
}