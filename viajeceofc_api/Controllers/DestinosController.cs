using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using viajeceofc_api.Context;
using viajeceofc_api.Models;

namespace viajeceofc_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DestinosController : ControllerBase
    {
        private readonly DataContext _context;

        public DestinosController(DataContext context)
        {
            _context = context;
        }

        // GET: api/Destinos
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Destinos>>> GetDestinos()
        {
          if (_context.Destinos == null)
          {
              return NotFound();
          }
            return await _context.Destinos.ToListAsync();
        }

        // GET: api/Destinos/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Destinos>> GetDestinos(int id)
        {
          if (_context.Destinos == null)
          {
              return NotFound();
          }
            var destinos = await _context.Destinos.FindAsync(id);

            if (destinos == null)
            {
                return NotFound();
            }

            return destinos;
        }

        // PUT: api/Destinos/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDestinos(int id, Destinos destinos)
        {
            if (id != destinos.Id)
            {
                return BadRequest();
            }

            _context.Entry(destinos).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DestinosExists(id))
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

        // POST: api/Destinos
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Destinos>> PostDestinos(Destinos destinos)
        {
          if (_context.Destinos == null)
          {
              return Problem("Entity set 'DataContext.Destinos'  is null.");
          }
            _context.Destinos.Add(destinos);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDestinos", new { id = destinos.Id }, destinos);
        }

        // DELETE: api/Destinos/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDestinos(int id)
        {
            if (_context.Destinos == null)
            {
                return NotFound();
            }
            var destinos = await _context.Destinos.FindAsync(id);
            if (destinos == null)
            {
                return NotFound();
            }

            _context.Destinos.Remove(destinos);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool DestinosExists(int id)
        {
            return (_context.Destinos?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
