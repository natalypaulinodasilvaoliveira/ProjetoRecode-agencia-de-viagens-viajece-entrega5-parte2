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
    public class ViajantesController : ControllerBase
    {
        private readonly DataContext _context;

        public ViajantesController(DataContext context)
        {
            _context = context;
        }

        // GET: api/Viajantes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Viajantes>>> GetViajantes()
        {
          if (_context.Viajantes == null)
          {
              return NotFound();
          }
            return await _context.Viajantes.ToListAsync();
        }

        // GET: api/Viajantes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Viajantes>> GetViajantes(int id)
        {
          if (_context.Viajantes == null)
          {
              return NotFound();
          }
            var viajantes = await _context.Viajantes.FindAsync(id);

            if (viajantes == null)
            {
                return NotFound();
            }

            return viajantes;
        }

        // PUT: api/Viajantes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutViajantes(int id, Viajantes viajantes)
        {
            if (id != viajantes.Id)
            {
                return BadRequest();
            }

            _context.Entry(viajantes).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ViajantesExists(id))
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

        // POST: api/Viajantes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Viajantes>> PostViajantes(Viajantes viajantes)
        {
          if (_context.Viajantes == null)
          {
              return Problem("Entity set 'DataContext.Viajantes'  is null.");
          }
            _context.Viajantes.Add(viajantes);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetViajantes", new { id = viajantes.Id }, viajantes);
        }

        // DELETE: api/Viajantes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteViajantes(int id)
        {
            if (_context.Viajantes == null)
            {
                return NotFound();
            }
            var viajantes = await _context.Viajantes.FindAsync(id);
            if (viajantes == null)
            {
                return NotFound();
            }

            _context.Viajantes.Remove(viajantes);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ViajantesExists(int id)
        {
            return (_context.Viajantes?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
