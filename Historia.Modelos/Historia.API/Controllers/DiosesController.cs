using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Historia.Modelos;

namespace Historia.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DiosesController : ControllerBase
    {
        private readonly DataContext _context;

        public DiosesController(DataContext context)
        {
            _context = context;
        }

        // GET: api/Dioses
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Dios>>> GetDios()
        {
          if (_context.Dioses == null)
          {
              return NotFound();
          }
            //return await _context.Dioses.ToListAsync();
            return await _context.Dioses.Include(d => d.Mitologia).ToListAsync();
        }

        // GET: api/Dioses/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Dios>> GetDios(int id)
        {
          if (_context.Dioses == null)
          {
              return NotFound();
          }
            //var dios = await _context.Dioses.FindAsync(id);
            var dios = _context.Dioses.Include(d => d.Mitologia).First(d => d.Id==id);

            if (dios == null)
            {
                return NotFound();
            }

            return dios;
        }

        // PUT: api/Dioses/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDios(int id, Dios dios)
        {
            if (id != dios.Id)
            {
                return BadRequest();
            }

            _context.Entry(dios).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DiosExists(id))
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

        // POST: api/Dioses
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Dios>> PostDios(Dios dios)
        {
          if (_context.Dioses == null)
          {
              return Problem("Entity set 'DataContext.Dios'  is null.");
          }
            _context.Dioses.Add(dios);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDios", new { id = dios.Id }, dios);
        }

        // DELETE: api/Dioses/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDios(int id)
        {
            if (_context.Dioses == null)
            {
                return NotFound();
            }
            var dios = await _context.Dioses.FindAsync(id);
            if (dios == null)
            {
                return NotFound();
            }

            _context.Dioses.Remove(dios);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool DiosExists(int id)
        {
            return (_context.Dioses?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
