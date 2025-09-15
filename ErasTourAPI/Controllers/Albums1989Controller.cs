using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ErasTourAPI.Data;
using ErasTourAPI.Models;

namespace ErasTourAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class Albums1989Controller : ControllerBase
{
    private readonly AppDbContext _context;

    public Albums1989Controller(AppDbContext context)
    {
        _context = context;
    }

    // GET: api/albums1989
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Album1989>>> GetAlbums1989()
    {
        return await _context.Albums1989.AsNoTracking().ToListAsync();
    }

    // GET: api/albums1989/5
    [HttpGet("{id}")]
    public async Task<ActionResult<Album1989>> GetAlbum1989(int id)
    {
        var album = await _context.Albums1989.FindAsync(id);

        if (album == null)
        {
            return NotFound();
        }

        return album;
    }

    // POST: api/albums1989
    [HttpPost]
    public async Task<ActionResult<Album1989>> PostAlbum1989(Album1989 album)
    {
        _context.Albums1989.Add(album);
        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(GetAlbum1989), new { id = album.Id }, album);
    }

    // PUT: api/albums1989/5
    [HttpPut("{id}")]
    public async Task<IActionResult> PutAlbum1989(int id, Album1989 album)
    {
        if (id != album.Id)
        {
            return BadRequest();
        }

        _context.Entry(album).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!Album1989Exists(id))
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

    // DELETE: api/albums1989/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteAlbum1989(int id)
    {
        var album = await _context.Albums1989.FindAsync(id);
        if (album == null)
        {
            return NotFound();
        }

        _context.Albums1989.Remove(album);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    private bool Album1989Exists(int id)
    {
        return _context.Albums1989.Any(e => e.Id == id);
    }
}
