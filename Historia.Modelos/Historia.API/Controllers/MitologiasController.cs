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
    public class MitologiasController : ControllerBase
    {
        private readonly DataContext _context;

        public MitologiasController(DataContext context)
        {
            _context = context;
        }

        // GET: api/Mitologias
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Mitologia>>> GetMitologia()
        {
          if (_context.Mitologias == null)
          {
              return NotFound();
          }            
          return await _context.Mitologias.Include(d => d.Dioses).ToListAsync();
            //return await _context.Mitologias.ToListAsync();
        }

        // GET: api/Mitologias/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Mitologia>> GetMitologia(int id)
        {
          if (_context.Mitologias == null)
          {
              return NotFound();
          }
            //var mitologia = await _context.Mitologias.FindAsync(id);
            var mitologia = _context.Mitologias.Include(d=>d.Dioses).First(d => d.Id == id);

            if (mitologia == null)
            {
                return NotFound();
            }

            return mitologia;
        }

        // PUT: api/Mitologias/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMitologia(int id, Mitologia mitologia)
        {
            if (id != mitologia.Id)
            {
                return BadRequest();
            }

            _context.Entry(mitologia).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MitologiaExists(id))
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

        // POST: api/Mitologias
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Mitologia>> PostMitologia(Mitologia mitologia)
        {
          if (_context.Mitologias == null)
          {
              return Problem("Entity set 'DataContext.Mitologia'  is null.");
          }
            _context.Mitologias.Add(mitologia);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMitologia", new { id = mitologia.Id }, mitologia);
        }

        // DELETE: api/Mitologias/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMitologia(int id)
        {
            if (_context.Mitologias == null)
            {
                return NotFound();
            }
            var mitologia = await _context.Mitologias.FindAsync(id);
            if (mitologia == null)
            {
                return NotFound();
            }

            _context.Mitologias.Remove(mitologia);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool MitologiaExists(int id)
        {
            return (_context.Mitologias?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
